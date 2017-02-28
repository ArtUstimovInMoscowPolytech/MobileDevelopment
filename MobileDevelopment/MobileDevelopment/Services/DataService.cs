using System;
using System.Threading.Tasks;
using MobileDevelopment.Models;

namespace MobileDevelopment.Services
{
    public class DataService : IDataService
    {
        public async Task<Product> GetProductAsync(int id)
        {
            await SimulateNetwork();

            return new Product
            {
                Id = id,
                Description = "Описание товара",
                Name = "Наименование товара",
                Price = 200,
            };
        }

        public async Task PostPostOrderAsync(int productId, int quantity)
        {
            await SimulateNetwork();
        }

        private static async Task SimulateNetwork()
        {
            // Задержка для симуляции работы с сетью
            await Task.Delay(TimeSpan.FromSeconds(3));
        }
    }
}
