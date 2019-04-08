using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manager.Models;

namespace Manager.Services
{
    public interface IMoneyItemService
    {
        List<MoneyItem> ListAsync();
        void AddAsync(MoneyItem moneyItem);
        void DeleteAsync(MoneyItem moneyItem);
    }
}
