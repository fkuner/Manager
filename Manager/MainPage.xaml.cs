using Manager.Helper;
using Manager.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Manager
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {



        // MainPage.xaml.cs

        //public Microsoft.UI.Xaml.Controls.NavigationView NavigationView => nvSample;

        /*
        public MainPage()
        {
            this.InitializeComponent();
            
            PageFrame.Navigate(typeof(BlankPage1));
            
        }
        public object BlankPage1 { get; set; }

        private readonly List<(string Tag, Type Page)> _pages = new List<(string Tag, Type Page)>
        {
            ("BlankPage1", typeof(BlankPage1)),
            ("BlankPage2", typeof(BlankPage2)),
            ("BlankPage2", typeof(BlankPage3)),
        };

        private void NvSample_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                PageFrame.Navigate(typeof(BlankPage1));
            }
            else
            {
                NavigationViewItem item =
                    args.SelectedItem as NavigationViewItem;

                switch (item.Tag)
                {
                    case "BlankPage1":
                        PageFrame.Navigate(typeof(BlankPage1));
                        break;

                    case "BlankPage2":
                        PageFrame.Navigate(typeof(BlankPage2));
                        break;

                    case "BlankPage3":
                        PageFrame.Navigate(typeof(BlankPage3));
                        break;

                 
                }
            }
        }

        private void NvSample_Loaded(object sender, RoutedEventArgs e)
        {
            var goBack = new KeyboardAccelerator { Key = VirtualKey.GoBack };
            goBack.Invoked += BackInvoked;
            this.KeyboardAccelerators.Add(goBack);

            // ALT routes here
            var altLeft = new KeyboardAccelerator
            {
                Key = VirtualKey.Left,
                Modifiers = VirtualKeyModifiers.Menu
            };
            altLeft.Invoked += BackInvoked;
            this.KeyboardAccelerators.Add(altLeft);

            nvSample.IsBackEnabled = this.Frame.CanGoBack;
        }

        private void NvSample_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            On_BackRequested();
        }

        private void BackInvoked(KeyboardAccelerator sender,
                         KeyboardAcceleratorInvokedEventArgs args)
        {
            On_BackRequested();
            args.Handled = true;
        }

        private bool On_BackRequested()
        {

            if (!PageFrame.CanGoBack)
                return false;

            // Don't go back if the nav pane is overlayed.
            if (nvSample.IsPaneOpen &&
                (nvSample.DisplayMode == NavigationViewDisplayMode.Compact ||
                 nvSample.DisplayMode == NavigationViewDisplayMode.Minimal))
                return false;

            PageFrame.GoBack();
            return true;
        }

        private void On_Navigated(object sender, NavigationEventArgs e)
        {
            nvSample.IsBackEnabled = PageFrame.CanGoBack;
            if (PageFrame.SourcePageType == typeof(SettingsPage))
            {
                // SettingsItem is not part of nvSample.MenuItems, and doesn't have a Tag.
                nvSample.SelectedItem = (NavigationViewItem)nvSample.SettingsItem;
                nvSample.Header = "Settings";
            }
            else if (PageFrame.SourcePageType != null)
            {
                var item = _pages.FirstOrDefault(p => p.Page == e.SourcePageType);

                nvSample.SelectedItem = nvSample.MenuItems
                    .OfType<NavigationViewItem>()
                    .First(n => n.Tag.Equals(item.Tag));

                nvSample.Header =
                    ((NavigationViewItem)nvSample.SelectedItem)?.Content?.ToString();
            }
        }*/
        public MainPage()
        {
            this.InitializeComponent();
        }
        // Add "using" for WinUI controls.
        // using muxc = Microsoft.UI.Xaml.Controls;

        private void PageFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        // List of ValueTuple holding the Navigation Tag and the relative Navigation Page
        private readonly List<(string Tag, Type Page)> _pages = new List<(string Tag, Type Page)>
        {
            ("BlankPage1", typeof(BlankPage1)),
            ("BlankPage2", typeof(BlankPage2)),
            ("BlankPage3", typeof(BlankPage3)),
            ("Memo",typeof(Memo)),
        };

        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            // You can also add items in code.
            NavView.MenuItems.Add(new NavigationViewItemSeparator());
            
            // Add handler for PageFrame navigation.

            // NavView doesn't load any page by default, so load home page.
            NavView.SelectedItem = NavView.MenuItems[0];
            // If navigation occurs on SelectionChanged, this isn't needed.
            // Because we use ItemInvoked to navigate, we need to call Navigate
            // here to load the home page.
            NavView_Navigate("home", new EntranceNavigationTransitionInfo());

            // Add keyboard accelerators for backwards navigation.
            var goBack = new KeyboardAccelerator { Key = VirtualKey.GoBack };
            goBack.Invoked += BackInvoked;
            this.KeyboardAccelerators.Add(goBack);

            // ALT routes here
            var altLeft = new KeyboardAccelerator
            {
                Key = VirtualKey.Left,
                Modifiers = VirtualKeyModifiers.Menu
            };
            altLeft.Invoked += BackInvoked;
            this.KeyboardAccelerators.Add(altLeft);
        }

        private void NavView_ItemInvoked(NavigationView sender,
                                         NavigationViewItemInvokedEventArgs args)
        {

            if (args.IsSettingsInvoked == true)
            {
                NavView_Navigate("settings", args.RecommendedNavigationTransitionInfo);
            }
            else if (args.InvokedItemContainer != null)
            {
                var navItemTag = args.InvokedItemContainer.Tag.ToString();
                NavView_Navigate(navItemTag, args.RecommendedNavigationTransitionInfo);
            }
        }

        
        private void NavView_SelectionChanged(NavigationView sender,
                                      NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected == true)
            {
                NavView_Navigate("settings", args.RecommendedNavigationTransitionInfo);
            }
            else if (args.SelectedItemContainer != null)
            {
                var navItemTag = args.SelectedItemContainer.Tag.ToString();
                NavView_Navigate(navItemTag, args.RecommendedNavigationTransitionInfo);
            }
        }
        

        private void NavView_Navigate(string navItemTag, NavigationTransitionInfo transitionInfo)
        {
            Type _page = null;
            if (navItemTag == "settings")
            {
                _page = typeof(SettingsPage);
            }
            else
            {
                var item = _pages.FirstOrDefault(p => p.Tag.Equals(navItemTag));
                _page = item.Page;
            }
            // Get the page type before navigation so you can prevent duplicate
            // entries in the backstack.
            var preNavPageType = PageFrame.CurrentSourcePageType;

            // Only navigate if the selected page isn't currently loaded.
            if (!(_page is null) && !Type.Equals(preNavPageType, _page))
            {
                //PageFrame.Navigate(_page, null, transitionInfo);
                PageFrame.Navigate(_page, null);
            }
        }

        private void NavView_BackRequested(NavigationView sender,
                                           NavigationViewBackRequestedEventArgs args)
        {
            On_BackRequested();
        }

        private void BackInvoked(KeyboardAccelerator sender,
                                 KeyboardAcceleratorInvokedEventArgs args)
        {
            On_BackRequested();
            args.Handled = true;
        }

        private bool On_BackRequested()
        {
            if (!PageFrame.CanGoBack)
                return false;

            // Don't go back if the nav pane is overlayed.
            if (NavView.IsPaneOpen &&
                (NavView.DisplayMode == NavigationViewDisplayMode.Compact ||
                 NavView.DisplayMode == NavigationViewDisplayMode.Minimal))
                return false;

            PageFrame.GoBack();
            return true;
        }

        
        private void On_Navigated(object sender, NavigationEventArgs e)
        {

            if (PageFrame.SourcePageType == typeof(SettingsPage))
            {
                // SettingsItem is not part of NavView.MenuItems, and doesn't have a Tag.
                NavView.SelectedItem = (NavigationViewItem)NavView.SettingsItem;
                NavView.Header = "Settings";
            }
            else if (PageFrame.SourcePageType != null)
            {
                var item = _pages.FirstOrDefault(p => p.Page == e.SourcePageType);

                NavView.SelectedItem = NavView.MenuItems
                    .OfType<NavigationViewItem>()
                    .First(n => n.Tag.Equals(item.Tag));

                NavView.Header =
                    ((NavigationViewItem)NavView.SelectedItem)?.Content?.ToString();
            }
        }
        
        
    }
}
