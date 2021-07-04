using WarehouseManagement.Models;

namespace WarehouseManagement.Interfaces
{
    public interface IOrderManagementService
    {
        void MakeAnOrder(Client client, string orderNumber);
        Order GetOrder(string orderNumber);

        void ChangeClient(string orderNumber, Client client);

        void AddProduct(string orderNumber, Product product);

        void RemoveProduct(string orderNumber, Product product);
    }
}