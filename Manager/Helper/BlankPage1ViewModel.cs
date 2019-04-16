using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace Manager.Helper
{
    public class BlankPage1ViewModel :ViewModelBase
    {
        private string _showContentRtfText;

        public string ShowContentRtfText
        {
            get => _showContentRtfText;
            set => Set(nameof(ShowContentRtfText), ref _showContentRtfText, value);
        }

        public BlankPage1ViewModel()
        {
            _showContentRtfText = "中国好";
        }
    }
}
