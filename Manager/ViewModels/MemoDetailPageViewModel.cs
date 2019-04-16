using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Manager.Models;

namespace Manager.ViewModels
{
    public class MemoDetailPageViewModel :ViewModelBase
    {

        #region 属性
        /// <summary>
        /// 传过来的memoItem
        /// </summary>
        private MemoItem _memoItem;

        /// <summary>
        /// 传过来的memoItem
        /// </summary>
        public MemoItem MemoItem
        {
            get => _memoItem;
            set => Set(nameof(MemoItem), ref _memoItem, value);
        }

        #endregion

        #region 命令
        /// <summary>
        /// 发送命令
        /// </summary>
        private RelayCommand _sendCommand;

        /// <summary>
        /// 发送命令
        /// </summary>
        public RelayCommand SendCommand =>
            _sendCommand ?? (_sendCommand = new RelayCommand( () =>
            {
                ExcuteSendCommand();
            }));

        /// <summary>
        /// 执行发送命令
        /// </summary>
        private void ExcuteSendCommand()
        {
            Messenger.Default.Send<MemoItem>(MemoItem, "Message");
        }

        #endregion

        
    }
}
