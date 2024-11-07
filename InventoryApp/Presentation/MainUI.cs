using InventoryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Presentation
{
    internal class MainUI
    {
        public void AppUI()
        {
            Console.WriteLine("Welcome to Inventory Management System");
            while (true)
            {
                Console.WriteLine($"1. Product Management\n" +
                    $"2. Supplier Management\n" +
                    $"3. Transaction Management\n" +
                    $"4. Generate Report\n" +
                    $"5. Exit\n");
                Console.WriteLine("Enter your choice:");
                int choice = int.Parse(Console.ReadLine());
                SwitchMenu(choice);
            }
        }

        private void SwitchMenu(int choice)
        {
            switch (choice)
            {
                case 1:
                    ProductUI.ProductMenu();
                    break;
                case 2:
                    SupplierUI.SupplierMenu();
                    break;
                case 3:
                    TransactionUI.TransactionMenu();
                    break;
                case 4:
                    InventoryUI.MakeReport();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Enter the correct choice!!!\n");
                    break;
            }
        }
    }
}
