﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manager.Models;

namespace Manager.Services
{
    public interface IMemoItemService
    {
        List<MemoItem> ListAsync();
        void AddAsync(MemoItem memoItem);
        void DeleteAsync(MemoItem memoItem);
    }
}
