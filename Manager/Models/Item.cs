using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Models
{
    public class Item
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
