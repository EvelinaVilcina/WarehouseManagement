using System.Collections.Generic;
using WarehouseManagement.Models;

namespace WarehouseManagement.Interfaces
{
    public interface IProductManagementService
    {
        void AddProduct(Product product);

        IList<Product> GetAllAvailableProducts();
        
        Product GetProduct(string Name);
          
        void ChangePrice(string Name, double newPrice);

        void AddToStock(string Name, int howMany);

        void RemoveFromStock(string Name, int howMany);

        void MarkOutOfStock(string Name);

        void RemoveProduct(string Name);
    }
}