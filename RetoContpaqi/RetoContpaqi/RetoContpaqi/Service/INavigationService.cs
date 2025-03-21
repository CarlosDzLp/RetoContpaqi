

namespace RetoContpaqi.Service
{
    public interface INavigationService
    {
        Task GoBack();
        Task OnPrincipal();
        Task OnLogin();
        Task NavigateToPage<T>(object? parameter = null) where T : Page;
    }
}
