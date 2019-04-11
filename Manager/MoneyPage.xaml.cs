using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Manager.Models;
using Manager.ViewModels;
using System.Text.RegularExpressions;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Manager
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MoneyPage : Page
    {

        public MoneyPage()
        {
            this.InitializeComponent();
            DataContext = ViewModelLocator.Instance.MoneyPageViewModel;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            MoneyItem item = new MoneyItem();
            if(ShowDate.Date.DateTime!=null && ShowEvent.Text!=null && ShowMoney.Text!=null && 
                (Regex.IsMatch(ShowMoney.Text, "^([0-9]{1,}[.][0-9]*)$") || Regex.IsMatch(ShowMoney.Text, "^([0-9]{1,})$")))
            {
                item.ConsumeTime = ShowDate.Date.DateTime;
                item.Event = ShowEvent.Text;
                item.Amount = float.Parse(ShowMoney.Text);
                item.CoverImage = "Assets/image.jpg";
                var viewModel = (MoneyPageViewModel)this.DataContext;
                viewModel.AddMoneyItem = item;
                viewModel.AddCommand.Execute(null);
                viewModel.RefreshCommand.Execute(null);
                MoneyListView.SelectedIndex = viewModel.MoneyItems.Count() - 1;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (MoneyPageViewModel)this.DataContext;
            var Item = MoneyListView.SelectedItem as MoneyItem;
            viewModel.Id = Item.Id;
            MoneyItem item = new MoneyItem();
            item.Id = Item.Id;
            item.ConsumeTime = ShowDate.Date.DateTime;
            item.Event = ShowEvent.Text;
            item.Amount = float.Parse(ShowMoney.Text);
            item.CoverImage = Item.CoverImage;
            viewModel.ChangeMoneyItem = item;
            viewModel.ChangeCommand.Execute(null);
            viewModel.RefreshCommand.Execute(null);
            int index = 0;
            foreach(MoneyItem moneyItem in viewModel.MoneyItems)
            {
                if(moneyItem.Id == Item.Id)
                {
                    MoneyListView.SelectedIndex = index;
                    break;
                }
                index++;
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (MoneyPageViewModel)this.DataContext;
            var Item = MoneyListView.SelectedItem as MoneyItem;
            if (Item != null)
            {
                viewModel.DeleteMoneyItem = Item;
                viewModel.DeleteCommand.Execute(null);
                viewModel.RefreshCommand.Execute(null);
            }
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var money = (MoneyItem)e.ClickedItem;
            ShowDate.Date = money.ConsumeTime;
            ShowMoney.Text = money.Amount.ToString();
            ShowEvent.Text = money.Event;
        }

        private void Result_Click(object sender, RoutedEventArgs e)
        {
            DateTime time = ChooseDate.Date.DateTime;
            var viewModel = (MoneyPageViewModel)this.DataContext;
            viewModel.Date = time;
            viewModel.SearchCommand.Execute(null);
        }

        private void Sure_Click(object sender, RoutedEventArgs e)
        {
            //这里是设置最大值和提醒差额并存入文件
            var viewModel = (MoneyPageViewModel)this.DataContext;
            if(MaxConsume.Text!=null && Difference.Text!=null &&
                ((Regex.IsMatch(MaxConsume.Text, "^([0-9]{1,}[.][0-9]*)$") || Regex.IsMatch(MaxConsume.Text, "^([0-9]{1,})$"))) &&
                (Regex.IsMatch(Difference.Text, "^([0-9]{1,}[.][0-9]*)$") || Regex.IsMatch(Difference.Text, "^([0-9]{1,})$")))
            {
                viewModel.MaxConsume = double.Parse(MaxConsume.Text);
                viewModel.Difference = double.Parse(Difference.Text);
                viewModel.SaveCommand.Execute(null);
            }
            viewModel.RefreshCommand.Execute(null);
            MaxConsume.Text = "";
            Difference.Text = "";
        }
    }
}
