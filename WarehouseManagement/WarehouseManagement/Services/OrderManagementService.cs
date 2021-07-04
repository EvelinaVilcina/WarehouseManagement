using System.Collections.Generic;
using System.Linq;
using WarehouseManagement.Exeptions;
using WarehouseManagement.Interfaces;
using WarehouseManagement.Models;

namespace WarehouseManagement.Services
{
    public class OrderManagementService : IOrderManagementService
    {
        private readonly List<Order> _orders;

        public OrderManagementService()
        {
            _orders = new List<Order>();
        }

        public void MakeAnOrder(Client client, string orderNumber)
        {           
            Order order = new Order()
            {
                OrderNumber = orderNumber,
                Client = client
            };
            
            _orders.Add(order);
        }

        public Order GetOrder(string orderNumber)
        {
            Order order = _orders.SingleOrDefault(o => o.OrderNumber == orderNumber);

            if (order == null)
            {
                throw new OrderDoesntExsistExeption("No order found with this number");
            }

            return order;            
        }

        public void ChangeClient(string orderNumber, Client client)
        {
            Order order = GetOrder(orderNumber);
            order.Client = client;
        }

        public void AddProduct(string orderNumber, Product product)
        {
            Order order = GetOrder(orderNumber);            
            
            if(order.Products == null)
            {
                List<Product> products = new List<Product>();
                order.Products = products;
            }
                                            
            order.Products.Add(product);
        }

        public void RemoveProduct(string orderNumber, Product product)
        {
            Order order = GetOrder(orderNumber);
            
            if (order.Products == null)
            {
                throw new OrderAlreadyEmptyExeption("Product list is already empty");
            }

            order.Products.Remove(product);
        }
    }
}
