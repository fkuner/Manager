﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manager.Models;

namespace Manager.Services
{
    public interface IMoneyItemService
    {
        /// <summary>
        /// 返回MoneyItem列表
        /// </summary>
        /// <returns></returns>
        List<MoneyItem> ListAsync();

        /// <summary>
        /// 添加MoneyItem
        /// </summary>
        /// <param name="moneyItem"></param>
        void AddAsync(MoneyItem moneyItem);

        /// <summary>
        /// 删除MoneyItem
        /// </summary>
        /// <param name="moneyItem"></param>
        void DeleteAsync(MoneyItem moneyItem);

        /// <summary>
        /// 根据Id更改MoneyItem
        /// </summary>
        /// <param name="id"></param>
        /// <param name="moneyItem"></param>
        void ChangeAsync(int id, MoneyItem moneyItem);

        /// <summary>
        /// 根据时间（年，月)查找消费额
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        double SearchAsync(DateTime date);

        /// <summary>
        /// 将最大消费额和差值保存到文件中
        /// </summary>
        /// <param name="maxConsume"></param>
        /// <param name="difference"></param>
        void SaveAsync(double Consume);

        /// <summary>
        /// 清空操作
        /// </summary>
        void ClearAsync();

        /// <summary>
        /// 读取最大消费额和差值
        /// </summary>
        List<double> ReadAsync();
    }
}
