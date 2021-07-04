using System.Collections.Generic;
using System.Linq;
using WarehouseManagement.Exeptions;
using WarehouseManagement.Interfaces;
using WarehouseManagement.Models;

namespace WarehouseManagement.Services
{
    public class ProductManagementService : IProductManagementService
    {
        private readonly List<Product> _products;

        public ProductManagementService()
        {
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            if (_products.Any(p => p.Name == product.Name))
            {
                throw new ProductAlreadyExistsExeption("Product with this naming already exsists");
            }
            _products.Add(product);
        }

        public IList<Product> GetAllAvailableProducts()
        {
            List<Product> products = _products.Where(p => !p.IsOutOfStock).ToList();
            return products;
        }

        public Product GetProduct(string Name)
        {
            Product product = _products.SingleOrDefault(p => p.Name == Name);

            if(product == null)
            {
                throw new ProductDoesntExistException("No product found");
            }

            return product;
        }

        public void ChangePrice(string Name, double newPrice)
        {
            Product product = GetProduct(Name);
            product.Price = newPrice;
        }

        public void AddToStock(string Name, int howMany)
        {
            Product product = GetProduct(Name);
            int newStock = product.Stock + howMany;
            product.Stock = newStock;
        }

        public void RemoveFromStock(string Name, int howMany)
        {
            Product product = GetProduct(Name);
            int newStock = product.Stock - howMany;
            product.Stock = newStock;
        }

        public void MarkOutOfStock(string Name)
        {
            Product product = GetProduct(Name);
            product.IsOutOfStock = true;
        }

        public void RemoveProduct(string Name)
        {
            Product product = GetProduct(Name);
            _products.Remove(product);
        }
    }
}
