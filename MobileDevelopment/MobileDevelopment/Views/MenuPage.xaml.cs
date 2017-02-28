using System;
using MobileDevelopment.ViewModels;
using Xamarin.Forms;

namespace MobileDevelopment.Views
{
    public partial class MenuPage : ContentPage
    {
        public ListView Items => _listView;

        public MenuPage()
        {
            InitializeComponent();

            var viewModel = new MenuViewModel();
            _listView.ItemsSource = viewModel.Items;
            _listView.ItemSelected += (sender, e) =>
            {
                if (_listView.SelectedItem != null)
                {
                    _listView.SelectedItem = null;
                }
            };
            BindingContext = viewModel;
        }
    }
}
