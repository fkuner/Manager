using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Manager.Models;
using Manager.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Manager.ViewModels
{
    /// <summary>
    /// ToolsPage的 ViewModel
    /// </summary>
    public class ToolsPageViewModel: ViewModelBase
    {
        private IToolItemService _toolItemService;

        /// <summary>
        /// 所有MemoItem。
        /// </summary>
        private ObservableCollection<ToolItem> _toolItems;

        /// <summary>
        /// 刷新备忘录命令。
        /// </summary>
        private RelayCommand _refreshCommand;

        /// <summary>
        /// 增加备忘录条目命令
        /// </summary>
        private RelayCommand _addCommand;

        /// <summary>
        /// 要添加的备忘录
        /// </summary>
        private ToolItem _addToolItem;

        /// <summary>
        /// 所有MemoItem。
        /// </summary>
        public ObservableCollection<ToolItem> ToolItems
        {
            get => _toolItems;
            set => Set(nameof(ToolItems), ref _toolItems, value);
        }

        /// <summary>
        /// 要添加的备忘录
        /// </summary>
        public ToolItem AddToolItem
        {
            get => _addToolItem;
            set => Set(nameof(AddToolItem), ref _addToolItem, value);
        }
        
        /// <summary>
        /// 刷新备忘录命令。
        /// </summary>
        public RelayCommand RefreshCommand =>
            _refreshCommand ?? (_refreshCommand = new RelayCommand(async () => {
                ToolItems.Clear();
                foreach (ToolItem memoitem in _toolItemService.ListAsync())
                {
                    ToolItems.Add(memoitem);
                }
            }));

        /// <summary>
        /// 添加备忘录命令。
        /// </summary>
        public RelayCommand AddCommand =>
            _addCommand ?? (_addCommand = new RelayCommand(async () => {
                _toolItemService.AddAsync(_addToolItem);
            }));


        public ToolsPageViewModel ( IToolItemService toolItemService)
        {
            ToolItems = new ObservableCollection<ToolItem>();
            ToolItems.Clear();
            foreach (ToolItem toolitem in toolItemService.ListAsync())
            {
                ToolItems.Add(toolitem);
            }
        }
    }
}
