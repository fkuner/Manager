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
                    List.Add(new MoneyItem { Id = Convert.ToInt32(query["Id"]), ConsumeTime = Convert.ToDateTime(query["ConsumeTime"].ToString()), Event = query["Event"].ToString(), Amount = Convert.ToDouble(query["Amount"]) , CoverImage = query["CoverImage"].ToString() });
                }
                db.Close();
            }
            return List;
        }

        public void AddAsync(MoneyItem moneyItem)
        {
            using (SqliteConnection db = new SqliteConnection("Filename=sqliteData.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT INTO MoneyItemTable VALUES (@id,@time,@event,@amount,@cover);";
                insertCommand.Parameters.AddWithValue("@id", moneyItem.Id);
                insertCommand.Parameters.AddWithValue("@time", moneyItem.ConsumeTime);
                insertCommand.Parameters.AddWithValue("@event", moneyItem.Event);
                insertCommand.Parameters.AddWithValue("@amount", moneyItem.Amount);
                insertCommand.Parameters.AddWithValue("@cover", moneyItem.CoverImage);
                insertCommand.ExecuteReader();
                db.Close();
            }
        }

        public void DeleteAsync(MoneyItem moneyItem)
        {
            using (SqliteConnection db = new SqliteConnection("Filename=sqliteData.db"))
            {
                db.Open();

                SqliteCommand deleteCommand = new SqliteCommand("DELETE FROM MoneyItemTable WHERE Id = @id AND ConsumeTime = @time AND Event = @event AND Amount = @amount AND CoverImage = @cover;");
                deleteCommand.Parameters.AddWithValue("@id", moneyItem.Id);
                deleteCommand.Parameters.AddWithValue("@time", moneyItem.ConsumeTime);
                deleteCommand.Parameters.AddWithValue("@event", moneyItem.Event);
                deleteCommand.Parameters.AddWithValue("@amount", moneyItem.Amount);
                deleteCommand.Parameters.AddWithValue("@cover", moneyItem.CoverImage);
                deleteCommand.ExecuteReader();
                db.Close();
            }
        }
    }
}
