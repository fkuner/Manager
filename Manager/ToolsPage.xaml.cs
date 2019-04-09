using Manager.Models;
using Manager.Pages;
using Manager.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Manager
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ToolsPage : Page
    {

        //public event PropertyChangedEventHandler PropertyChanged;

        public ToolsPage()
        {
            this.InitializeComponent();
            DataContext = ViewModelLocator.Instance.ToolsPageViewModel;
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            var viewModel = (ToolsPageViewModel)this.DataContext;
            ToolListView.SelectedItem = viewModel.ToolItems[0];
        }

        /*
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                AppViewBackButtonVisibility.Collapsed;

            if (memoItems.Count == 0)
            {
                GetItemsAsync();
            }

            base.OnNavigatedTo(e);
        }
        */

        
        
        private void ToolListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Prepare the connected animation for navigation to the detail page.
            //toolItem = e.ClickedItem as string;
            //ToolListView.PrepareConnectedAnimation("itemAnimation", e.ClickedItem, "toolItem");

            this.Frame.Navigate(typeof(ToolsDetailPage), e.ClickedItem);
        }
        
        // Called by the Loaded event of the ImageGridView.
        /*
        private async Task MemoListView_LoadedAsync(object sender, RoutedEventArgs e)
        {
            // Run the connected animation for navigation back to the main page from the detail page.
            if (memoItem != null)
            {
                MemoListView.ScrollIntoView(memoItem);
                ConnectedAnimation animation = ConnectedAnimationService.GetForCurrentView().GetAnimation("backAnimation");
                if (animation != null)
                {
                    await MemoListView.TryStartConnectedAnimationAsync(animation, memoItem, "memoItem");
                }
            }
        }
        
        private async void StartConnectedAnimationForBackNavigation()
        {
            // Run the connected animation for navigation back to the main page from the detail page.
            if (memoItem != null)
            {
                MemoListView.ScrollIntoView(memoItem);
                ConnectedAnimation animation = ConnectedAnimationService.GetForCurrentView().GetAnimation("backAnimation");
                if (animation != null)
                {
                    await MemoListView.TryStartConnectedAnimationAsync(animation, memoItem, "memoItem");
                }
            }
        }
        */
        private void Add_OnClick(object sender, RoutedEventArgs e)
        {
            ToolItem toolItem = new ToolItem();
            toolItem.ID = 200;
            toolItem.Content = "请输入你要添加的内容";
            var viewModel = (ToolsPageViewModel)this.DataContext;
            viewModel.ToolItems.Add(toolItem);
        }

        private void Delete_OnClick(object sender, RoutedEventArgs e)
        {
            var viewModel = (ToolsPageViewModel)this.DataContext;
            var Item = ToolListView.SelectedItem as ToolItem;
            viewModel.DeleteToolItem = Item;
            viewModel.DeleteCommand.Execute(null);
        }

        private void Save_OnClick(object sender, RoutedEventArgs e)
        {
            var viewModel = (ToolsPageViewModel)this.DataContext;
            var Item = ToolListView.SelectedItem as ToolItem;
            Item.ID = ToolListView.SelectedIndex+10;
            Item.Content = "haha";
            viewModel.AddToolItem = Item;
            viewModel.AddCommand.Execute(null);
        }
    }
}
