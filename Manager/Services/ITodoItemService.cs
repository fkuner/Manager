using Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Services
{
    public interface ITodoItemService
    {
        /// <summary>
        /// 同IMemoItem理
        /// </summary>
        /// <returns></returns>
        List<TodoItem> ListAsync();
        /// <summary>
        /// 同AddMemoItem理
        /// </summary>
        /// <param name="todoItem"></param>
        void AddAsync(TodoItem todoItem);
        /// <summary>
        /// 同DeleteMemoItem理
        /// </summary>
        /// <param name="todoItem"></param>
        void DeleteAsync(TodoItem todoItem);
        /// <summary>
        /// 同FindMemoItem理
        /// </summary>
        /// <param name="TodoItems"></param>
        /// <param name="todoItem"></param>
        /// <returns></returns>
        int FindMemoItem(List<TodoItem> TodoItems, TodoItem todoItem);
    }
}
