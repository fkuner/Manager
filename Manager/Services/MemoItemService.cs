using Manager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Services
{
    class MemoItemService
    {
        //private MemoItem _memoItem;


        public ObservableCollection<MemoItem>  ListAsync()
        {
            ObservableCollection<MemoItem> MemoItems = new ObservableCollection<MemoItem>();

            for (int i=0;i<5;i++)
            {
                MemoItem memoItem = new MemoItem();
                memoItem.Content=i.ToString();
                MemoItems.Add(memoItem);
            }
            return MemoItems;
        }
    }
}
