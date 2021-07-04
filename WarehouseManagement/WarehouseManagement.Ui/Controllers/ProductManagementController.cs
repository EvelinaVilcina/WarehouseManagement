using System;
using System.Collections.Generic;
using WarehouseManagement.Exeptions;
using WarehouseManagement.Models;
using WarehouseManagement.Services;

namespace WarehouseManagement.Ui
{
    public class ProductManagementController
    {
        private readonly ProductManagementService _service;
        private readonly CorectUserInputHelper _input;

        public ProductManagementController(CorectUserInputHelper corectUserInputHelper, ProductManagementService productManagementService)
        {
            _service = productManagementService;
            _input = corectUserInputHelper;
        }

        public void AddProduct()
        {           
            Product product = new Product()
            {
                Name = _input.GetUserStringInput("Name of the product and color name"),
                Price = _input.GetUserDoubleInput("Price?"),
                ColourCode = _input.GetUserShortInput("Color code?"),
                EanCode = _input.GetUserStringInput("EAN Code?")
            };

            try
            {
                _service.AddProduct(product);
            }
            catch(ProductAlreadyExistsExeption ex)
            {
                Console.WriteLine(ex.Message);                
            }
            Console.WriteLine("Product is saved");
        }

        public void GetAllAvailableProducts()
        {
            Console.WriteLine("List of all Available products");
            IList<Product> products = _service.GetAllAvailableProducts();
            foreach (var product in products)
            {
                Console.WriteLine("Product name is: " + product.Name);
            }
        }          

        public void GetProduct()
        {                        
            try
            {                
                Product product = _service.GetProduct(_input.GetUserStringInput("What is the name of product?"));
                PrintProductDetails(product);
            }
            catch(ProductDoesntExistException ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }
       
        public void ChangePrice()
        {
            string name = _input.GetUserStringInput("Name of the product and color name?");
            double newPrice = _input.GetUserDoubleInput("New price of the object?");
            
            _service.ChangePrice(name, newPrice);
            Product product =_service.GetProduct(name);
            PrintProductDetails(product);
        }
       
        public void AddToStock()
        {
            string name = _input.GetUserStringInput("Name of the product and color name");
            int stock = _input.GetUserIntInput("How many add to stock?");

            _service.AddToStock(name, stock);
            Product product = _service.GetProduct(name);
            Console.WriteLine("New stock is:" + product.Stock);
        }

        public void RemoveFromStock()
        {
            string name = _input.GetUserStringInput("Name of the product and color name");
            int stock = _input.GetUserIntInput("How many remove from stock?");

            _service.RemoveFromStock(name, stock);
            Product product = _service.GetProduct(name);
            Console.WriteLine("New stock is:" + product.Stock);
        }

        public void MarkOutOfStock()
        {
            string name = _input.GetUserStringInput("Name of the product and color name");
            _service.MarkOutOfStock(name);
            Product product = _service.GetProduct(name);
            Console.WriteLine("New stock is:" + product.Stock);
        }

        public void RemoveProduct()
        {
            _service.RemoveProduct(_input.GetUserStringInput("Name of the product and color name"));
            Console.WriteLine("Product is removed");
        }

        private static void PrintProductDetails(Product product)
        {
            Console.WriteLine("Product name:" + product.Name);
            Console.WriteLine("Price:" + product.Price);
            Console.WriteLine("Color code:" + product.ColourCode);
            Console.WriteLine("EAN code:" + product.EanCode);
        }
    }
}
