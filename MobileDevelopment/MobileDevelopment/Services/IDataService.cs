using System.Threading.Tasks;
using MobileDevelopment.Models;

namespace MobileDevelopment.Services
{
    public interface IDataService
    {
        Task<Product> GetProductAsync(int id);
        Task PostPostOrderAsync(int productId, int quantity);
    }
}
