using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manager.Models;

namespace Manager.Services
{
    public interface IToolItemService
    {
        List<ToolItem> ListAsync();
        void AddAsync(ToolItem toolItem);
        void DeleteAsync(ToolItem toolItem);
        void ChangeAsync(int id, ToolItem toolItem);
    }
}
