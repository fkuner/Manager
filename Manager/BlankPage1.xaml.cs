using Manager.Pages;
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
    public sealed partial class BlankPage1 : Page, INotifyPropertyChanged
    {

        public BlankPage1()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        private string memoItem;

        public ObservableCollection<string> memoItems { get; } = new ObservableCollection<string>();

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                AppViewBackButtonVisibility.Collapsed;

            if (memoItems.Count == 0)
            {
                await GetItemsAsync();
            }

            base.OnNavigatedTo(e);
        }

        private async Task GetItemsAsync()
        {
            // https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.image#Windows_UI_Xaml_Controls_Image_Source
            // See "Using a stream source to show images from the Pictures library".
            // This code is modified to get images from the app folder.

            // Get the app folder where the images are stored.
            //StorageFolder appInstalledFolder = Package.Current.InstalledLocation;
            //StorageFolder assets = await appInstalledFolder.GetFolderAsync("Assets\\Samples");

            // Get and process files in folder
            //IReadOnlyList<StorageFile> fileList = await assets.GetFilesAsync();
            
            for(int i=0;i<5;i++)
            {
                memoItem = "1";
                memoItems.Add(memoItem);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void MemoListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Prepare the connected animation for navigation to the detail page.
            memoItem = e.ClickedItem as string;
            MemoListView.PrepareConnectedAnimation("itemAnimation", e.ClickedItem, "memoItem");

            this.Frame.Navigate(typeof(MemoDetail), e.ClickedItem);
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
        */

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
    }
}
