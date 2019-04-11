using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Manager.Models;

namespace Manager.ViewModels
{
    public class MemoDetailPageViewModel :ViewModelBase
    {
        /// <summary>
        /// 传过来的memoItem
        /// </summary>
        private MemoItem _memoItem;

        public MemoItem MemoItem
        {
            get => _memoItem;
            set => Set(nameof(MemoItem), ref _memoItem, value);
        }
    }
}
