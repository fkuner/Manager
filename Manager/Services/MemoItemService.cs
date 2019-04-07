﻿using Manager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace Manager.Services
{
    public class MemoItemService : IMemoItemService
    {
        //缺一个初始化命令,坤哥，等会儿你试的时候一定要App.xaml.cs加载中给它初始化
        public static void InitializeDatabase()
        {
            using (SqliteConnection db = new SqliteConnection("Filename=sqliteData.db"))
            {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT EXISTS MemoItemTable " +
                    "(ID INTEGER PRIMARY KEY NOT NULL," +
                    "Content NVACHAR(2048) NULL);";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }
        }

        public void AddAsync(MemoItem memoItem)
        {
            //throw new NotImplementedException();
            //添加命令
            using (SqliteConnection db = new SqliteConnection("Filename=sqliteData.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT INTO MemoItemTable VALUES (@id,@content);";
                insertCommand.Parameters.AddWithValue("@id", memoItem.ID);
                insertCommand.Parameters.AddWithValue("@content", memoItem.Content);

                insertCommand.ExecuteReader();
                db.Close();
            }

        }

        public void DeleteAsync(MemoItem memoItem)
        {
            //throw new NotImplementedException();
            //删除命令
            using (SqliteConnection db = new SqliteConnection("Filename=sqliteData.db"))
            {
                db.Open();

                SqliteCommand deleteCommand = new SqliteCommand("DELETE FROM MemoItemTable WHERE ID = @id;");
                deleteCommand.Parameters.AddWithValue("@id", memoItem.ID);

                deleteCommand.ExecuteReader();
                db.Close();
            }
        }

        public int FindMemoItem(List<MemoItem> MemoItems, MemoItem memoItem)
        {
            //throw new NotImplementedException();
            //这里不涉及数据库操作吗？感觉这个接口写的有点问题，坤哥等会儿你自己改一下
            foreach (MemoItem m in MemoItems)
            {
                if(m.ID == memoItem.ID)
                {
                    return m.ID;
                }
            }
            return -1;
        }

        //private MemoItem _memoItem;


        public List<MemoItem>  ListAsync()
        {
            List<MemoItem> List = new List<MemoItem>();
            using (SqliteConnection db = new SqliteConnection("Filename=sqliteData.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand
            ("SELECT * from MemoItemTable", db);
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    List.Add(new MemoItem { ID=Convert.ToInt32(query["ID"]),Content=query["Content"].ToString()});
                }
                db.Close();
            }
            return List;
        }
    }
}