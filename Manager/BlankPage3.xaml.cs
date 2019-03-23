﻿using System;
using System.Collections.Generic;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Manager
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage3 : Page
    {
        public BlankPage3()
        {
            this.InitializeComponent();
            MyFrame.Navigate(typeof(Calendar));
        }

        private void Record_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(Record));
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(Search));
        }

        private void Remind_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(Remind));
        }

        private void Event_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(Calendar));
        }
    }
}
