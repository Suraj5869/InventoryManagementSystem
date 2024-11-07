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

        public static void MakeReport()
        {
            Console.WriteLine("Enter the inventory Id:");
            int id = int.Parse(Console.ReadLine());
            try
            {
                inventoryRepository.CheckInventory(id);
                
                var inventoryProducts = inventoryRepository.GetInventoryProducts(id);
                var inventorySuppliers = inventoryRepository.GetAllSuppliers(id);
                var inventoryTransactions = inventoryRepository.GetAllTransactions(id);
                double totalCost = GetTotalPrice(inventoryProducts);

                PrintReport(inventoryProducts, inventorySuppliers, inventoryTransactions, totalCost);
            }
            catch(InvalidInventoryException ie)
            {
                Console.WriteLine(ie.Message);
            }
        }

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
