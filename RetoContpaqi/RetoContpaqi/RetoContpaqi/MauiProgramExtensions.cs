using Auth0.OidcClient;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Plugin.Maui.Biometric;
using RetoContpaqi.Pages;
using RetoContpaqi.Service;
using RetoContpaqi.Service.Client;
using RetoContpaqi.ViewModels.Pages;

namespace RetoContpaqi
{
    public static class MauiProgramExtensions
    {
        public static MauiAppBuilder UseSharedMauiApp(this MauiAppBuilder builder)
        {
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .RegisterViewModels()
                .RegisterViews()
                .RegisterService()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("Poppins-Bold.ttf", "PBold");
                    fonts.AddFont("Poppins-Light.ttf", "PLight");
                    fonts.AddFont("Poppins-Medium.ttf", "PMedium");
                    fonts.AddFont("Poppins-Regular.ttf", "PRegular");
                    fonts.AddFont("Poppins-Thin.ttf", "PThin");

                    fonts.AddFont("FontAwesomeBrandsRegular.otf", "FRegular");
                    fonts.AddFont("FontAwesomeDuotoneSolid.otf", "FDuotoneSolid");
                    fonts.AddFont("FontAwesomeProLight.otf", "FProLight");
                    fonts.AddFont("FontAwesomeProRegular.otf", "FProRegular");
                    fonts.AddFont("FontAwesomeProSolid.otf", "FProSolid");
                    fonts.AddFont("FontAwesomeProThin.otf", "FProThin");
                    fonts.AddFont("FontAwesomeRegular.otf", "FRegular");
                    fonts.AddFont("FontAwesomeSolid.otf", "FSolid");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder;
        }

        #region Service
        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<NavigationPage>();
            mauiAppBuilder.Services.AddTransient<LoginPage>();
            mauiAppBuilder.Services.AddTransient<MainPage>();
            mauiAppBuilder.Services.AddTransient<DetailPage>();
            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<LoginPageViewModel>();
            mauiAppBuilder.Services.AddTransient<MainPageViewModel>();
            mauiAppBuilder.Services.AddTransient<DetailPageViewModel>();
            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterService(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<IBiometric>(BiometricAuthenticationService.Default);
            mauiAppBuilder.Services.AddSingleton<IServiceClient, ServiceClient>();
            mauiAppBuilder.Services.AddTransient<INavigationService, NavigationService>();

            var client = new Auth0Client(new Auth0ClientOptions
            {
                Domain = "dev-ymud4lrcl7f6anj2.us.auth0.com",
                ClientId = "imcsAjrgvEh57sqqgcgX4ID7JiYFF0f8",
                RedirectUri = "myapp://callback",
                PostLogoutRedirectUri = "myapp://callback",
                Scope = "openid profile email"
            });
            mauiAppBuilder.Services.AddSingleton(client);
            return mauiAppBuilder;
        }
        #endregion
    }
}
