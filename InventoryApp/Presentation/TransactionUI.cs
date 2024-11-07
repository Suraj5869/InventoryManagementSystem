using InventoryApp.Exceptions;
using InventoryApp.Models;
using InventoryApp.Repositories;
using InventoryApp.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Presentation
{
    internal class TransactionUI
    {
        static MainUI mainUI = new MainUI();
        static ProductRepository productRepository = new ProductRepository();
        static TransactionRepository transactionRepository = new TransactionRepository();
        internal static void TransactionMenu()
        {
            while (true)
            {
                Console.WriteLine("-----> Transaction Menu <-----\n" +
                    "1. Add Stock\n" +
                    "2. Remove Stock\n" +
                    "3. View Transaction\n" +
                    "4. Go Back to Main Menu\n");
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
                    AddStock();
                    break;
                case 2:
                    RemoveStock();
                    break;
                case 3:
                    ViewTransacions();
                    break;
                case 4:
                    mainUI.AppUI();
                    break;
                default:
                    Console.WriteLine("Choose a correct option!!!\n");
                    break;
            }
        }

        //show the transactions of the specific product 
        private static void ViewTransacions()
        {
            Console.WriteLine("Enter the product name:");
            string name = Console.ReadLine();
            try
            {
                Product product = productRepository.GetByName(name);//Get the product if it is exist else get an exception
                var transactions = transactionRepository.GetAllTransactions(product);//Get all the transactions of the specific product
                Console.WriteLine("Transaction Id\tProduct Id\tType\tQuantity\tDate & Time\t\tInventory Id");
                PrintTransactions(transactions);
            }
            catch (InvalidProductException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void PrintTransactions(List<Transaction> transactions)
        {
            foreach (var transaction in transactions)
            {
                Console.WriteLine(transaction);
            }
        }

        //Remove the specific quantity of stock from the database
        private static void RemoveStock()
        {
            Console.WriteLine("Enter the product name:");
            string name = Console.ReadLine();

            try
            {
                Product product = productRepository.GetByName(name);//Get the product if it is exist else get an exception
                var productData = transactionRepository.GetProduct(product);//Get all the data of product along with inventory
                Console.WriteLine("Enter the amount of quantity to remove:");
                int quantity = int.Parse(Console.ReadLine());
                transactionRepository.CheckStock(productData, quantity);//checks if the sufficient amount of product is available or not
                productData.Quantity -= quantity;

                Transaction transaction = new Transaction { ProductId = productData.Id, Type = TransactionType.REMOVE, Quantity = quantity, Date = DateTime.Now, InventoryId = productData.InventoryId };
                transactionRepository.AddTransaction(transaction);
            }
            catch (InvalidProductException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(InsufficientStockException ie)
            {
                Console.WriteLine(ie.Message);
            }
        }

        //Add the stock in the inventory
        private static void AddStock()
        {
            Console.WriteLine("Enter the product name:");
            string name = Console.ReadLine();

            try
            {
                Product product = productRepository.GetByName(name);//Get the product if it is exist else get an exception
                var productData = transactionRepository.GetProduct(product);//Get all the data of product along with inventory
                Console.WriteLine("Enter the amount of quantity to add:");
                int quantity = int.Parse(Console.ReadLine());
                productData.Quantity += quantity;

                Transaction transaction = new Transaction { ProductId = productData.Id, Type = TransactionType.ADD, Quantity = quantity, Date = DateTime.Now, InventoryId=productData.InventoryId };
                transactionRepository.AddTransaction(transaction);
            }
            catch (InvalidProductException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
