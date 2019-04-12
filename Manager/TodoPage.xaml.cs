﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Contacts;
using Windows.ApplicationModel.Email;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel.Contacts;
using Windows.ApplicationModel.Email;
using System.Threading.Tasks;
using Manager.Services;
using Manager.Models;
using Manager.ViewModels;
using Manager.Services;
using Windows.ApplicationModel.DataTransfer;
using System.Collections.ObjectModel;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Manager
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TodoPage : Page
    {

        //private List<TodoItem> todoItems;
        private List<string> Items;
        public TodoPage()
        {
            this.InitializeComponent();
            DataTransferManager.GetForCurrentView().DataRequested += ShareRequested;
            DataContext = ViewModelLocator.Instance.TodoPageViewModel;
        }

        /// <summary>
        /// 发送邮件响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void MainButton_Click(object sender, RoutedEventArgs e)
        {
            String subject = "test";
            String messageBody = "test";
            //Windows.ApplicationModel.Contacts.Contact 
            
            Contact contact = new Contact()
            {
                Emails =
                {
                    new ContactEmail()
                    {
                        Address = "784819644@qq.com",
                        Description = "UWP 开发者",
                    }
                }
            };
            await ComposeEmail(contact, subject, messageBody);
            

            //如果要挑选人脉中的联系人
            /*
            ContactPicker contactPicker = new ContactPicker();

            contactPicker.SelectionMode = ContactSelectionMode.Fields;

            contactPicker.DesiredFieldsWithContactFieldType.Add(ContactFieldType.Email);
            contactPicker.DesiredFieldsWithContactFieldType.Add(ContactFieldType.Address);
            contactPicker.DesiredFieldsWithContactFieldType.Add(ContactFieldType.PhoneNumber);

            //Select one or more contacts
            IList<Contact> contacts = await contactPicker.PickContactsAsync();

            if (contacts != null &&
                contacts.Count > 0)
            {
                foreach (Contact contact in contacts)
                {
                    await ComposeEmail(contact, subject, messageBody);
                }
            }
            */
        }

        /// <summary>
        /// 发送邮件函数
        /// </summary>
        /// <param name="recipient"></param>
        /// <param name="subject"></param>
        /// <param name="messageBody"></param>
        /// <returns></returns>
        private async Task ComposeEmail(Windows.ApplicationModel.Contacts.Contact recipient,
        string subject, string messageBody)
        {
            var emailMessage = new Windows.ApplicationModel.Email.EmailMessage();
            emailMessage.Body = messageBody;

            var email = recipient.Emails.FirstOrDefault<Windows.ApplicationModel.Contacts.ContactEmail>();
            if (email != null)
            {
                var emailRecipient = new Windows.ApplicationModel.Email.EmailRecipient(email.Address);
                emailMessage.To.Add(emailRecipient);
                emailMessage.Subject = subject;
            }

            await Windows.ApplicationModel.Email.EmailManager.ShowComposeNewEmailAsync(emailMessage);
        }


        private async void  Add_Click(object sender, RoutedEventArgs e)
        {


            //testTextBlock.Text = textbox.Text;

            TodoItem todoItem = new TodoItem();
            todoItem.Content = "添加任务";
            
            var viewModel = (TodoPageViewModel)this.DataContext;
            viewModel.TodoItems.Add(todoItem);
            

           
        }
        private void Reshare_Click(object sender, RoutedEventArgs e)
        {
            DataTransferManager.ShowShareUI();
        }

        private void ShareRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            var deferral = args.Request.GetDeferral();
            DataRequest request = args.Request;
            request.Data.Properties.Title = "ShareUISample";
            request.Data.SetText("Description：" + "This is a line from ShareUISample. Welcome to learn UWP.");
            //flash.jpg是示例代码中Asssets文件夹中的图片，可以将其改为你自己的图片
            request.Data.SetBitmap(RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/UWP-ji-0.jpg")));
            deferral.Complete();
        }

        private void CheckBox_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }
        private void Delete_click(object sender, RoutedEventArgs e)
        {
            var viewModel = (TodoPageViewModel)this.DataContext;
            var Item = TodoListView.SelectedItem as TodoItem;
            viewModel.DeleteTodoItem = Item;
            viewModel.DeleteCommand.Execute(null);
        }
        /// <summary>
        /// Share
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// 
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (TodoPageViewModel)this.DataContext;
            var Item = TodoListView.SelectedItem as TodoItem;

        // Getting the currently selected ListBoxItem
        // Note that the ListBox must have
        // IsSynchronizedWithCurrentItem set to True for this to work
        /*ListBoxItem myListBoxItem =
            (ListBoxItem)(ToolListView.ItemContainerGenerator.ContainerFromItem(ToolListView.Items.CurrentItem));

        // Getting the ContentPresenter of myListBoxItem
        ContentPresenter myContentPresenter = FindVisualChild<ContentPresenter>(myListBoxItem);

        // Finding textBlock from the DataTemplate that is set on that ContentPresenter
        DataTemplate myDataTemplate = myContentPresenter.ContentTemplate;
        TextBlock myTextBlock = (TextBlock)myDataTemplate.FindName("textBlock", myContentPresenter);

        // Do something to the DataTemplate-generated TextBlock
        MessageBox.Show("The text of the TextBlock of the selected list item: "
                        + myTextBlock.Text);*/
             Item.Content = "haha";
            viewModel.AddTodoItem = Item;
            viewModel.AddCommand.Execute(null);
        }
    
        /// <summary>
        /// 通知栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clock_OnClick(object sender, RoutedEventArgs e)
        {
            var type = ToastTemplateType.ToastText02;
            var content = ToastNotificationManager.GetTemplateContent(type);
            //生成XML
            XmlNodeList toastxml = content.GetElementsByTagName("text");
            toastxml[0].AppendChild(content.CreateTextNode("标题"));
            toastxml[1].AppendChild(content.CreateTextNode("内容"));
            //设置时间、次数等参数
            //DateTime due = DateTime.Parse("2019-04-08 21:21:00");
            DateTime due = DateTime.Now.AddMinutes(1);
            TimeSpan span = TimeSpan.FromMinutes(1);
            UInt32 time = 3;
            ScheduledToastNotification toast = new ScheduledToastNotification(content, due, span, time);
            //设置Toast的id
            toast.Id = "toast1";
            //if (state == 0)
            //{
            //    var node = content.SelectSingleNode("/toast");
            //    var audio = content.CreateElement("audio");
            //    audio.SetAttribute("silent", "true");
            //    node.AppendChild(audio);
            //}
            //else
            //{
            var node = content.SelectSingleNode("/toast");
            var audio = content.CreateElement("audio");
            audio.SetAttribute("src", "ms-winsoundevent:Notification.IM");
            audio.SetAttribute("loop", "false");
            node.AppendChild(audio);
            ToastNotificationManager.CreateToastNotifier().AddToSchedule(toast);

        }

       
    }
}
