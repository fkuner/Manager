using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manager.Models;

namespace Manager.Services
{
    public class MoneyItemService : IMoneyItemService
    {
        public List<MoneyItem> ListAsync()
        {
            //throw new NotImplementedException();
            List<MoneyItem> List=new List<MoneyItem>();
            List.Add(new MoneyItem { ConsumeTime = DateTime.Now, Event = "购买苹果电脑", Amount = 10000.0, CoverImage = "Assets/image.jpg" });
            List.Add(new MoneyItem { ConsumeTime = DateTime.Now, Event = "购买苹果手机", Amount = 5000.0, CoverImage = "Assets/image.jpg" });
            List.Add(new MoneyItem { ConsumeTime = DateTime.Now, Event = "购买苹果耳机", Amount = 5000.0, CoverImage = "Assets/image.jpg" });
            List.Add(new MoneyItem { ConsumeTime = DateTime.Now, Event = "购买苹果Pad", Amount = 5000.0, CoverImage = "Assets/image.jpg" });
            List.Add(new MoneyItem { ConsumeTime = DateTime.Now, Event = "购买联想电脑", Amount = 10000, CoverImage = "Assets/image.jpg" });
            List.Add(new MoneyItem { ConsumeTime = DateTime.Now, Event = "购买联想手机", Amount = 5000.0, CoverImage = "Assets/image.jpg" });
            List.Add(new MoneyItem { ConsumeTime = DateTime.Now, Event = "购买联想耳机", Amount = 5000.0, CoverImage = "Assets/image.jpg" });
            List.Add(new MoneyItem { ConsumeTime = DateTime.Now, Event = "购买联想Pad", Amount = 5000.0, CoverImage = "Assets/image.jpg" });
            List.Add(new MoneyItem { ConsumeTime = DateTime.Now, Event = "购买万达广场", Amount = 5000.0, CoverImage = "Assets/image.jpg" });
            List.Add(new MoneyItem { ConsumeTime = DateTime.Now, Event = "购买东北大学", Amount = 5000.0, CoverImage = "Assets/image.jpg" });

            return List;
        }

        public void AddAsync(MoneyItem moneyItem)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(MoneyItem moneyItem)
        {
            throw new NotImplementedException();
        }
    }
}
