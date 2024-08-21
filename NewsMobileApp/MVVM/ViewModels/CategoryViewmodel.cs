using DocumentFormat.OpenXml.Office2016.Drawing.Command;
using NewsMobileApp.MVVM.Models;
using NewsMobileApp.MVVM.Views;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Globalization;

namespace NewsMobileApp.MVVM.ViewModels
{
    public class CategoryViewmodel : BindableBase
    {

        public CategoryViewmodel()
        {
            ArticlesList = new ObservableCollection<Article>();
            LoadCategory();
            CallApi();
            ComboLangItemSrc();
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


        private ObservableCollection<string> _comboProp;

        public ObservableCollection<string> ComboProp
        {
            get { return _comboProp; }
            set { _comboProp = value;
            RaisePropertyChanged(nameof(ComboProp));   
            }
        }


        private string _comboselected;

        public string ComboSelected
        {
            get { return _comboselected; }
            set { _comboselected = value;
                RaisePropertyChanged(nameof(ComboSelected));
                CallApi(lang:ComboSelected);
            }
        }


        public void ComboLangItemSrc()
        {
            ComboProp = new ObservableCollection<string>
            {
                "Arabic","Chinese","Dutch","English","French","German",
                "Greek","Hebrew","Hindi","Italian","Japanese","Malayalam",
                "Marathi","Norwegian","Portuguese","Romanian","Russian","Spanish",
                "Swedish","Tamil","Telugu","Ukrainian"
            };
        }

        private async void CallApi(string topic = "breaking-news",string lang = "English")
        {
            topic = string.IsNullOrEmpty(topic) ? "breaking-news" : topic;
            lang = GetVariableNameByValue(lang).Split('-')[0];
            
            ArticlesList.Clear();   
            ArticlesList = await NewsViewModel.LoadNews(topic,lang, ArticlesList);
        }

        private string GetUniqueCode(string lang)
        {

            //throw new NotImplementedException();
            return null;
        }


        public static string GetVariableNameByValue(string languageName)
        {
            try
            {
                var cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
                foreach (var culture in cultures)
                {
                    if (culture.DisplayName.StartsWith(languageName, StringComparison.OrdinalIgnoreCase))
                    {
                        return culture.Name;
                    }
                }
                return null;
            }
            catch (CultureNotFoundException)
            {
                return "";
            }
        }

        private void LoadCategory()
        {
            ListOfCategory = new ObservableCollection<Category>()
            {
                new Category {Id=1,Name="Breaking-News" },
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
