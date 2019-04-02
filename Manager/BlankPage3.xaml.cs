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
            this.ViewModel = new RecordingViewModel();
            ObservableCollection<string> listItems = new ObservableCollection<string>();
            listItems.Add("Item1");
            listItems.Add("Item2");
            listItems.Add("Item3");
            listItems.Add("Item4");
            listItems.Add("Item5");
            EventListView.ItemsSource = listItems;
        }
        public RecordingViewModel ViewModel
        {
            get;
            set;
        }
    }

    public class Recording
    {
        public string ArtisName { get; set; }
        public string CompositionName { get; set; }
        public DateTime ReleaseDateTime { get; set; }

        public Recording()
        {
            this.ArtisName = "Wolfgang";
            this.CompositionName = "Andante in C for Piano";
            this.ReleaseDateTime = new DateTime(1761, 1, 1);
        }

        public string OnlineSummary
        {
            get
            {
                return $"{this.CompositionName} by {this.ArtisName},released:"
                    + this.ReleaseDateTime.ToString("d");
            }
        }
    }
    
    public class RecordingViewModel
    {
        private Recording defaultRecording = new Recording();
        public Recording DefaultRecording
        {
            get
            {
                return this.defaultRecording;
            }
        }
    }
}
