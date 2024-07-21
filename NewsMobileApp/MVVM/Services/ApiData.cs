using NewsMobileApp.MVVM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsMobileApp.MVVM.Services
{
    public class ApiData
    {
        public static async Task<Root> GetNews(string newsTopic)
        {
            try
            {
                var httpClient = new HttpClient();
                var jsonData = await httpClient.GetStringAsync("https://gnews.io/api/v4/top-headlines?token=5407c0202837a13e3983187c85356ea1&lang=hi&topic=" + newsTopic.ToLower());
                var result = JsonConvert.DeserializeObject<Root>(jsonData);
                return result;
            }
            catch (Exception ex)
            {
               throw new Exception(ex.Message);    
            }
        }
    }
}
