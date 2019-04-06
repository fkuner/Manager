using GalaSoft.MvvmLight;
using Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Globalization.DateTimeFormatting;

namespace Manager.ViewModels
{
    public class MemoItemViewModel
    {
        private int _itemId;

        public int ItemId
        {
            get
            {
                return _itemId;
            }
        }

        public string DateCreatedHourMinute
        {
            get
            {
                var formatter = new DateTimeFormatter("hour minute");
                return formatter.Format(DateCreated);
            }
        }

        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }

        public MemoItemViewModel()
        {
        }

        public static MemoItemViewModel FromItem(Item item)
        {
            var viewModel = new MemoItemViewModel();

            viewModel._itemId = item.Id;
            viewModel.DateCreated = item.DateCreated;
            viewModel.Title = item.Title;
            viewModel.Text = item.Text;

            return viewModel;
        }
    }
}
