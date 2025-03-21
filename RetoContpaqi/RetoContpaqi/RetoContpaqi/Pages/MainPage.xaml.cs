using RetoContpaqi.Models;
using RetoContpaqi.ViewModels.Pages;
using System.Threading.Tasks;

namespace RetoContpaqi.Pages;

public partial class MainPage : ContentPage
{
    private readonly MainPageViewModel pageViewModel;

    public MainPage(MainPageViewModel pageViewModel)
	{
		InitializeComponent();
		this.BindingContext = this.pageViewModel = pageViewModel;
    }

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        try
        {
            if (e.CurrentSelection.Count > 0) 
            {
                var item = e.CurrentSelection.FirstOrDefault() as UserModel;
                if (item != null)
                {
                    await pageViewModel.OnNavigationDetail(item);
                }
                ((CollectionView)sender).SelectedItem = null;
            }
        }
        catch(Exception ex)
        {

        }
    }
}