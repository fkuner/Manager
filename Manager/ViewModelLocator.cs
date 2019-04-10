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
        public TodoPageViewModel TodoPageViewModel => SimpleIoc.Default.GetInstance<TodoPageViewModel>();
        public MoneyPageViewModel MoneyPageViewModel => SimpleIoc.Default.GetInstance<MoneyPageViewModel>();
        public ToolsPageViewModel ToolsPageViewModel => SimpleIoc.Default.GetInstance<ToolsPageViewModel>();

        public MemoDetailPageViewModel MemoDetailPageViewModel =>
            SimpleIoc.Default.GetInstance<MemoDetailPageViewModel>();

        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<MemoPageViewModel>();
            SimpleIoc.Default.Register<ToolsPageViewModel>();
            SimpleIoc.Default.Register<TodoPageViewModel>();
            SimpleIoc.Default.Register<MoneyPageViewModel>();
            SimpleIoc.Default.Register<MemoDetailPageViewModel>();
            SimpleIoc.Default.Register<INavigationService,NavigationService>();
            SimpleIoc.Default.Register<IMemoItemService,MemoItemService>();
            SimpleIoc.Default.Register<IToolItemService,ToolItemService>();
            SimpleIoc.Default.Register<ITodoItemService,TodoItemService>();
            SimpleIoc.Default.Register<IMoneyItemService,MoneyItemService>();
        }//定义私有变量，cs中不能New
    }
}
