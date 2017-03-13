using MobileDevelopment.Services;
using MobileDevelopment.ViewModels;
using Xamarin.Forms;

namespace MobileDevelopment.Views
{
    public partial class ProductPage : ContentPage
    {
        private ProductViewModel _viewModel;

        public ProductPage()
        {
            InitializeComponent();

            _viewModel = new ProductViewModel(this, new DataService());

            BindingContext = _viewModel;  
        }

        private void Stepper_OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (e.NewValue < 1)
            {
                ((Stepper)sender).Value = 1;
            }
            else
            {
                _viewModel.UpdateQuantity((int)e.NewValue);
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await _viewModel.LoadProductAsync(1);
        }
    }
}
