using Manager.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace Manager.Services
{
    public class TodoItemService : ITodoItemService
    {
        /// <summary>
        /// 初始化方法
        /// </summary>
        public static void InitializeDatabase()
        {
            using (SqliteConnection db = new SqliteConnection("Filename=sqliteData.db"))
            {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT EXISTS TodoItemTable " +
                                      "(ID INTEGER PRIMARY KEY NOT NULL," +
                                      "Content NVACHAR(2048) NULL);";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }
        }

        /// <summary>
        /// 插入元素的方法
        /// </summary>
        public void AddAsync(TodoItem todoItem)
        {
            using (SqliteConnection db = new SqliteConnection("Filename=sqliteData.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT INTO TodoItemTable VALUES (@id,@content);";
                insertCommand.Parameters.AddWithValue("@id", todoItem.ID);
                insertCommand.Parameters.AddWithValue("@content", todoItem.Content);

                insertCommand.ExecuteReader();
                db.Close();
            }
        }

        /// <summary>
        /// 删除元素的方法
        /// </summary>
        public void DeleteAsync(TodoItem todoItem)
        {
            //throw new NotImplementedException();
            using (SqliteConnection db = new SqliteConnection("Filename=sqliteData.db"))
            {
                db.Open();

                SqliteCommand deleteCommand = new SqliteCommand("DELETE FROM TodoItemTable WHERE ID = @id;");
                deleteCommand.Parameters.AddWithValue("@id", todoItem.ID);

                deleteCommand.ExecuteReader();
                db.Close();
            }
        }

        /// <summary>
        /// 查找元素的方法
        /// </summary>
        public int FindMemoItem(List<TodoItem> TodoItems, TodoItem todoItem)
        {
            throw new NotImplementedException();
        }

        //private TodoItem _TodoItem;



        /// <summary>
        /// 列出所有元素的方法
        /// </summary>
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
                    List.Add(new TodoItem {ID = Convert.ToInt32(query["ID"]), Content = query["Content"].ToString()});
                }

                db.Close();
            }
        
        return List;
            //throw new NotImplementedException();
        }
    }
}
