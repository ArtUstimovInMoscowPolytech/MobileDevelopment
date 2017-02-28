using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileDevelopment.Views.Biglion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MediatorPage : ContentPage
    {
        public MediatorPage()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TabPage());
        }
    }
}
