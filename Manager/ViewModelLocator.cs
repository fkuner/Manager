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
        public MemoPageViewModel MemoPageViewModel => SimpleIoc.Default.GetInstance<MemoPageViewModel>();
        public ToolsPageViewModel ToolsPageViewModel => SimpleIoc.Default.GetInstance<ToolsPageViewModel>();
        public BlankPage2ViewModel BlankPage2ViewModel => SimpleIoc.Default.GetInstance<BlankPage2ViewModel>();

        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<MemoPageViewModel>();
            SimpleIoc.Default.Register<ToolsPageViewModel>();
            SimpleIoc.Default.Register<BlankPage2ViewModel>();
            SimpleIoc.Default.Register<IMemoItemService,MemoItemService>();
            SimpleIoc.Default.Register<IToolItemService,ToolItemService>();
            SimpleIoc.Default.Register<ITodoItemService,TodoItemService>();
        }//定义私有变量，cs中不能New
    }
}
