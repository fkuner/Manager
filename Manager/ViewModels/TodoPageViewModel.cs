using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Manager.Models;
using Manager.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.ViewModels
{
    /// <summary>
    /// TodoPage的ViewModel
    /// </summary>
    public class TodoPageViewModel : ViewModelBase
    {
        private ITodoItemService _todoItemService;

        /// <summary>
        /// 所有TodoItem。
        /// </summary>
        private ObservableCollection<TodoItem> _todoItems;

        /// <summary>
        /// 刷新提醒事项命令。
        /// </summary>
        private RelayCommand _refreshCommand;

        /// <summary>
        /// 增加提醒事项条目命令
        /// </summary>
        private RelayCommand _addCommand;

        /// <summary>
        /// 删除提醒事项条目命令
        /// </summary>
        private RelayCommand _deleteCommand;

        /// <summary>
        /// 要添加的提醒事项
        /// </summary>
        private TodoItem _addTodoItem;

        /// <summary>
        /// 要删除的提醒事项
        /// </summary>
        private TodoItem _deleteTodoItem;

        /// <summary>
        /// 所有TodoItem。
        /// </summary>
        public ObservableCollection<TodoItem> TodoItems
        {
            get => _todoItems;
            set => Set(nameof(TodoItems), ref _todoItems, value);
        }

        /// <summary>
        /// 要添加的提醒事项
        /// </summary>
        public TodoItem AddTodoItem
        {
            get => _addTodoItem;
            set => Set(nameof(AddTodoItem), ref _addTodoItem, value);
        }

        /// <summary>
        /// 要删除的提醒事项
        /// </summary>
        public TodoItem DeleteTodoItem
        {
            get => _deleteTodoItem;
            set => Set(nameof(DeleteTodoItem), ref _deleteTodoItem, value);
        }
        /// <summary>
        /// 刷新提醒事项命令。
        /// </summary>
        public RelayCommand RefreshCommand =>
            _refreshCommand ?? (_refreshCommand = new RelayCommand(async () => {
                TodoItems.Clear();
                foreach (TodoItem todoitem in _todoItemService.ListAsync())
                {
                    TodoItems.Add(todoitem);
                }
            }));

        /// <summary>
        /// 添加提醒事项命令。
        /// </summary>
        public RelayCommand AddCommand =>
            _addCommand ?? (_addCommand = new RelayCommand(async () => {
                _todoItemService.AddAsync(_addTodoItem);
            }));

        /// <summary>
        /// 删除提醒事项命令。
        /// </summary>
        public RelayCommand DeleteCommand =>
            _deleteCommand ?? (_deleteCommand = new RelayCommand(async () =>
            {
                _todoItemService.DeleteAsync(_deleteTodoItem);
            }));

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="todoItemService"></param>
        public TodoPageViewModel(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
            TodoItems = new ObservableCollection<TodoItem>();
            TodoItems.Clear();
            foreach (TodoItem todoitem in todoItemService.ListAsync())
            {
                TodoItems.Add(todoitem);
            }
        }

    }
}