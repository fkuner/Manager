using GalaSoft.MvvmLight.Ioc;
using Manager.Services;
using Manager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class ViewModelLocator
    {
        public static readonly ViewModelLocator Instance = new ViewModelLocator(); //单件模式
        public BlankPage1ViewModel BlankPage1ViewModel => SimpleIoc.Default.GetInstance<BlankPage1ViewModel>();
        public BlankPage2ViewModel BlankPage2ViewModel => SimpleIoc.Default.GetInstance<BlankPage2ViewModel>();

        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<BlankPage1ViewModel>();
            SimpleIoc.Default.Register<BlankPage2ViewModel>();
            SimpleIoc.Default.Register<IMemoItemService, MemoItemService>();
            SimpleIoc.Default.Register<ITodoItemService,TodoItemService>();
        }//定义私有变量，cs中不能New
    }
}
