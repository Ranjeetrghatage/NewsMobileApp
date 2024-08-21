using NewsMobileApp.MVVM.Models;
using NewsMobileApp.MVVM.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsMobileApp.MVVM.ViewModels
{
    public class NewsViewModel
    {
        public NewsViewModel()
        {
        }

        public static async Task<ObservableCollection<Article>> LoadNews(string newsHeading,string language,ObservableCollection<Article> newsList)
        {
            var Rootnews =await ApiData.GetNews(newsHeading, language);

            foreach (var article in Rootnews.Articles)
            {
                newsList.Add(article);  
            }
            return newsList; 
        }

    }
}
