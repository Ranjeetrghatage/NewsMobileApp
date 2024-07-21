using NewsMobileApp.MVVM.Views;

namespace NewsMobileApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new HomePage();
        }
    }
}
