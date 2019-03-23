using System;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Manager
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage2 : Page
    {
        public BlankPage2()
        {
            this.InitializeComponent();
        }

        /*
        private async void SendMail(Contact recipient, StorageFile attchmentFile)
        {
            // Windows.ApplicationModel.Email
            EmailMessage message = new EmailMessage();
            // Mail subject
            message.Subject = "This is a test mail.";

            message.Body = "This is a test mail, please ignore.";

            if (attchmentFile != null)
            {
                RandomAccessStreamReference stream =
                    RandomAccessStreamReference.CreateFromFile(attchmentFile);

                EmailAttachment attachment = new EmailAttachment(attchmentFile.Name, stream);

                // Set mail's attachment
                message.Attachments.Add(attachment);
            }

            ContactEmail email = recipient.Emails.FirstOrDefault();

            if (email != null)
            {
                EmailRecipient emailRecipient = new EmailRecipient(email.Address);

                message.To.Add(emailRecipient);
            }

            await EmailManager.ShowComposeNewEmailAsync(message);
        }
        private async System.Threading.Tasks.Task MainButton_ClickAsync(object sender, RoutedEventArgs e)
        {
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
                for (int i = 0; i < contacts.Count; i++)
                {
                    // TODO:    
                }
            }

            //// Select only one contact
            Contact contact = await contactPicker.PickContactAsync();

            if (contact != null)
            {
                  //TODO:...
            }

            SendMail(contact,null);
        }  
        */
        
        private async void MainButton_Click(object sender, RoutedEventArgs e)
        {
            String subject = "test";
            String messageBody = "test";
            //Windows.ApplicationModel.Contacts.Contact 
            /*
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
            */

            //如果要挑选人脉中的联系人
           
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
            
            
        }

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
    }
}
