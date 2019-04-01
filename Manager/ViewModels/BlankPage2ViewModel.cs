using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Manager.Models;
using Manager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.ViewModels
{
    /// <summary>
    /// BlankPage2的ViewModel
    /// </summary>
    class BlankPage2ViewModel : ViewModelBase
    {
        private TodoItemService todoItemService=new TodoItemService(); 
        
       

        /// <summary>
        /// 第一个TodoItem。
        /// </summary>
        private TodoItem _firstTodoItem;

        /// <summary>
        /// 第一个TodoItem。
        /// </summary>
        public TodoItem FirstTodoItem
        {
            get => _firstTodoItem;
            set => Set(nameof(FirstTodoItem), ref _firstTodoItem, value);
        }

        /// <summary>
        /// 所有TodoItem。
        /// </summary>
        private IEnumerable<TodoItem> _todoItems;

        /// <summary>
        /// 所有TodoItem。
        /// </summary>
        public IEnumerable<TodoItem> TodoItems
        {
            get => _todoItems;
            set => Set(nameof(TodoItems), ref _todoItems, value);
        }

        /// <summary>
        /// 刷新命令。
        /// </summary>
        private RelayCommand _refreshCommand;

        /// <summary>
        /// 刷新命令。
        /// </summary>
        public RelayCommand RefreshCommand =>
            _refreshCommand ?? (_refreshCommand = new RelayCommand(async () => {
                //var todoItemService = new TodoItemService();
                var todoItemList = await todoItemService.ListAsync();
                FirstTodoItem = todoItemList[0];
                TodoItems = todoItemList;
            }));

        /// <summary>
        /// 增加命令
        /// </summary>
        private RelayCommand _addCommand;

        /// <summary>
        /// 增加命令
        /// </summary>
        public RelayCommand AddCommand =>
            _addCommand ?? (_addCommand = new RelayCommand(async () => {
                await todoItemService.AddAsync(_addTodoItem);
            }));

        private TodoItem _addTodoItem=new TodoItem();
        public TodoItem AddTodoItem
        {
            get => _addTodoItem;
            set =>  Set(nameof(AddTodoItem), ref _addTodoItem, value);
        }
 
    }
}