using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Models
{
    
    class TodoItem
    {
        /// <summary>
        /// 待办事项类
        /// </summary>
        
        //property
        private String item;
        private Date date;
        int level;  //事件的优先级

        //method
        public TodoItem()
        {
            Console.WriteLine("对象已创建");
        }
        public TodoItem(String item)
        {
            this.item = item;
        }
    }

    class TodoItemList
    {
        /// <summary>
        /// 待办事项列表类
        /// </summary>
        private TodoItem todoItem;
    }

    class Date
    {
        /// <summary>
        /// 日期类
        /// </summary>
        private int year;
        private int month;
        private int day;
        private int hour;
        private int minute;
        private int second;

        public int getYear()
        {
            return this.year;
        }
        public int getMonth()
        {
            return this.month;
        }
        public int getDay()
        {
            return this.day;
        }
        public int getHour()
        {
            return this.year;
        }
        public int getMinute()
        {
            return this.minute;
        }
        public int getSecond()
        {
            return this.second;
        }
    }
}
