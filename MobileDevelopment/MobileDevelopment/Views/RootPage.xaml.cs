using System;
using System.Threading.Tasks;
using MobileDevelopment.Models;
using Xamarin.Forms;

namespace MobileDevelopment.Views
{
    public partial class RootPage : MasterDetailPage
    {
        public RootPage()
        {
            InitializeComponent();

            var menu = new MenuPage();
            Master = menu;
            Detail = new NavigationPage(new MainPage());
            menu.Items.ItemSelected += OnItemSelected;
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs selectedItemChangedEventArgs)
        {
            var listView = (ListView)sender;
            if (listView.SelectedItem != null)
            {

                await NavigateTo(((MenuItemModel)listView.SelectedItem).PageType);
                listView.SelectedItem = null;
            }
        }

        private async Task NavigateTo(Type pageType)
        {
            var displayPage = (Page)Activator.CreateInstance(pageType);
            Detail = new NavigationPage(displayPage);
            IsPresented = false;
        }
    }
}
