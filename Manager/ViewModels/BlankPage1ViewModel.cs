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
    /// BlankPage1 ViewModel
    /// </summary>
    public class BlankPage1ViewModel: ViewModelBase
    {
        private IMemoItemService _memoItemService;

        /// <summary>
        /// 所有MemoItem。
        /// </summary>
        private ObservableCollection<MemoItem> _memoItems;

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
        private MemoItem _addMemoItem;

        /// <summary>
        /// 所有MemoItem。
        /// </summary>
        public ObservableCollection<MemoItem> MemoItems
        {
            get => _memoItems;
            set => Set(nameof(MemoItems), ref _memoItems, value);
        }

        /// <summary>
        /// 要添加的备忘录
        /// </summary>
        public MemoItem AddMemoItem
        {
            get => _addMemoItem;
            set => Set(nameof(AddMemoItem), ref _addMemoItem, value);
        }
        
        /// <summary>
        /// 刷新备忘录命令。
        /// </summary>
        public RelayCommand RefreshCommand =>
            _refreshCommand ?? (_refreshCommand = new RelayCommand(async () => {
                MemoItems.Clear();
                foreach (MemoItem memoitem in _memoItemService.ListAsync())
                {
                    MemoItems.Add(memoitem);
                }
            }));

        /// <summary>
        /// 添加备忘录命令。
        /// </summary>
        public RelayCommand AddCommand =>
            _addCommand ?? (_addCommand = new RelayCommand(async () => {
                _memoItemService.AddAsync(_addMemoItem);
            }));

       /// <summary>
       /// 构造函数
       /// </summary>
       /// <param name="memoItemService"></param>
        public BlankPage1ViewModel(IMemoItemService memoItemService)
        {
            MemoItems = new ObservableCollection<MemoItem>();
            MemoItems.Clear();
            foreach (MemoItem memoitem in memoItemService.ListAsync())
            {
                MemoItems.Add(memoitem);
            }
        }
    }
}
