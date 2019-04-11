using Manager.Models;
using Manager.Pages;
using Manager.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
using GalaSoft.MvvmLight.Views;
using Manager.Services;
using MemoDetailPage = Manager.Pages.MemoDetailPage;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Manager
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MemoPage : Page
    {
        
        private MemoItem _lastSelectedItem;

        public MemoPage()
        {
            this.InitializeComponent();
            DataContext = ViewModelLocator.Instance.MemoPageViewModel;
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            UpdateForVisualState(AdaptiveStates.CurrentState);
        }

        private void AdaptiveStates_CurrentStateChanged(object sender, VisualStateChangedEventArgs e)
        {
            UpdateForVisualState(e.NewState, e.OldState);
        }

        private void UpdateForVisualState(VisualState newState, VisualState oldState = null)
        {
            var isNarrow = newState == NarrowState;

            if (isNarrow && oldState == DefaultState && _lastSelectedItem != null)
            {
                // Resize down to the detail item. Don't play a transition.
                DetailFrame.Navigate(typeof(MemoDetailPage), _lastSelectedItem.Id, new SuppressNavigationTransitionInfo());
            }
               
            EntranceNavigationTransitionInfo.SetIsTargetElement(MasterListView, isNarrow);
        }

        private void MasterListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var clickedItem = (MemoItem)e.ClickedItem;
            _lastSelectedItem = clickedItem;
            var viewModel = (MemoPageViewModel)this.DataContext;
            if (AdaptiveStates.CurrentState == NarrowState)
            {
                //Frame.Navigate(typeof(MemoDetailPage), e.ClickedItem as MemoItem, new DrillInNavigationTransitionInfo());
                viewModel.SetCommand.Execute(Frame);
                viewModel.OpenToMemoDetailPageCommand.Execute(e.ClickedItem as MemoItem);
            }
            else
            {
                //DetailFrame.Navigate(typeof(MemoDetailPage), e.ClickedItem as MemoItem, new DrillInNavigationTransitionInfo());
                viewModel.SetCommand.Execute(DetailFrame);
                viewModel.OpenToMemoDetailPageCommand.Execute(e.ClickedItem as MemoItem);
                
            }
            
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            // Assure we are displaying the correct item. This is necessary in certain adaptive cases.
            MasterListView.SelectedItem = _lastSelectedItem;
        }

        
    }
}
