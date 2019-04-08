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

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }
        private void SearchOpition_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.RemovedItems.Count > 0)
            {
                if (SearchOpition.SelectedItem.ToString() != SearchOpition.Items[2].ToString())
                {
                    SearchBox1.Visibility = Visibility.Collapsed;
                    SearchBox2.Visibility = Visibility.Collapsed;
                    SearchBox3.Visibility = Visibility.Visible;
                }
                else
                {
                    SearchBox1.Visibility = Visibility.Visible;
                    SearchBox2.Visibility = Visibility.Visible;
                    SearchBox3.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var money = (MoneyItem)e.ClickedItem;
            ShowDate.Date = money.ConsumeTime;
            ShowMoney.Text = money.Amount.ToString();
            ShowEvent.Text = money.Event;
        }
    }
}
