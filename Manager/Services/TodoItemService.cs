using Manager.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Services
{
    class TodoItemService
    {
        /// <summary>
        /// 列出所有Todo项目。
        /// </summary>
        /// <returns>所有Todo项目。</returns>
        public async Task<List<TodoItem>> ListAsync()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response =
                await httpClient.GetAsync(
                    "http://localhost:5000/api/todoItems");
            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<TodoItem>>(json);
        }

        /// <summary>
        /// 添加Todo项目。
        /// </summary>
        /// <param name="todoItem">要添加的Todo项目。</param>
        public async Task AddAsync(TodoItem todoItem)
        {
            HttpClient httpClient = new HttpClient();
            string json = JsonConvert.SerializeObject(todoItem);
            await httpClient.PostAsync("http://localhost:5000/api/todoItems",
                new StringContent(json, Encoding.UTF8, "application/json"));
        }

        /// <summary>
        /// 删除Todo项目。
        /// </summary>
        /// <param name="todoItem">要删除的Todo项目。</param>
        public async Task DeleteAsync(TodoItem todoItem)
        {
            HttpClient httpClient = new HttpClient();
            await httpClient.DeleteAsync(
                "http://localhost:5000/api/todoItems/" + todoItem.ID);
        }
    }
}
