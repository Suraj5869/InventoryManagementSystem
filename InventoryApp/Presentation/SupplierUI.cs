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
    internal class SupplierUI
    {
        static MainUI mainUI = new MainUI();
        static SupplierRepository supplierRepository = new SupplierRepository();
        static InventoryRepository inventoryRepository = new InventoryRepository();
        internal static void SupplierMenu()
        {
            while (true)
            {
                Console.WriteLine("-----> Supplier Menu <-----\n" +
                    "1. Add Supplier\n" +
                    "2. Update Supplier\n" +
                    "3. Delete Supplier\n" +
                    "4. View Supplier's Details\n" +
                    "5. View All Suppliers\n" +
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
                    AddSupplier();
                    break;
                case 2:
                    UpdateSupplier();
                    break;
                case 3:
                    DeleteSupplier();
                    break;
                case 4:
                    ViewSupplier();
                    break;
                case 5:
                    ShowAllSuppliers();
                    break;
                case 6:
                    mainUI.AppUI();
                    break;
                default:
                    Console.WriteLine("Choose a correct option!!!\n");
                    break;
            }
        }

        private static void ShowAllSuppliers()
        {
            var suppliers = supplierRepository.GetAllSuppliers();
            foreach (var supplier in suppliers)
            {
                Console.WriteLine(supplier);
                Console.WriteLine("~~~~~~~~~~~~~~~~");
            }
        }

        private static void ViewSupplier()
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
            Console.WriteLine("Enter name of supplier:");
            string name = Console.ReadLine();
            try
            {
                Supplier supplier = supplierRepository.GetByName(name);
                Console.WriteLine(supplier);
            }
            catch (InvalidSupplierException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void SearchById()
        {
            Console.WriteLine("Enter supplier Id:");
            int id = int.Parse(Console.ReadLine());
            try
            {
                Supplier supplier = supplierRepository.GetById(id);
                Console.WriteLine(supplier);
            }
            catch (InvalidSupplierException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void DeleteSupplier()
        {
            Console.WriteLine("Enter supplier Name:");
            string name = Console.ReadLine();
            try
            {
                Supplier supplier = supplierRepository.GetByName(name);
                supplierRepository.RemoveSupplier(supplier);
                Console.WriteLine("Supplier deleted successfully.");
            }
            catch (InvalidSupplierException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void UpdateSupplier()
        {
            Console.WriteLine("Enter supplier Name:");
            string name = Console.ReadLine();
            try
            {
                Supplier supplier = supplierRepository.GetByName(name);
                GetSupplierDetails(supplier);
            }
            catch (InvalidSupplierException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void GetSupplierDetails(Supplier supplier)
        {
            Console.WriteLine("Enter new supplier name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter new supplier email:");
            string email = Console.ReadLine();
            Console.WriteLine("Enter new inventory id:");
            int id = int.Parse(Console.ReadLine());

            
            try
            {
                inventoryRepository.CheckInventory(id);
                Supplier supplier1 = new Supplier { Name = name, Email = email, InventoryId = id };
                supplierRepository.CheckSupplier(supplier1);
                supplier.Name = name;
                supplier.Email = email;
                supplier.InventoryId = id;
                Console.WriteLine("Supplier updated Successfully!!");
            }
            catch (DuplicateSupplierException de)
            {
                Console.WriteLine(de.Message);
            }
            catch(InvalidInventoryException ie)
            {
                Console.WriteLine(ie.Message);
            }
        }

        private static void AddSupplier()
        {
            Console.WriteLine("Enter name of the supplier:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter supplier email:");
            string email = Console.ReadLine();
            Console.WriteLine("Enter inventory id:");
            
            try
            {
                int id = int.Parse(Console.ReadLine());
                inventoryRepository.CheckInventory(id);

                Supplier supplier = new Supplier { Name = name, Email = email, InventoryId = id };
                supplierRepository.CheckSupplier(supplier);
                supplierRepository.AddSupplier(supplier);
                Console.WriteLine("Supplier Added Successfully!!");
            }
            catch(DuplicateSupplierException de)
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
