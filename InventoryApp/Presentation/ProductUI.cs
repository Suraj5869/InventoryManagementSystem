using InventoryApp.Exceptions;
using InventoryApp.Models;
using InventoryApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Presentation
{
    internal class ProductUI
    {
        static MainUI mainUI = new MainUI();
        static ProductRepository productRepository = new ProductRepository();
        static InventoryRepository inventoryRepository = new InventoryRepository();
        internal static void ProductMenu()
        {
            while (true)
            {
                Console.WriteLine("-----> Product Menu <-----\n" +
                    "1. Add Product\n" +
                    "2. Update Product\n" +
                    "3. Delete Product\n" +
                    "4. View Product Details\n" +
                    "5. View All Products\n" +
                    "6. Go Back to Main Menu\n");
                Console.WriteLine("Enter your choice:");
                int choice = int.Parse(Console.ReadLine());
                SwitchMenu(choice);
            }
        }

        private static void SwitchMenu(int choice)
        {
            switch (choice)
            {
                case 1:
                    AddProduct();
                    break;
                case 2:
                    UpdatePoduct();
                    break;
                case 3:
                    DeleteProduct();
                    break;
                case 4:
                    ViewProduct();
                    break;
                case 5:
                    ShowAllProducts();
                    break;
                case 6:
                    mainUI.AppUI();
                    break;
                default:
                    Console.WriteLine("Choose a correct option!!!\n");
                    break;
            }
        }

        private static void ShowAllProducts()
        {
            var products = productRepository.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine(product);
                Console.WriteLine("~~~~~~~~~~~~~~~~");
            }
        }

        private static void ViewProduct()
        {
            Console.WriteLine("How do you want to search:\n" +
                "1. By Id\n" +
                "2. By Name\n");
            Console.WriteLine("Enter your choice:");
            int choice = int.Parse(Console.ReadLine());
            ViewSwitch(choice);
        }

        private static void ViewSwitch(int choice)
        {
            switch (choice)
            {
                case 1:
                    SearchById();
                    break;
                case 2:
                    SearchByName();
                    break;
                default:
                    Console.WriteLine("Select correct option");
                    break;
            }
        }

        private static void SearchByName()
        {
            Console.WriteLine("Enter name of product:");
            string name = Console.ReadLine();
            try
            {
                Product product = productRepository.GetByName(name);
                Console.WriteLine(product);
            }
            catch (InvalidProductException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void SearchById()
        {
            Console.WriteLine("Enter product Id:");
            int id = int.Parse(Console.ReadLine());
            try
            {
                Product product = productRepository.GetById(id);
                Console.WriteLine(product);
            }
            catch (InvalidProductException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void DeleteProduct()
        {
            Console.WriteLine("Enter product Name:");
            string name = Console.ReadLine();
            try
            {
                Product product = productRepository.GetByName(name);
                productRepository.RemoveProduct(product);
                Console.WriteLine("Product deleted successfully.");
            }
            catch (InvalidProductException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void UpdatePoduct()
        {
            Console.WriteLine("Enter product Name:");
            string name = Console.ReadLine();
            try
            {
                Product product = productRepository.GetByName(name);
                GetProductDetails(product);
            }
            catch (InvalidProductException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void GetProductDetails(Product product)
        {
            Console.WriteLine("Enter new product name:");
            string name = Console.ReadLine();
            try
            {
                productRepository.CheckProductExist(name);
                product.Name = name;
                Console.WriteLine("Enter new product description:");
                string description = Console.ReadLine();
                product.Description = description;
                Console.WriteLine("Enter new price of product:");
                double price = double.Parse(Console.ReadLine());
                product.Price = price; Console.WriteLine("Product Added successfully!!\n");
            }
            catch (DuplicateProductException de)
            {
                Console.WriteLine(de.Message);
            }           
        }

        private static void AddProduct()
        {
            Console.WriteLine("Enter name of the product:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter product description:");
            string description = Console.ReadLine();
            Console.WriteLine("Enter product quantity:");
            int quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter price of product:");
            double price = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the inventory Id:");

            try
            {
                int id = int.Parse(Console.ReadLine());
                inventoryRepository.CheckInventory(id);
                Product product = new Product { Name = name, Description = description, Quantity = quantity, Price = price, InventoryId = id };
                productRepository.CheckProductExist(name);
                productRepository.AddProduct(product);
                Console.WriteLine("Product Added successfully!!\n");
            }
            catch(DuplicateProductException de)
            {
                Console.WriteLine(de.Message);
            }
            catch(InvalidInventoryException ie)
            {
                Console.WriteLine(ie.Message);
            }
        }

        
    }
}
