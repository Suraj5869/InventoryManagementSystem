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

        internal void AddSupplier(Supplier supplier)
        {
            _inventoryContext.suppliers.Add(supplier);
            _inventoryContext.SaveChanges();
        }

        internal void CheckSupplier(Supplier supplier)
        {
            foreach (var supplier1 in _inventoryContext.suppliers)
            {
                CompareSuppliers(supplier1, supplier);
            }
        }

        private void CompareSuppliers(Supplier supplier1, Supplier supplier)
        {
            if (supplier1.Id == supplier1.Id && supplier1.Name == supplier.Name && supplier1.Email == supplier.Email && supplier1.InventoryId == supplier.InventoryId)
            {
                throw new DuplicateSupplierException("Supplier is already exist!!\n");
            }
        }

        internal List<Supplier> GetAllSuppliers()
        {
            var suppliers = _inventoryContext.suppliers.ToList();
            return suppliers;
        }

        internal Supplier GetById(int id)
        {
            var supplier = _inventoryContext.suppliers.FirstOrDefault(s => s.Id == id);
            if (supplier != null)
            {
                return supplier;
            }
            throw new InvalidSupplierException("No such supplier exist!!");
        }

        internal Supplier GetByName(string? name)
        {
            var supplier = _inventoryContext.suppliers.FirstOrDefault(s => s.Name == name);
            if (supplier != null)
            {
                return supplier;
            }
            throw new InvalidSupplierException("No such supplier exist!!");
        }

        internal void RemoveSupplier(Supplier supplier)
        {
            _inventoryContext.suppliers.Remove(supplier);
            _inventoryContext.SaveChanges();
        }
    }
}
