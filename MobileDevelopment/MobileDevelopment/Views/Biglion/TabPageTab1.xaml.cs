using MobileDevelopment.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileDevelopment.Views.Biglion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabPageTab1 : ContentPage
    {
        public TabPageTab1()
        {
            InitializeComponent();

            var viewModel = new TabbedPageViewModel();
            _listView.ItemsSource = viewModel.Items;
        }
    }
}
