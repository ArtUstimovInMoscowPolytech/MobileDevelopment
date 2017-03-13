using System;
using System.Diagnostics;
using MobileDevelopment.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileDevelopment.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilePage : ContentPage
    {
        private readonly FilePageViewModel _viewModel;

        public FilePage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new FilePageViewModel(this);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await _viewModel.LoadText();
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();

            await _viewModel.StoreText();       
        }
    }
}
