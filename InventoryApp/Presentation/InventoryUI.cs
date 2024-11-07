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
    internal class InventoryUI
    {
        static InventoryRepository inventoryRepository = new InventoryRepository();

        //It collect all the data of repository and make the report 
        public static void MakeReport()
        {

            Console.WriteLine("Enter the inventory Id:");
            int id = int.Parse(Console.ReadLine());
            try
            {
                //Checks if the inventory of specified id exist or not
                //if not exist then throw the exception
                inventoryRepository.CheckInventory(id);
                
                //collect the available products in the inventory
                var inventoryProducts = inventoryRepository.GetInventoryProducts(id);
                //collect the available suppliers in the inventory
                var inventorySuppliers = inventoryRepository.GetAllSuppliers(id);
                //collect the transactions done in the inventory
                var inventoryTransactions = inventoryRepository.GetAllTransactions(id);
                //It calculate the total cost of the products present in the inventory
                double totalCost = GetTotalPrice(inventoryProducts);

                PrintReport(inventoryProducts, inventorySuppliers, inventoryTransactions, totalCost);
            }
            catch(InvalidInventoryException ie)
            {
                Console.WriteLine(ie.Message);
            }
        }

        //the method print the data given by above method
        private static void PrintReport(Inventory inventoryProducts, Inventory inventorySuppliers, Inventory inventoryTransactions, double totalCost)
        {
            Console.WriteLine("Inventory Details:\n" +
                    $"Inventory Id: {inventoryTransactions.Id}\n" +
                    $"Inventory Location: {inventoryTransactions.Location}\n" +
                    $"Products available in inventory: {inventoryProducts.Products.Count}\n" +
                    $"Total stock value: {totalCost}\n" +
                    $"~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            Console.WriteLine("Product List");
            foreach (var product in inventoryProducts.Products)
            {
                Console.WriteLine(product);
                Console.WriteLine("-------------------------------");
            }
            Console.WriteLine("===============================");

            Console.WriteLine("Supplier List");
            foreach (var supplier in inventorySuppliers.Suppliers)
            {
                Console.WriteLine(supplier);
                Console.WriteLine("--------------------------------");
            }
            Console.WriteLine("================================");

            Console.WriteLine("Transaction List");
            Console.WriteLine("Transaction Id\tProduct Id\tType\tQuantity\tDate & Time\t\tInventory Id");
            foreach (var transaction in inventoryTransactions.Transactions)
            {
                Console.WriteLine(transaction);
            }
            Console.WriteLine("========================================================================================\n");
        }

        private static double GetTotalPrice(Inventory inventoryProducts)
        {
            double totalCost = 0;
            foreach (var product in inventoryProducts.Products)
            {
                totalCost += (product.Quantity * product.Price);
            }
            return totalCost;
        }
    }
}
