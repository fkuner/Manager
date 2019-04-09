using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manager.Models;
using Microsoft.Data.Sqlite;

namespace Manager.Services
{
    public class MemoItemService : IMemoItemService
    {
        /// <summary>
        /// 初始化方法，连接数据库+第一次使用建表
        /// </summary>
        public static void InitializeDatabase()
        {
            using (SqliteConnection db = new SqliteConnection("Filename=sqliteData.db"))
            {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT EXISTS MemoItemTable " +
                    "(Id INTEGER PRIMARY KEY NOT NULL," +
                    "DateCreated DATE," +
                    "Title NVACHAR(2048) NULL," +
                    "Text NVACHAR(2048) NULL);";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }
        }

        public void AddAsync(MemoItem memoItem)
        {
            //throw new NotImplementedException();
            using (SqliteConnection db = new SqliteConnection("Filename=sqliteData.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT INTO MemoItemTable VALUES (@id,@date,@title,@text);";
                insertCommand.Parameters.AddWithValue("@id", memoItem.Id);
                insertCommand.Parameters.AddWithValue("@date", memoItem.DateCreated);
                insertCommand.Parameters.AddWithValue("@title", memoItem.Title);
                insertCommand.Parameters.AddWithValue("@text", memoItem.Text);
                insertCommand.ExecuteReader();
                db.Close();
            }
        }

        public void ChangeAsync(int id, MemoItem memoItem)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(MemoItem memoItem)
        {
            //throw new NotImplementedException();
            using (SqliteConnection db = new SqliteConnection("Filename=sqliteData.db"))
            {
                db.Open();

                SqliteCommand deleteCommand = new SqliteCommand("DELETE FROM MemoItemTable WHERE Id = @id AND DateCreated = @date AND Title = @title AND Text = @text;");
                deleteCommand.Parameters.AddWithValue("@id", memoItem.Id);
                deleteCommand.Parameters.AddWithValue("@date", memoItem.DateCreated);
                deleteCommand.Parameters.AddWithValue("@title", memoItem.Title);
                deleteCommand.Parameters.AddWithValue("@text", memoItem.Text);
                deleteCommand.ExecuteReader();
                db.Close();
            }
        }

        public List<MemoItem> ListAsync()
        {
            //throw new NotImplementedException();
            List<MemoItem> List = new List<MemoItem>();
            using (SqliteConnection db = new SqliteConnection("Filename=sqliteData.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand
            ("SELECT * from MemoItemTable", db);
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    List.Add(new MemoItem { Id = Convert.ToInt32(query["Id"]), DateCreated = Convert.ToDateTime(query["DateCreated"].ToString()), Title = query["Title"].ToString(), Text = query["Text"].ToString() });
                }
                db.Close();
            }
            return List;
        }
    }
}
