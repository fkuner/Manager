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
        /// <summary>
        /// ListAsynv返回所有的MemoItem对象
        /// </summary>
        /// <returns></returns>
        List<MemoItem> ListAsync();
        /// <summary>
        /// AddAsync添加一个MemoItem对象
        /// </summary>
        /// <param name="memoItem"></param>
        void AddAsync(MemoItem memoItem);
        /// <summary>
        /// DeleteAsync表示删除一个MemoItem对象
        /// </summary>
        /// <param name="memoItem"></param>
        void DeleteAsync(MemoItem memoItem);
        /// <summary>
        /// FindMemoItem表示寻找一个数据对象,这里我感觉这个接口可能有点小问题
        /// </summary>
        /// <param name="MemoItems"></param>
        /// <param name="memoItem"></param>
        /// <returns></returns>
        int FindMemoItem(List<MemoItem> MemoItems,MemoItem memoItem);
    }
}
