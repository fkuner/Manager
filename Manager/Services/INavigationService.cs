using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Manager.Models;

namespace Manager.Services
{
    public interface INavigationService
    {
        void NavagateToMemoDetailPage(MemoItem memoItem);

        void SetMemoDetailFrame(Frame frame);
    }
}
