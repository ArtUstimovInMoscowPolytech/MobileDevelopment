using System.Collections.ObjectModel;
using MobileDevelopment.Models;
using MobileDevelopment.Views;

namespace MobileDevelopment.ViewModels
{
    public class MenuViewModel
    {
        public ObservableCollection<MenuItemModel> Items = new ObservableCollection<MenuItemModel>
        {
            new MenuItemModel
            {
                Title = "Главная",
                PageType = typeof(MainPage),
            },
            new MenuItemModel
            {
                Title = "Товар",
                PageType = typeof(ProductPage),
            },
            new MenuItemModel
            {
                Title = "Файл",
                PageType = typeof(FilePage),
            },
            new MenuItemModel
            {
                Title = "Оповещения",
                PageType = typeof(LocalPushPage),
            },
        };
    }
}
