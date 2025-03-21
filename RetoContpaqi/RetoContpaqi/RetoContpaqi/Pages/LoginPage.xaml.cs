using RetoContpaqi.ViewModels.Pages;

namespace RetoContpaqi.Pages;

public partial class LoginPage : ContentPage
{
    private readonly LoginPageViewModel pageViewModel;

    public LoginPage(LoginPageViewModel pageViewModel)
	{
		InitializeComponent();
        this.BindingContext = this.pageViewModel = pageViewModel;
    }
}