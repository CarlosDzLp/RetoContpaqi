using Auth0.OidcClient;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Plugin.Maui.Biometric;
using RetoContpaqi.Service;
using RetoContpaqi.ViewModels.Base;
using System.Windows.Input;

namespace RetoContpaqi.ViewModels.Pages
{
    public class LoginPageViewModel : BindableBase
    {
        private readonly INavigationService navigationService;
        private readonly IBiometric biometric;
        private readonly Auth0Client auth0Client;

        #region Properties
        public bool IsBiometric { get; set; }
        #endregion

        #region Constructor
        public LoginPageViewModel(INavigationService navigationService, IBiometric biometric, Auth0Client auth0Client)
        {
            this.navigationService = navigationService;
            this.biometric = biometric;
            this.auth0Client = auth0Client;
            LoginCommand = new Command(async () => await LoginCommandExecuted());
            BiometricCommand = new Command(async () => await BiometricCommandExecuted());
            _ = ValidateBiometric();            
        }
        #endregion

        #region Command
        public ICommand LoginCommand { get; set; }
        public ICommand BiometricCommand { get; set; }
        #endregion

        #region CommandExecuted
        private async Task LoginCommandExecuted()
        {
            try
            {
                var loginResult = await auth0Client.LoginAsync();
                if (loginResult != null && !string.IsNullOrWhiteSpace(loginResult.AccessToken)) 
                {
                    var bio = await SecureStorage.GetAsync("ACCESS");
                    if (!string.IsNullOrWhiteSpace(bio))
                        SecureStorage.Remove("ACCESS");
                    await SecureStorage.SetAsync("ACCESS", loginResult.AccessToken);
                    await navigationService.OnPrincipal();
                }
                
            }
            catch (Exception ex)
            {

            }
        }

        private async Task BiometricCommandExecuted()
        {
            try
            {
                var snackbarOptions = new SnackbarOptions
                {
                    BackgroundColor = Colors.Red,
                    TextColor = Colors.White,
                    CornerRadius = new CornerRadius(10),
                };                
                TimeSpan duration = TimeSpan.FromSeconds(3);                             
                if (biometric.IsPlatformSupported)
                {
                    var result = await biometric.AuthenticateAsync(new AuthenticationRequest
                    {
                        AllowPasswordAuth = true,
                        AuthStrength = AuthenticatorStrength.Weak,
                        NegativeText = "Cancelar",
                        Subtitle = "Contpaq",
                        Title = "Reto Contpaq",
                        Description = "Reto contpaq, authenticación"
                    }, CancellationToken.None);
                    if(result.Status == BiometricResponseStatus.Success)
                    {
                        var bio = await SecureStorage.GetAsync("ACCESS");
                        if (!string.IsNullOrWhiteSpace(bio))
                        {
                            await navigationService.OnPrincipal();
                        }                          
                    }
                    else
                    {
                        await Snackbar.Make("Se ha cancelado la authenticación", null, string.Empty, duration, snackbarOptions).Show();
                    }
                }
                else
                {
                    await Snackbar.Make("No tiene soporte el telefono para biometricos", null, string.Empty, duration, snackbarOptions).Show();
                }
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        #region Methods
        private async Task ValidateBiometric()
        {
            try
            {
                IsBiometric = false;
                var bio = await SecureStorage.GetAsync("BIOMETRIC");
                if (!string.IsNullOrWhiteSpace(bio) && bio == "1")
                    IsBiometric = true;
                if (IsBiometric)
                {
                    await BiometricCommandExecuted();
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
    }
}
