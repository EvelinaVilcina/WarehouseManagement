using System.Collections.Generic;
using WarehouseManagement.Models;
using WarehouseManagement.Services;
using Xunit;

namespace WarehouseManagement.Tests
{
    public class ProductManagementServiceTests
    {
        private readonly ProductManagementService _service;

        public ProductManagementServiceTests()
        {
            _service = new ProductManagementService();
        }

        [Fact]
        public void AddProduct_WhenProductGetsAdded_ThenGetsSaved()
        {
            Product product = new Product()
            {
                Name = "a"
            };

            _service.AddProduct(product);
            
            Product actualProduct = _service.GetProduct(product.Name);

            Assert.Equal(product, actualProduct);
        }

        [Fact]
        public void GetAllAvailableProducts_WhenAsked_ThenShowsAList()
        {
            Product product = new Product()
            {
                Name = "a"
            };

            _service.AddProduct(product);
            IList<Product> products = _service.GetAllAvailableProducts();

            Assert.True(products.Contains(product));
        }

        [Fact]
        public void GetProduct_WhenNeeded_ThenFindsAProduct()
        {
            Product product = new Product()
            {
                Name = "a"
            };
            _service.AddProduct(product);
            Product expectedProduct = _service.GetProduct(product.Name);

            Assert.Equal(expectedProduct, product);
        }

        [Fact]
        public void ChangePrice_WhenChangesPrice_ThenShows()
        {
            Product product = new Product()
            {
                Name = "a",
                Price = 0
            };
            _service.AddProduct(product);                                           
            _service.ChangePrice("a", 1);

            Assert.Equal(1, product.Price);
        }

        [Fact]
        public void AddToStock_WhenAdded_ThenShowsAll()
        {
            Product product = new Product()
            {
                Name = "a",
                Stock = 0
            };
            _service.AddProduct(product);
            _service.AddToStock("a", 4);

            Assert.Equal(4, product.Stock);
        }

        [Fact]
        public void RemoveFromStock_WhenRemoved_thenShowsTheRest()
        {
            Product product = new Product()
            {
                Name = "a",
                Stock = 4
            };
            _service.AddProduct(product);
            _service.RemoveFromStock("a", 3);

            Assert.Equal(1, product.Stock);
        }

        [Fact]
        public void MarkOutOfStock_WhenOutOfStock_ThenShows()
        {
            Product product = new Product()
            {
                Name = "a"
            };
            _service.AddProduct(product);
            _service.MarkOutOfStock("a");

            Assert.True(product.IsOutOfStock);
        }

        [Fact]
        public void RemoveProduct_WhenProductIsRemoved_ThenNotInTheList()
        {
            Product product = new Product()
            {
                Name = "a"
            };
            _service.AddProduct(product);
            _service.RemoveProduct("a");

            IList<Product> products = _service.GetAllAvailableProducts();

            Assert.False(products.Contains(product));
        }
    }
}
