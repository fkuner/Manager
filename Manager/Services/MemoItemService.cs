using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manager.Models;

namespace Manager.Services
{
    public class MemoItemService : IMemoItemService
    {

        public void AddAsync(MemoItem memoItem)
        {
            //throw new NotImplementedException();
            
        }

        public void DeleteAsync(MemoItem memoItem)
        {
            //throw new NotImplementedException();
        }

        public List<MemoItem> ListAsync()
        {
            //throw new NotImplementedException();
            List<MemoItem> memoItems = new List<MemoItem>();
            MemoItem memoitem1 = new MemoItem();
            MemoItem memoitem2 = new MemoItem();
            memoitem1.Id = 0;
            memoitem1.DateCreated = DateTime.Now;
            memoitem1.Title = "Item 1";
            memoitem1.Text = @"hahahaha";
            memoItems.Add(memoitem1);

            memoitem2.Id = 0;
            memoitem2.DateCreated = DateTime.Now;
            memoitem2.Title = "Item 2";
            memoitem2.Text = @"xixixi";
            memoItems.Add(memoitem2);
            return memoItems;
        }
    }
}
