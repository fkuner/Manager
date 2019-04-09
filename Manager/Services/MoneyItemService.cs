using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manager.Models;
using Microsoft.Data.Sqlite;

namespace Manager.Services
{
    public class MoneyItemService : IMoneyItemService
    {
        /// <summary>
        /// 初始化方法，连接数据库+第一次使用建表
        /// </summary>
        public static void InitializeDatabase()
        {
            using (SqliteConnection db = new SqliteConnection("Filename=sqliteData.db"))
            {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT EXISTS MoneyItemTable " +
                    "(Id INTEGER PRIMARY KEY NOT NULL," +
                    "ConsumeTime DATE," +
                    "Event NVACHAR(2048) NULL," +
                    "Amount DOUBLE," +
                    "CoverImage NVACHAR(2048) NULL);";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }
        }

        public List<MoneyItem> ListAsync()
        {
            //throw new NotImplementedException();
            List<MoneyItem> List = new List<MoneyItem>();
            using (SqliteConnection db = new SqliteConnection("Filename=sqliteData.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand
            ("SELECT * from MoneyItemTable", db);
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    List.Add(new MoneyItem { Id = Convert.ToInt32(query["Id"]), DateCreated = Convert.ToDateTime(query["DateCreated"].ToString()), Title = query["Title"].ToString(), Text = query["Text"].ToString() });
                }
                db.Close();
            }
            return List;
        }

        public void AddAsync(MoneyItem moneyItem)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(MoneyItem moneyItem)
        {
            throw new NotImplementedException();
        }
    }
}
