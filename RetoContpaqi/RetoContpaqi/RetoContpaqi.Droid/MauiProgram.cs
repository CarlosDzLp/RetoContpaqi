using Maui.GoogleMaps.Android;
using Maui.GoogleMaps.Hosting;

namespace RetoContpaqi.Droid
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder.UseSharedMauiApp();
            var platformConfig = new PlatformConfig
            {
                BitmapDescriptorFactory = new CachingNativeBitmapDescriptorFactory()
            };
            builder.UseGoogleMaps(platformConfig);
            return builder.Build();
        }
    }
}
