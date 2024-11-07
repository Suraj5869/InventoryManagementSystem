using InventoryApp.Data;
using InventoryApp.Exceptions;
using InventoryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Repositories
{
    internal class SupplierRepository
    {
        private InventoryContext _inventoryContext;

        public SupplierRepository()
        {
            _inventoryContext = new InventoryContext();
        }

        //Add the new supplier in database
        internal void AddSupplier(Supplier supplier)
        {
            _inventoryContext.suppliers.Add(supplier);
            _inventoryContext.SaveChanges();
        }

        //check if the supplier is already exist or not
        internal void CheckSupplier(Supplier supplier)
        {
            foreach (var supplier1 in _inventoryContext.suppliers)
            {
                CompareSuppliers(supplier1, supplier);
            }
        }

        //compare the supplier data with other suppliers present in database
        private void CompareSuppliers(Supplier supplier1, Supplier supplier)
        {
            if (supplier1.Id == supplier1.Id && supplier1.Name == supplier.Name && supplier1.Email == supplier.Email && supplier1.InventoryId == supplier.InventoryId)
            {
                throw new DuplicateSupplierException("Supplier is already exist!!\n");
            }
        }

        //get the list of suppliers present in database
        internal List<Supplier> GetAllSuppliers()
        {
            var suppliers = _inventoryContext.suppliers.ToList();
            return suppliers;
        }

        //Get the supplier by its id if it is not exist then throws an exception
        internal Supplier GetById(int id)
        {
            var supplier = _inventoryContext.suppliers.FirstOrDefault(s => s.Id == id);
            if (supplier != null)
            {
                return supplier;
            }
            throw new InvalidSupplierException("No such supplier exist!!");
        }

        //Get the supplier by its name if it is not exist then throws an exception
        internal Supplier GetByName(string? name)
        {
            var supplier = _inventoryContext.suppliers.FirstOrDefault(s => s.Name == name);
            if (supplier != null)
            {
                return supplier;
            }
            throw new InvalidSupplierException("No such supplier exist!!");
        }

        //delete the specific supplier from the database
        internal void RemoveSupplier(Supplier supplier)
        {
            _inventoryContext.suppliers.Remove(supplier);
            _inventoryContext.SaveChanges();
        }

        //Update the supplier details in dstabase
        internal void UpdateSupplier(Supplier supplier, string name, string email, int id)
        {
            supplier.Name = name;
            supplier.Email = email;
            supplier.InventoryId = id;
            _inventoryContext.SaveChanges();
        }
    }
}
