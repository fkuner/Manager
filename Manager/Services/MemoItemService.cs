using Manager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Services
{
    public class MemoItemService : IMemoItemService
    {
        public void AddAsync(MemoItem memoItem)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(MemoItem memoItem)
        {
            throw new NotImplementedException();
        }

        public int FindMemoItem(List<MemoItem> MemoItems, MemoItem memoItem)
        {
            throw new NotImplementedException();
        }

        //private MemoItem _memoItem;


        public List<MemoItem>  ListAsync()
        {
            List<MemoItem> MemoItems = new List<MemoItem>();

            for (int i=0;i<5;i++)
            {
                MemoItem memoItem = new MemoItem();
                memoItem.Content=i.ToString();
                MemoItems.Add(memoItem);
            }
            return MemoItems;
            throw new NotImplementedException();
        }
    }
}
