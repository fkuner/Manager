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
    class BlankPage1ViewModel: ViewModelBase
    {
        private MemoItemService memoItemService = new MemoItemService();

        /// <summary>
        /// 所有TodoItem。
        /// </summary>
        private ObservableCollection<MemoItem> _memoItems;

        /// <summary>
        /// 所有TodoItem。
        /// </summary>
        public ObservableCollection<MemoItem> MemoItems
        {
            get => _memoItems;
            set => Set(nameof(MemoItems), ref _memoItems, value);
        }
        /*
        /// <summary>
        /// 所有MemoItem。
        /// </summary>
        private IEnumerable<MemoItem> _memoItems;

        /// <summary>
        /// 所有MemoItem。
        /// </summary>
        public IEnumerable<MemoItem> MemoItems
        {
            get => _memoItems;
            set => Set(nameof(MemoItems), ref _memoItems, value);
        }
        */

        public BlankPage1ViewModel()
        {
            MemoItems = new ObservableCollection<MemoItem>();
            MemoItems = memoItemService.ListAsync();
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
                MemoItems = memoItemService.ListAsync();
            }));
    }
}
