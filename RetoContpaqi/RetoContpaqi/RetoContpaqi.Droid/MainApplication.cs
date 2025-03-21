using Android.App;
using Android.Runtime;
using RetoContpaqi.Helpers;

namespace RetoContpaqi.Droid
{
    #if DEBUG
        [Application(UsesCleartextTraffic = true)]
    #else                                       
        [Application]
    #endif
    [MetaData("com.google.android.maps.v2.API_KEY", Value = GoogleMapsKey.KeyDroid)]
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
