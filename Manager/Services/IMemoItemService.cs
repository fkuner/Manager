using Manager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Services
{
    public interface IMemoItemService
    {
        List<MemoItem> ListAsync();
        void AddAsync(MemoItem memoItem);
        void DeleteAsync(MemoItem memoItem);
        int FindMemoItem(List<MemoItem> MemoItems,MemoItem memoItem);
    }
}
