using System;
using WarehouseManagement.Exeptions;
using WarehouseManagement.Models;
using WarehouseManagement.Services;

namespace WarehouseManagement.Ui
{
    public class OrderManagementController
    {
        private readonly OrderManagementService _orders;
        private readonly CorectUserInputHelper _input;
        private readonly ClientManagementService _clients;
        private readonly ProductManagementService _products;

        public OrderManagementController(OrderManagementService orderManagementService, CorectUserInputHelper corectUserInputHelper, ClientManagementService clientManagementService, ProductManagementService productManagementService)
        {
            _orders = orderManagementService;
            _input = corectUserInputHelper;
            _clients = clientManagementService;
            _products = productManagementService;
        }

        public void Start()
        {
            Console.WriteLine("Write number of your Order Management Service operation!");
            Console.WriteLine("1 - Make An Order");
            Console.WriteLine("2 - Get Order");
            Console.WriteLine("3 - Change Client");
            Console.WriteLine("4 - Add Product");
            Console.WriteLine("5 - Remove Product");            
            UserOrderOpChoise(Console.ReadLine());
        }

        private void UserOrderOpChoise(string OrderOpChoise)
        {
            switch (OrderOpChoise)
            {
                case "1":
                    MakeAnOrder();
                    break;

                case "2":
                    GetOrder();
                    break;

                case "3":
                    ChangeClient();
                    break;

                case "4":
                    AddProduct();
                    break;

                case "5":
                    RemoveProduct();
                    break;               
            }
        }

        private void RemoveProduct()
        {
            Order order = _orders.GetOrder(_input.GetUserStringInput("What is the order number?"));
            Product product = _products.GetProduct(_input.GetUserStringInput("What product you want to add?"));
            _orders.RemoveProduct(order.OrderNumber, product);
            Console.WriteLine("Product has been removed");
        }

        private void AddProduct()
        {
            Order order = _orders.GetOrder(_input.GetUserStringInput("What is the order number?"));
            Product product = _products.GetProduct(_input.GetUserStringInput("What product you want to add?"));
            _orders.AddProduct(order.OrderNumber, product);
            Console.WriteLine("Product has been added to order");
        }

        private void ChangeClient()
        {
            Order order = _orders.GetOrder(_input.GetUserStringInput("What is the order number?"));
            Client newClient = _clients.GetClient(_input.GetUserStringInput("What is full name of new client?"));

            _orders.ChangeClient(order.OrderNumber, newClient);
            Console.WriteLine("Client has been changed for the order");
        }

        private void GetOrder()
        {            
            try
            {
                Order order = _orders.GetOrder(_input.GetUserStringInput("What is the order number?"));
                Console.WriteLine(order.OrderNumber);
                Console.WriteLine(order.Client.FullName);
                Console.WriteLine(order.DateTime);

                foreach (var product in order.Products)
                {
                    Console.WriteLine(product.Name);
                    Console.WriteLine(product.Price);
                }
            }
            catch (OrderDoesntExsistExeption ex)
            {
                Console.WriteLine(ex.Message);
            }           
        }

        private void MakeAnOrder()
        {            
            Client client = _clients.GetClient(_input.GetUserStringInput("What is full name of client?"));
            string orderNumber = _input.GetUserStringInput("What will be order number?"); 
            
            _orders.MakeAnOrder(client, orderNumber);
            Console.WriteLine("New order has been created");
        }
    }
}
