using DocumentFormat.OpenXml.Office2016.Drawing.Command;
using NewsMobileApp.MVVM.Models;
using NewsMobileApp.MVVM.Views;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace NewsMobileApp.MVVM.ViewModels
{
    public class CategoryViewmodel : BindableBase
    {

        public CategoryViewmodel()
        {
            ArticlesList = new ObservableCollection<Article>();
            LoadCategory();
            CallApi();
        }

        public ObservableCollection<Category> ListOfCategory { get; set; }

        private ObservableCollection<Article> __articlesList;
        public ObservableCollection<Article> ArticlesList
        {
            get { return __articlesList; }
            set { __articlesList = value; 
            RaisePropertyChanged(nameof(ArticlesList));   
            }
        }


        private Category _categoryselected;

        public Category CategorySelected
        {
            get { return _categoryselected; }
            set
            {
                _categoryselected = value;
                RaisePropertyChanged(nameof(CategorySelected));
                CallApi(CategorySelected.Name);
            }
        }


        private Article _articleselected;

        public Article ArtcleSelected
        {
            get { return _articleselected; }
            set { _articleselected = value;
            RaisePropertyChanged(nameof(ArtcleSelected));
                if(_articleselected != null)
                   ArticleSelectedMethod(ArtcleSelected);
            }
        }

        public async void ArticleSelectedMethod(Article sel)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new DetailsPage(sel));
        }

        private async void CallApi(string v = "breaking-news")
        {
            v = string.IsNullOrEmpty(v) ? "breaking-news" : v;
            ArticlesList.Clear();   
            ArticlesList = await NewsViewModel.LoadNews(v, ArticlesList);
        }

        private void LoadCategory()
        {
            ListOfCategory = new ObservableCollection<Category>()
            {
                new Category {Id=1,Name="breaking-news" },
                new Category {Id=2,Name="World" },
                new Category {Id=3,Name="Nation" },
                new Category {Id=4,Name="Business " },
                new Category {Id=5,Name="Entertainment" },
                new Category {Id=6,Name="Sports" },
                new Category {Id=7,Name="Science" },
                new Category {Id=8,Name="Health" },
            };
        }
    }
}
