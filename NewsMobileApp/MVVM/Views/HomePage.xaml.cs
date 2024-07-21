using DocumentFormat.OpenXml.Drawing.Diagrams;
using NewsMobileApp.MVVM.ViewModels;

namespace NewsMobileApp.MVVM.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
        BindingContext = new CategoryViewmodel();
    }

  

    //private void CategoryView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    //{
    //    var selectedItem = CategoryView.SelectedItem;
  
    //    if (selectedItem != null)
    //    {
    //        CallApi(selectedItem.Name.ToString);
    //    }
    //}
}