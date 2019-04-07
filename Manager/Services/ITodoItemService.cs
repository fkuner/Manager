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
        List<TodoItem> ListAsync();
        void AddAsync(TodoItem todoItem);
        void DeleteAsync(TodoItem todoItem);
        int FindMemoItem(List<TodoItem> TodoItems, TodoItem todoItem);
    }
}
