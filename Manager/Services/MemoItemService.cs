using Manager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace Manager.Services
{
    class MemoItemService
    {
<<<<<<< HEAD
<<<<<<< HEAD
        //缺一个初始化命令,坤哥，等会儿你试的时候一定要App.xaml.cs加载中给它初始化
        public void InitializeDatabase()
        {
            using (SqliteConnection db = new SqliteConnection("Filename=sqliteData.db"))
            {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT EXISTS MemoItemTable " +
                    "(ID INTEGER PRIMARY KEY NOT NULL," +
                    "Content NVACHAR(2048) NULL)";

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

=======
>>>>>>> parent of 908a51a... 客户端架构模式终极版
=======
>>>>>>> parent of 908a51a... 客户端架构模式终极版
        //private MemoItem _memoItem;


        public ObservableCollection<MemoItem>  ListAsync()
        {
<<<<<<< HEAD
<<<<<<< HEAD
            List<MemoItem> List = new List<MemoItem>();
            using (SqliteConnection db = new SqliteConnection("Filename=sqliteData.db"))
=======
=======
>>>>>>> parent of 908a51a... 客户端架构模式终极版
            ObservableCollection<MemoItem> MemoItems = new ObservableCollection<MemoItem>();

            for (int i=0;i<5;i++)
>>>>>>> parent of 908a51a... 客户端架构模式终极版
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand
            ("SELECT * from MemoItemTable", db);
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    List.Add(new MemoItem { ID=(int)query["ID"],Content=query["Content"].ToString()});
                }
                db.Close();
            }
<<<<<<< HEAD
            return List;
=======
            return MemoItems;
<<<<<<< HEAD
>>>>>>> parent of 908a51a... 客户端架构模式终极版
=======
>>>>>>> parent of 908a51a... 客户端架构模式终极版
        }
    }
}
