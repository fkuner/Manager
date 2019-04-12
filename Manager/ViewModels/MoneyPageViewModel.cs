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
        public const string PropertyName = "ThisMonthMoney";

        //下面是定义的私有变量
        /// <summary>
        /// 所有MoneyItem。
        /// </summary>
        private ObservableCollection<MoneyItem> _moneyItems;

        /// <summary>
        /// 查询月消费额
        /// </summary>
        private string _monthmoney;

        /// <summary>
        /// 当前月消费额
        /// </summary>
        private string _thismonthmoney;

        /// <summary>
        /// 想要修改的id值
        /// </summary>
        private int _id;

        /// <summary>
        /// 按月选择的时间,用来查找你选择月份的当月消费额的
        /// </summary>
        private DateTime _date;

        /// <summary>
        /// 这里表示设定的月最高消费
        /// </summary>
        public static double _maxConsume;

        /// <summary>
        /// 这里表示差值
        /// </summary>
        public static double _difference;

        /// <summary>
        /// 这里表示显示的最大消费额等
        /// </summary>
        private string _showmessage;



        //下面是一系列的命令
        /// <summary>
        /// 刷新账单命令。
        /// </summary>
        private RelayCommand _refreshCommand;

        /// <summary>
        /// 增加账单条目命令
        /// </summary>
        private RelayCommand _addCommand;

        /// <summary>
        /// 删除账单条目命令
        /// </summary>
        private RelayCommand _deleteCommand;

        /// <summary>
        /// 修改账单条目命令
        /// </summary>
        private RelayCommand _changeCommand;

        /// <summary>
        ///根据时间查找的函数 
        /// </summary>
        private RelayCommand _searchCommand;

        /// <summary>
        /// 保存设置的命令
        /// </summary>
        private RelayCommand _saveSettingsCommand;

        /// <summary>
        /// 读取设置的命令
        /// </summary>
        private RelayCommand _readSettingsCommand;



        /// <summary>
        /// 要添加的账单
        /// </summary>
        private MoneyItem _addMoneyItem;

        /// <summary>
        /// 要删除的账单
        /// </summary>
        private MoneyItem _deleteMoneyItem;

        /// <summary>
        /// 要修改的账单
        /// </summary>
        private MoneyItem _changeMoneyItem;



        //下面是实现的set和get的方法
        /// <summary>
        /// 所有MoneyItem。
        /// </summary>
        public ObservableCollection<MoneyItem> MoneyItems
        {
            get => _moneyItems;
            set => Set(nameof(MoneyItems), ref _moneyItems, value);
        }

        /// <summary>
        /// ID值
        /// </summary>
        public int Id
        {
            get => _id;
            set => Set(nameof(Id), ref _id, value);
        }
        /// <summary>
        /// Date值,用来根据Date查找的
        /// </summary>
        public DateTime Date
        {
            get => _date;
            set => Set(nameof(Date), ref _date, value);
        }

        /// <summary>
        /// 查找月的值
        /// </summary>
        public string MonthMoney
        {
            get => _monthmoney;
            set => Set(nameof(MonthMoney), ref _monthmoney, value);
        }

        /// <summary>
        /// 当前月的值
        /// </summary>
        public string ThisMonthMoney
        {
            get
            {
                return _thismonthmoney;
            }

            set
            {
                string oldValue = _thismonthmoney;
                _thismonthmoney = value;
                RaisePropertyChanged(() => ThisMonthMoney, oldValue, value, true);
            }
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
        /// 要删除的账单
        /// </summary>
        public MoneyItem DeleteMoneyItem
        {
            get => _deleteMoneyItem;
            set => Set(nameof(DeleteMoneyItem), ref _deleteMoneyItem, value);
        }

        /// <summary>
        /// 要修改的账单
        /// </summary>
        public MoneyItem ChangeMoneyItem
        {
            get => _changeMoneyItem;
            set => Set(nameof(ChangeMoneyItem), ref _changeMoneyItem, value);
        }

        /// <summary>
        /// 设置的MaxConsume
        /// </summary>
        public double MaxConsume
        {
            get => _maxConsume;
            set => Set(nameof(MaxConsume), ref _maxConsume, value);
        }

        /// <summary>
        /// 设置的Difference
        /// </summary>
        public double Difference
        {
            get => _difference;
            set => Set(nameof(Difference), ref _difference, value);
        }

        /// <summary>
        /// 显示信息
        /// </summary>
        public string ShowMessage
        {
            get => _showmessage;
            set => Set(nameof(ShowMessage), ref _showmessage, value);
        }



        //下面是具体的实现
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
                List<double> List = _moneyItemService.ReadAsync();
                if (List.Count() > 0)
                {
                    ShowMessage = "当前设置最大值:" + List[0].ToString() + "\n当前设置差值:" + List[1].ToString();
                }
                ThisMonthMoney = "当月消费额:" + _moneyItemService.SearchAsync(DateTime.Now).ToString();
            }));

        /// <summary>
        /// 添加账单命令。
        /// </summary>
        public RelayCommand AddCommand =>
            _addCommand ?? (_addCommand = new RelayCommand(async () =>
            {

                _moneyItemService.AddAsync(_addMoneyItem);

            }));

        /// <summary>
        /// 修改账单的命令
        /// </summary>
        public RelayCommand ChangeCommand =>
            _changeCommand ?? (_changeCommand = new RelayCommand(async () =>
            {

                _moneyItemService.ChangeAsync(_id, _changeMoneyItem);

            }));

        /// <summary>
        /// 删除账单的命令
        /// </summary>
        public RelayCommand DeleteCommand =>
            _deleteCommand ?? (_deleteCommand = new RelayCommand(async () =>
            {
                _moneyItemService.DeleteAsync(_deleteMoneyItem);
            }));

        /// <summary>
        /// 查询账单的命令
        /// </summary>
        /// <param name="moneyItemService"></param>
        public RelayCommand SearchCommand =>
            _searchCommand ?? (_searchCommand = new RelayCommand(async () =>
            {
                MonthMoney ="当月消费额为:"+ _moneyItemService.SearchAsync(_date).ToString();
            }));


        /// <summary>
        /// 保存设定值的命令
        /// </summary>
        public RelayCommand SaveCommand =>
            _saveSettingsCommand ?? (_saveSettingsCommand = new RelayCommand(async () =>
             {
                 _moneyItemService.ClearAsync();
                 _moneyItemService.SaveAsync(_maxConsume);
                 _moneyItemService.SaveAsync(_difference);
             }));

        /// <summary>
        /// 读取设定值的命令
        /// </summary>
        public RelayCommand ReadCommand =>
            _readSettingsCommand ?? (_readSettingsCommand = new RelayCommand(async () =>
             {            
                 List<double> List = _moneyItemService.ReadAsync();
                 if (List.Count() > 0)
                 {
                     MaxConsume = List[0];
                     Difference = List[1];
                 }
             }));


        /// <summary>
        /// 这是初始化的命令吧
        /// </summary>
        /// <param name="moneyItemService"></param>
        public MoneyPageViewModel(IMoneyItemService moneyItemService)
        {
            _moneyItemService = new MoneyItemService();
            MoneyItems = new ObservableCollection<MoneyItem>();
            MoneyItems.Clear();
            foreach (MoneyItem moneyItem in moneyItemService.ListAsync())
            {
                MoneyItems.Add(moneyItem);
            }
            List<double> List = moneyItemService.ReadAsync();
            if (List.Count() > 0)
            {
                ShowMessage = "当前设置最大值:" + List[0].ToString() + "\n当前设置差值:" + List[1].ToString();
            }
            ThisMonthMoney = "当月消费额:"+moneyItemService.SearchAsync(DateTime.Now).ToString();
        }
    }
}
