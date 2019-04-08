using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Manager.Models;
using Manager.Services;

namespace Manager.ViewModels
{
    /// <summary>
    /// MoneyPage的ViewModel
    /// </summary>
    public class MoneyPageViewModel : ViewModelBase
    {
        private IMoneyItemService _moneyItemService;

        /// <summary>
        /// 所有MoneyItem。
        /// </summary>
        private ObservableCollection<MoneyItem> _moneyItems;

        /// <summary>
        /// 刷新账单命令。
        /// </summary>
        private RelayCommand _refreshCommand;

        /// <summary>
        /// 增加账单条目命令
        /// </summary>
        private RelayCommand _addCommand;

        /// <summary>
        /// 要添加的账单
        /// </summary>
        private MoneyItem _addMoneyItem;

        /// <summary>
        /// 所有MoneyItem。
        /// </summary>
        public ObservableCollection<MoneyItem> MoneyItems
        {
            get => _moneyItems;
            set => Set(nameof(MoneyItems), ref _moneyItems, value);
        }

        /// <summary>
        /// 要添加的账单
        /// </summary>
        public MoneyItem AddMoneyItem
        {
            get => _addMoneyItem;
            set => Set(nameof(AddMoneyItem), ref _addMoneyItem, value);
        }

        /// <summary>
        /// 刷新账单命令。
        /// </summary>
        public RelayCommand RefreshCommand =>
            _refreshCommand ?? (_refreshCommand = new RelayCommand(async () =>
            {
                MoneyItems.Clear();
                foreach (MoneyItem moneyItem in _moneyItemService.ListAsync())
                {
                    MoneyItems.Add(moneyItem);
                }
            }));

        /// <summary>
        /// 添加账单命令。
        /// </summary>
        public RelayCommand AddCommand =>
            _addCommand ?? (_addCommand = new RelayCommand(async () =>
            {

                _moneyItemService.AddAsync(_addMoneyItem);

            }));


        public MoneyPageViewModel(IMoneyItemService moneyItemService)
        {
            MoneyItems = new ObservableCollection<MoneyItem>();
            MoneyItems.Clear();
            foreach (MoneyItem moneyItem in moneyItemService.ListAsync())
            {
                MoneyItems.Add(moneyItem);
            }
        }
    }
}
