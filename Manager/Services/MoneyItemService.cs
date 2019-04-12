using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manager.Models;
using Microsoft.Data.Sqlite;
using System.IO;
using System.Text;

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
                    "(Id INTEGER PRIMARY KEY," +
                    "ConsumeTime DATE," +
                    "Event NVACHAR(2048) NULL," +
                    "Amount DOUBLE," +
                    "CoverImage NVACHAR(2048) NULL);";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();

                String tableCommand1 = "CREATE TABLE IF NOT EXISTS SetTable " +
                    "(Id INTEGER PRIMARY KEY," +
                    "Amount DOUBLE NOT NULL);";
                SqliteCommand createTable1 = new SqliteCommand(tableCommand1, db);

                createTable1.ExecuteReader();
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
                    List.Add(new MoneyItem { Id = Convert.ToInt32(query["Id"]), ConsumeTime = Convert.ToDateTime(query["ConsumeTime"].ToString()), Event = query["Event"].ToString(), Amount = Convert.ToDouble(query["Amount"]), CoverImage = query["CoverImage"].ToString() });
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

                insertCommand.CommandText = "INSERT INTO MoneyItemTable VALUES (NULL,@time,@event,@amount,@cover);";
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

                SqliteCommand deleteCommand = new SqliteCommand("DELETE FROM MoneyItemTable WHERE Id = @id AND ConsumeTime = @time AND Event = @event AND Amount = @amount AND CoverImage = @cover;", db);
                deleteCommand.Parameters.AddWithValue("@id", moneyItem.Id);
                deleteCommand.Parameters.AddWithValue("@time", moneyItem.ConsumeTime);
                deleteCommand.Parameters.AddWithValue("@event", moneyItem.Event);
                deleteCommand.Parameters.AddWithValue("@amount", moneyItem.Amount);
                deleteCommand.Parameters.AddWithValue("@cover", moneyItem.CoverImage);
                deleteCommand.ExecuteReader();
                db.Close();
            }
        }

        public void ChangeAsync(int id, MoneyItem moneyItem)
        {
            //throw new NotImplementedException();
            //这里实现更新操作
            using (SqliteConnection db = new SqliteConnection("Filename=sqliteData.db"))
            {
                db.Open();

                SqliteCommand updateCommand = new SqliteCommand("UPDATE MoneyItemTable SET ConsumeTime = @time , Event = @event , Amount = @amount WHERE Id = @id;", db);
                updateCommand.Parameters.AddWithValue("@time", moneyItem.ConsumeTime);
                updateCommand.Parameters.AddWithValue("@event", moneyItem.Event);
                updateCommand.Parameters.AddWithValue("@amount", moneyItem.Amount);
                //updateCommand.Parameters.AddWithValue("@cover", moneyItem.CoverImage);
                updateCommand.Parameters.AddWithValue("@id", id);
                updateCommand.ExecuteReader();
                db.Close();
            }
        }

        public double SearchAsync(DateTime date)
        {
            //throw new NotImplementedException();
            double sum = 0;
            using (SqliteConnection db = new SqliteConnection("Filename=sqliteData.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand("SELECT * FROM MoneyItemTable WHERE strftime('%Y/%m',ConsumeTime) = @time;", db);
                Console.WriteLine(date.ToString("yyyy/MM"));
                selectCommand.Parameters.AddWithValue("@time", date.ToString("yyyy/MM"));
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    sum += Convert.ToDouble(query["Amount"]);
                    Console.WriteLine(sum);
                }
                db.Close();
            }
            return sum;
        }

        public void ClearAsync()
        {
            using (SqliteConnection db = new SqliteConnection("Filename=sqliteData.db"))
            {
                db.Open();

                SqliteCommand deleteCommand = new SqliteCommand();
                deleteCommand.Connection = db;
                deleteCommand.CommandText = "DELETE FROM SetTable";
                deleteCommand.ExecuteReader();

                db.Close();
            }
        }

        public void SaveAsync(double Consume)
        {
            using (SqliteConnection db = new SqliteConnection("Filename=sqliteData.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT INTO SetTable VALUES (NULL,@amount);";
                insertCommand.Parameters.AddWithValue("@amount", Consume);
                insertCommand.ExecuteReader();

                db.Close();
            }
        }

        public List<double> ReadAsync()
        {
            List<double> List = new List<double>();
            using (SqliteConnection db = new SqliteConnection("Filename=sqliteData.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand
            ("SELECT * from SetTable", db);
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    List.Add(Convert.ToDouble(query["Amount"]));
                }
                db.Close();
            }
            return List;
        }
    }
}
