using Manager.Models;
using Microsoft.Data.Sqlite;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Services
{
    public class TodoItemService : ITodoItemService
    {
        /// <summary>
        /// 初始化方法，连接数据库+第一次使用建表
        /// </summary>
        public static void InitializeDatabase()
        {
            using (SqliteConnection db = new SqliteConnection("Filename=sqliteData.db"))
            {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT EXISTS TodoItemTable " +
                    "(ID INTEGER PRIMARY KEY NOT NULL," +
                    "Content NVACHAR(2048) NULL," +
                    "DateCreated DATE);";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }
        }

        public void AddAsync(TodoItem todoItem)
        {
            using (SqliteConnection db = new SqliteConnection("Filename=sqliteData.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT INTO TodoItemTable (Content, DateCreated) VALUES (@content, @date);";
                insertCommand.Parameters.AddWithValue("@content", todoItem.Content);
                insertCommand.Parameters.AddWithValue("@date", todoItem.DateCreated);
                insertCommand.ExecuteReader();
                db.Close();
            }
        }

        public void ChangeAsync(int id, TodoItem todoItem)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(TodoItem todoItem)
        {
            using (SqliteConnection db = new SqliteConnection("Filename=sqliteData.db"))
            {
                db.Open();

                SqliteCommand deleteCommand = new SqliteCommand("DELETE FROM TodoItemTable WHERE ID = @id AND Content = @content AND DateCreated = @date;");
                deleteCommand.Parameters.AddWithValue("@id", todoItem.ID);
                deleteCommand.Parameters.AddWithValue("@content", todoItem.Content);
                deleteCommand.Parameters.AddWithValue("@date", todoItem.DateCreated);
                deleteCommand.ExecuteReader();
                db.Close();
            }
        }

        public int FindMemoItem(List<TodoItem> TodoItems, TodoItem todoItem)
        {
            throw new NotImplementedException();
        }

        //private TodoItem _TodoItem;


        public List<TodoItem> ListAsync()
        {
            List<TodoItem> List = new List<TodoItem>();
            using (SqliteConnection db = new SqliteConnection("Filename=sqliteData.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand
            ("SELECT * from TodoItemTable", db);
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    List.Add(new TodoItem { ID = Convert.ToInt32(query["ID"]), Content = query["Content"].ToString(), DateCreated = Convert.ToDateTime(query["DateCreated"].ToString()) });
                }
                db.Close();
            }
            return List;

        }
    }
}
