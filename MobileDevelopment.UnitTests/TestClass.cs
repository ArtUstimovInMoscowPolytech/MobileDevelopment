using NUnit.Framework;
using System.Threading.Tasks;
using MobileDevelopment.Models;
using MobileDevelopment.Services;
using MobileDevelopment.ViewModels;
using Moq;
using Xamarin.Forms;

namespace MobileDevelopment.UnitTests
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public async Task TestProductLoad()
        {
            var mock = new Mock<IDataService>();

            mock.Setup(obj => obj.GetProductAsync(111)).ReturnsAsync(() => new Product
            {
                Id = 2,
            });

            mock.Setup(obj => obj.GetProductAsync(2))
                .ReturnsAsync(() => new Product
                {
                    Id = 2,
                });

            var viewModel = new ProductViewModel(new Page(), mock.Object);
            await viewModel.LoadProductAsync(2);

            Assert.AreEqual(2, viewModel.Product.Id);
        }

        [Test]
        public async Task TestProductSum()
        {
            var mock = new Mock<IDataService>();

            mock.Setup(framework => framework.GetProductAsync(1))
                .ReturnsAsync(() => new Product
                {
                    Id = 1,
                    Price = 200,
                });

            var viewModel = new ProductViewModel(new Page(), mock.Object);
            await viewModel.LoadProductAsync(1);

            viewModel.UpdateQuantity(6);

            Assert.AreEqual(viewModel.Sum, 1200);
        }
    }
}
