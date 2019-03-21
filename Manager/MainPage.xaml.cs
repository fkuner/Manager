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
        public MainPage()
        {
            this.InitializeComponent();
            PageFrame.Navigate(typeof(BlankPage1));
        }
        public object BlankPage1 { get; set; }

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
                        PageFrame.Navigate(typeof(BlankPage1));
                        break;

                 
                }
            }
        }
    }
}
