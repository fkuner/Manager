using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Storage.Streams;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Manager.Helper
{
    public static class RtfStringSetter
    {
        public static string GetRtfString(RichEditBox edit)
        {
            string s;
            edit.Document.GetText(Windows.UI.Text.TextGetOptions.FormatRtf,out s);
            return s;
        }

        public static void SetRtfString(RichEditBox edit, string rtfText)
        {
            edit.Document.SetText(Windows.UI.Text.TextSetOptions.FormatRtf, rtfText);
        }

        public static readonly DependencyProperty RtfStringProperty = 
            DependencyProperty.RegisterAttached(
                "RtfString",
                typeof(string),
                typeof(RtfStringSetter),
                new PropertyMetadata(null,SourceChanged));

        private static void SourceChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            Debug.WriteLine("SourceChanged被调用");
            RichEditBox editBox=o as RichEditBox;
            if(editBox==null)
                return;
            SetRtfToRichEditBox(editBox, (string) o.GetValue(RtfStringProperty));

        }

        public static async Task<IRandomAccessStream> BytesToStream(byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);
            var raStream = new InMemoryRandomAccessStream();
            var outputStream = raStream.GetOutputStreamAt(0);
            await RandomAccessStream.CopyAsync(stream.AsInputStream(), outputStream);
            return raStream;
        }

        public static async Task SetRtfToRichEditBox(RichEditBox box, string rtf)
        {
            //从string 字符串richText获取Byte数组
            Byte[] bs = System.Text.Encoding.UTF8.GetBytes(rtf);

            //从字节数组创建IRandomAccessStream
            IRandomAccessStream ras = await BytesToStream(bs);

            
            box.Document.LoadFromStream(
                TextSetOptions.FormatRtf, //表示按照rtf格式读取
                ras); //刚刚创建的IRandomAccessStream
        }

    }
}
