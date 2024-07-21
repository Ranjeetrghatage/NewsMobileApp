using NewsMobileApp.MVVM.Models;

namespace NewsMobileApp.MVVM.Views;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(Article article)
	{
		InitializeComponent();
		ImageNews.Source = article.Image;
		Titlelbl.Text = article.Title;	
		description.Text = article.Description;	
	}
}