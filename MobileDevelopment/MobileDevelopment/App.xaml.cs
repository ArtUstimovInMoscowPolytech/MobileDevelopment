using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using MobileDevelopment.Views;
using Xamarin.Forms;

namespace MobileDevelopment
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //Biglion
            //var np = new NavigationPage(new MediatorPage());
            //np.BarBackgroundColor = Color.Orange;
            //MainPage = np;//new Views.RootPage();

            MainPage = new RootPage();
        }

        protected override void OnStart()
        {
            //// Подключение Mobile Center
            //MobileCenter.Start(typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
