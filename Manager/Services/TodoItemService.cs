using Manager.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Services
{
    public class TodoItemService : ITodoItemService
    {
        public void AddAsync(TodoItem todoItem)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(TodoItem todoItem)
        {
            throw new NotImplementedException();
        }

        public int FindMemoItem(List<TodoItem> TodoItems, TodoItem todoItem)
        {
            throw new NotImplementedException();
        }

        //private TodoItem _TodoItem;


        public List<TodoItem> ListAsync()
        {
            List<TodoItem> TodoItems = new List<TodoItem>();
            for (int i = 0; i < 5; i++)
            {
                TodoItem todoItem = new TodoItem();
                todoItem.Content = i.ToString();
                TodoItems.Add(todoItem);
            }
            return TodoItems;
            throw new NotImplementedException();
        }
    }
}
