using WarehouseManagement.Models;
using WarehouseManagement.Services;
using Xunit;

namespace WarehouseManagement.Tests
{
    public class OrderManagementServiceTests
    {
        public readonly OrderManagementService _orders;

        public OrderManagementServiceTests()
        {
            _orders = new OrderManagementService();
        }

        [Fact]
        public void MakeOrder_WhenNewOrder_ThenSaves()
        {
            Client client = new Client()
            {
                FullName = "a"
            };
            
            _orders.MakeAnOrder(client, "1");

            Order actualOrder = _orders.GetOrder("1");
            Assert.Equal("1", actualOrder.OrderNumber);
        }

        [Fact]
        public void GetOrder_WhenAsked_ThenFindsOrder()
        {
            Client client = new Client();           
            _orders.MakeAnOrder(client, "1");

            Order actualOrder = _orders.GetOrder("1");
            Assert.Equal("1", actualOrder.OrderNumber);
        }

        [Fact]
        public void ChangeClient_WhenAddsNewClient_ThenRemovesPrevious()
        {
            Client client = new Client()
            {
                FullName = "a"
            };

            _orders.MakeAnOrder(client, "1");

            Client newClient = new Client()
            {
                FullName = "b"
            };
           
            _orders.ChangeClient("1", newClient);

            Order order = _orders.GetOrder("1");

            Assert.Equal("b", order.Client.FullName);
        }

        [Fact]
        public void AddProduct_WhenAddsNewProduct_ThenGetsSaved()
        {
            Client client = new Client()
            {
                FullName = "a"
            };

            _orders.MakeAnOrder(client, "1");


            Product product = new Product()
            { 
                Name = "a",
                Price = 1,
                ColourCode = 1,
                EanCode = "1"                
            };

            _orders.AddProduct("1", product);
            Order order = _orders.GetOrder("1");

            Assert.True(order.Products.Contains(product));

        }

        [Fact]
        public void RemoveProduct_WhenProductIsRemoved_ThenGetsSaved()
        {
            Client client = new Client()
            {
                FullName = "a"
            };

            _orders.MakeAnOrder(client, "1");

            Product product = new Product()
            {
                Name = "a"
            };

            _orders.AddProduct("1", product);
            _orders.RemoveProduct("1", product);

            Order order = _orders.GetOrder("1");

            Assert.False(order.Products.Contains(product));
        }
    }
}
