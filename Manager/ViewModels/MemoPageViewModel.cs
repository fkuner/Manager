using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Manager.Models;
using Manager.Services;

namespace Manager.ViewModels
{

    /// <summary>
    /// MemoPage的ViewModel
    /// </summary>
    public class MemoPageViewModel : ViewModelBase
    {

        /// <summary>
        /// 备忘录服务
        /// </summary>
        private IMemoItemService _memoItemService;

        /// <summary>
        /// 导航服务
        /// </summary>
        private INavigationService _navigationService;
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
        /// 导航到备忘录详细页命令
        /// </summary>
        private RelayCommand<MemoItem> _openToMemoDetailPageCommand;

        /// <summary>
        /// 设置Frame命令
        /// </summary>
        private RelayCommand<Frame> _setCommand;

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
            _refreshCommand ?? (_refreshCommand = new RelayCommand(async () =>
            {
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
            _addCommand ?? (_addCommand = new RelayCommand(async () =>
            {

                _memoItemService.AddAsync(_addMemoItem); 

            }));

        /// <summary>
        /// 导航到备忘录详细页命令
        /// </summary>
        /// <param name="memoItemService"></param>
        public RelayCommand<MemoItem> OpenToMemoDetailPageCommand =>
            _openToMemoDetailPageCommand ?? (_openToMemoDetailPageCommand =
                new RelayCommand<MemoItem>(memoItem => {
                    _navigationService.NavagateToMemoDetailPage(memoItem);
                }));

        /// <summary>
        /// 设置Frame命令
        /// </summary>
        public RelayCommand<Frame> SetCommand => 
            _setCommand ?? (_setCommand = new RelayCommand<Frame>(frame =>
        {
            _navigationService.SetMemoDetailFrame(frame);
        }));


        public MemoPageViewModel(IMemoItemService memoItemService,INavigationService navigationService)
        {
            _memoItemService = memoItemService;
            _navigationService = navigationService;
            MemoItems = new ObservableCollection<MemoItem>();
            MemoItems.Clear();
            foreach (MemoItem memoItem in memoItemService.ListAsync())
            {
                MemoItems.Add(memoItem);
            }
        }
    }
}
