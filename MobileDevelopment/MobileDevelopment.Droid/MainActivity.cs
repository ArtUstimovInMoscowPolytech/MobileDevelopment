using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.Azure.Mobile;

namespace MobileDevelopment.Droid
{
    [Activity(Label = "MobileDevelopment", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            // Подключение Yandex.Metrica
            YandexMetricaAndroid.YandexMetricaImplementation.Activate(this, "API_KEY", this.Application);

            // Подключение Flurry
            Flurry.Analytics.FlurryAgent.Init(this, "API_KEY");

            // Подключение Mobile Center
            MobileCenter.Configure("API_KEY");

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}