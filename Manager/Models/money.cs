using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Models
{
    public class Money
    {
        public DateTime ConsumeTime { get; set; }
        public string Event { get; set; }
        public double Amount { get; set; }
        public string CoverImage { get; set; }
    }

    //这里先写了一个类似ViewModel的类，坤哥看看后删了就行
    public class MoneyManager
    {
        public static ObservableCollection<Money> GetEvents()
        {
            var events = new ObservableCollection<Money>();

            events.Add(new Money { ConsumeTime = DateTime.Now, Event = "购买苹果电脑", Amount = 10000.0, CoverImage = "Assets/image.jpg" });
            events.Add(new Money { ConsumeTime = DateTime.Now, Event = "购买苹果手机", Amount = 5000.0, CoverImage = "Assets/image.jpg" });
            events.Add(new Money { ConsumeTime = DateTime.Now, Event = "购买苹果耳机", Amount = 5000.0, CoverImage = "Assets/image.jpg" });
            events.Add(new Money { ConsumeTime = DateTime.Now, Event = "购买苹果Pad", Amount = 5000.0, CoverImage = "Assets/image.jpg" });
            events.Add(new Money { ConsumeTime = DateTime.Now, Event = "购买联想电脑", Amount = 10000, CoverImage = "Assets/image.jpg" });
            events.Add(new Money { ConsumeTime = DateTime.Now, Event = "购买联想手机", Amount = 5000.0, CoverImage = "Assets/image.jpg" });
            events.Add(new Money { ConsumeTime = DateTime.Now, Event = "购买联想耳机", Amount = 5000.0, CoverImage = "Assets/image.jpg" });
            events.Add(new Money { ConsumeTime = DateTime.Now, Event = "购买联想Pad", Amount = 5000.0, CoverImage = "Assets/image.jpg" });
            events.Add(new Money { ConsumeTime = DateTime.Now, Event = "购买万达广场", Amount = 5000.0, CoverImage = "Assets/image.jpg" });
            events.Add(new Money { ConsumeTime = DateTime.Now, Event = "购买东北大学", Amount = 5000.0, CoverImage = "Assets/image.jpg" });

            return events;
        }
        
    }
     
}
