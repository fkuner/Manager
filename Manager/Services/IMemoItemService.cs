using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manager.Models;

namespace Manager.Services
{
    public interface IMemoItemService
    {
        /// <summary>
        /// 返回数据库表单
        /// </summary>
        /// <returns></returns>
        List<MemoItem> ListAsync();

        /// <summary>
        /// 添加操作
        /// </summary>
        /// <param name="memoItem"></param>
        void AddAsync(MemoItem memoItem);

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="memoItem"></param>
        void DeleteAsync(MemoItem memoItem);

        /// <summary>
        /// 根据Id改变数据库中的MemoItem。
        /// </summary>
        /// <param name="id"></param>
        /// <param name="memoItem"></param>
        void ChangeAsync(int id, MemoItem memoItem);
    }
}
