using RetoContpaqi.ViewModels.Pages;

namespace RetoContpaqi.Pages;

public partial class DetailPage : ContentPage
{
    private readonly DetailPageViewModel detailPageView;

    public DetailPage(DetailPageViewModel detailPageView)
	{
		InitializeComponent();
		this.BindingContext = this.detailPageView = detailPageView;
    }
}