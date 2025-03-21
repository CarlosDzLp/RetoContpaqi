using Auth0.OidcClient;
using RetoContpaqi.Models;
using RetoContpaqi.Pages;
using RetoContpaqi.Service;
using RetoContpaqi.Service.Client;
using RetoContpaqi.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace RetoContpaqi.ViewModels.Pages
{
    public class MainPageViewModel : BindableBase
    {
        private readonly INavigationService navigationService;
        private readonly IServiceClient serviceClient;
        private readonly Auth0Client auth0Client;

        #region Properties
        private bool _isBiometric;
        public bool IsBiometric
        {
            get { return _isBiometric; }
            set 
            {
                if(value != _isBiometric)
                {
                    SetProperty(ref _isBiometric, value);
                    BiometricCommandExecuted();
                }
            }
        }
        public ObservableCollection<UserModel> ListUser { get; set; }
        #endregion

        #region Constructor
        public MainPageViewModel(INavigationService navigationService, IServiceClient serviceClient, Auth0Client auth0Client)
        {
            this.navigationService = navigationService;
            this.serviceClient = serviceClient;
            this.auth0Client = auth0Client;
            _ = LoadData();
            _ = ValidateBiometric();
            LogOutCommand = new Command(async () => await LogOutCommandExecuted());
        }
        #endregion

        #region Command
        public ICommand LogOutCommand { get; set; }
        #endregion

        #region CommandExecuted
        private async Task LogOutCommandExecuted()
        {
            try
            {
                var result = await auth0Client.LogoutAsync();
                if(result == IdentityModel.OidcClient.Browser.BrowserResultType.Success)
                {
                    SecureStorage.Remove("BIOMETRIC");
                    SecureStorage.Remove("ACCESS");
                    await navigationService.OnLogin();
                }
                
            }
            catch(Exception ex)
            {

            }
        }

        private async Task BiometricCommandExecuted()
        {
            try
            {
                var bio = await SecureStorage.GetAsync("BIOMETRIC");
                if (!string.IsNullOrWhiteSpace(bio))
                    SecureStorage.Remove("BIOMETRIC");
                await SecureStorage.SetAsync("BIOMETRIC", IsBiometric ? "1" : "0");
            }
            catch(Exception ex)
            {

            }
        }
        #endregion

        #region Methods
        private async Task LoadData()
        {
            try
            {
                ListUser = new ObservableCollection<UserModel>();
                var result = await serviceClient.ListUser();
                if(result != null && result.Count > 0)
                {
                    foreach(var item in result)
                    {
                        ListUser.Add(item);
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        private async Task ValidateBiometric()
        {
            try
            {
                var bio = await SecureStorage.GetAsync("BIOMETRIC");
                IsBiometric = (!string.IsNullOrWhiteSpace(bio) && bio == "1") ? true : false;
            }
            catch(Exception ex)
            {

            }
        }

        public async Task OnNavigationDetail(UserModel user)
        {
            try
            {
                await navigationService.NavigateToPage<DetailPage>(user);
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
    }
}
