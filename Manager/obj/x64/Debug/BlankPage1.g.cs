<<<<<<< HEAD
<<<<<<< HEAD
﻿#pragma checksum "F:\Manager\Manager\BlankPage1.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6116ECF0BE02AE8A52FAD208C41178CF"
=======
﻿#pragma checksum "C:\Users\Lenovo\source\repos\Manager\Manager\BlankPage1.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "746B5060D8F5D162DD315A7445E3AD40"
>>>>>>> parent of 908a51a... 客户端架构模式终极版
=======
﻿#pragma checksum "C:\Users\Lenovo\source\repos\Manager\Manager\BlankPage1.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "746B5060D8F5D162DD315A7445E3AD40"
>>>>>>> parent of 908a51a... 客户端架构模式终极版
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Manager
{
    partial class BlankPage1 : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 3: // BlankPage1.xaml line 44
                {
                    this.TitleTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4: // BlankPage1.xaml line 53
                {
                    this.Page1CommandBar = (global::Windows.UI.Xaml.Controls.CommandBar)(target);
                }
                break;
            case 5: // BlankPage1.xaml line 68
                {
                    this.MemoListView = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.MemoListView).ItemClick += this.MemoListView_ItemClick;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

