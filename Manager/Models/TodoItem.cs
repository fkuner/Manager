using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Models
{
    public class TodoItem
    {
        /// <summary>
        /// 待办事项类
        /// </summary>

        public int ID { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
    }

}
