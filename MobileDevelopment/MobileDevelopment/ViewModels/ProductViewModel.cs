using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using MobileDevelopment.Models;
using MobileDevelopment.Services;
using Xamarin.Forms;

namespace MobileDevelopment.ViewModels
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        private readonly IDataService _dataService;

        private readonly Page _page;

        public event PropertyChangedEventHandler PropertyChanged;

        public Product Product { get; private set; } = new Product();

        public int Quantity { get; private set; } = 1;

        public int Sum => Quantity * Product.Price;

        public ICommand PostOrderCommand { get; private set; }

        public ProductViewModel(Page page, IDataService dataService)
        {
            _dataService = dataService;
            _page = page;

            PostOrderCommand = new Command(async () =>
            {
                await _dataService.PostPostOrderAsync(Product.Id, Quantity);
                await page.DisplayAlert(null, "Заказ успешно отправлен", "ОК");
            });
        }

        public void UpdateQuantity(int quantity)
        {
            Quantity = quantity;
            OnPropertyChanged(nameof(Quantity));
            OnPropertyChanged(nameof(Sum));

            // Событие Yandex.Metrica
            YandexMetricaPCL.YandexMetrica.Implementation.ReportEvent("ProductQuantityChanged");

            // Событие Flurry
            Flurry.Analytics.Portable.AnalyticsApi.LogEvent("ProductQuantityChanged");

            // Событие Mobile Center
            Analytics.TrackEvent("ProductQuantityChanged");
        }

        public async Task LoadProductAsync(int id)
        {
            Product = await _dataService.GetProductAsync(id);
            OnPropertyChanged(nameof(Product));
            OnPropertyChanged(nameof(Sum));
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
