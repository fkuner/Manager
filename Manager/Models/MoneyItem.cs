using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Models
{
    public class MoneyItem
    {
        public int ID { get; set; }
        public DateTime ConsumeTime { get; set; }
        public string Event { get; set; }
        public double Amount { get; set; }
        public string CoverImage { get; set; }
    }

}
