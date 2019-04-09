﻿using Manager.Models;
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
            
        }

        
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                AppViewBackButtonVisibility.Collapsed;

            var viewModel = (ToolsPageViewModel)this.DataContext;

            if (viewModel.ToolItems.Count == 0)
            {
                ToolItem toolItem = new ToolItem();
                toolItem.ID = 0;
                toolItem.Content = "请输入你要添加的内容";
                viewModel.AddToolItem = toolItem;
                viewModel.AddCommand.Execute(null);
            }
            //ToolListView.SelectedItem = viewModel.ToolItems[0];

            base.OnNavigatedTo(e);
        }

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
            
            // Getting the currently selected ListBoxItem
            // Note that the ListBox must have
            // IsSynchronizedWithCurrentItem set to True for this to work
            /*ListBoxItem myListBoxItem =
                (ListBoxItem)(ToolListView.ItemContainerGenerator.ContainerFromItem(ToolListView.Items.CurrentItem));

            // Getting the ContentPresenter of myListBoxItem
            ContentPresenter myContentPresenter = FindVisualChild<ContentPresenter>(myListBoxItem);

            // Finding textBlock from the DataTemplate that is set on that ContentPresenter
            DataTemplate myDataTemplate = myContentPresenter.ContentTemplate;
            TextBlock myTextBlock = (TextBlock)myDataTemplate.FindName("textBlock", myContentPresenter);
             
            // Do something to the DataTemplate-generated TextBlock
            MessageBox.Show("The text of the TextBlock of the selected list item: "
                            + myTextBlock.Text);*/
            Item.Content = "haha";
            viewModel.AddToolItem = Item;
            viewModel.AddCommand.Execute(null);
        }
        private childItem FindVisualChild<childItem>(DependencyObject obj)
            where childItem : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is childItem)
                    return (childItem)child;
                else
                {
                    childItem childOfChild = FindVisualChild<childItem>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }
    }
}
