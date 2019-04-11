using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Manager.Models;
using Manager.Pages;

namespace Manager.Services
{
    public class NavigationService : INavigationService
    {


        private Frame _memoDetailFrame;

        public void SetMemoDetailFrame(Frame frame)
        {
            this._memoDetailFrame = frame;
        }
        
        /// <summary>
        /// 导航到MemoDetailPage
        /// </summary>
        /// <param name="memoItem"></param>
        public void NavagateToMemoDetailPage(MemoItem memoItem)
        {
            //throw new NotImplementedException();
            _memoDetailFrame.Navigate(typeof(MemoDetailPage), memoItem);
        }
    }
}
