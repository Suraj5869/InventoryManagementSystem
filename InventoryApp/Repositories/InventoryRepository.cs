using InventoryApp.Data;
using InventoryApp.Exceptions;
using InventoryApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Repositories
{
    internal class InventoryRepository
    {
        InventoryContext _inventoryContext;
        public InventoryRepository()
        {
            _inventoryContext = new InventoryContext();
        }

        public Inventory CheckInventory(int id)
        {
            var inventory = _inventoryContext.inventories.Find(id);
            if (inventory == null)
            {
                throw new InvalidInventoryException("No such inventory exist!\n");
            }
            return inventory;
        }


        internal Inventory GetInventoryProducts(int id)
        {
            var inventories =  _inventoryContext.inventories.Include(p=>p.Products).ToList();

            var inventory = inventories.Find(i=>i.Id == id);
            return inventory;
        }

        internal Inventory GetAllSuppliers(int id)
        {
            var inventories =  _inventoryContext.inventories.Include(p => p.Suppliers).ToList();
            var inventory = inventories.Find(i => i.Id == id);
            return inventory;
        }

        internal Inventory GetAllTransactions(int id)
        {
            var inventories = _inventoryContext.inventories.Include(p => p.Transactions).ToList();
            var inventory = inventories.Find(i => i.Id == id);
            return inventory;
        }

        
    }
}
