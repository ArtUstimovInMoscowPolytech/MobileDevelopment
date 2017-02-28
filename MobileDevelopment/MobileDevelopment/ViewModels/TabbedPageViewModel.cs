using System;
using System.Collections.ObjectModel;

namespace MobileDevelopment.ViewModels
{
    public class Item
    {
        public string Description { get; set; }

        public DateTime FromDateTime { get; set; }

        public DateTime ToDateTime { get; set; }

        public string Image { get; set; }
    }

    public class TabbedPageViewModel
    {
        public ObservableCollection<Item> Items = new ObservableCollection<Item>
        {
            new Item
            {
                Description = "Всё меню кухни в ресторане Якитория",
                FromDateTime = DateTime.Now,
                ToDateTime = DateTime.Now + TimeSpan.FromDays(10),
                Image = "https://igx.4sqi.net/img/general/558x200/62852567_DHcFIijmY7a48O-_8JTu4fVkl8eQYAGYOiBN5oKtT0A.jpg",
            },
        };
    }
}
