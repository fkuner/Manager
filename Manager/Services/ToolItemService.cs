using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Manager.Models;
using Microsoft.Data.Sqlite;

namespace Manager.Services
{
    public class ToolItemService : IToolItemService
    {
        public static void InitializeDatabase()
        {
            using (SqliteConnection db = new SqliteConnection("Filename=sqliteData.db"))
            {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT EXISTS ToolItemTable " +
                                      "(ID INTEGER PRIMARY KEY AUTOINCREMENT," +
                                      "Content NVACHAR(2048) NULL);";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }

        }
        public List<ToolItem> ListAsync()
        {
            //throw new NotImplementedException();
            List<ToolItem> List = new List<ToolItem>();
            using (SqliteConnection db = new SqliteConnection("Filename=sqliteData.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from ToolItemTable", db);
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    List.Add(new ToolItem { ID = Convert.ToInt32(query["ID"]), Content = query["Content"].ToString() });
                }
                db.Close();
            }
            return List;
        }

        /// <summary>
        /// 增加命令
        /// </summary>
        /// <param name="toolItem"></param>
        public void AddAsync(ToolItem toolItem)
        {

            //throw new NotImplementedException();
          
            using (SqliteConnection db = new SqliteConnection("Filename=sqliteData.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT INTO ToolItemTable (Content) VALUES (@content);";
                insertCommand.Parameters.AddWithValue("@content", toolItem.Content);

                insertCommand.ExecuteReader();
                db.Close();
            }
        }

        /// <summary>
        /// 删除命令
        /// </summary>
        /// <param name="toolItem"></param>
        public void DeleteAsync(ToolItem toolItem)
        {
            //throw new NotImplementedException();
            
            using (SqliteConnection db = new SqliteConnection("Filename=sqliteData.db"))
            {
                db.Open();

                SqliteCommand deleteCommand = new SqliteCommand("DELETE FROM ToolItemTable WHERE ID = @id;");
                deleteCommand.Connection = db;
                deleteCommand.Parameters.AddWithValue("@id", toolItem.ID);

                deleteCommand.ExecuteReader();
                db.Close();
            }
        }

        public void ChangeAsync(int id, ToolItem toolItem)
        {
            throw new NotImplementedException();
        }
    }
}
