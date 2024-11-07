using InventoryApp.Data;
using InventoryApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Repositories
{
    internal class TransactionRepository
    {
        private InventoryContext _inventoryContext;

        public TransactionRepository()
        {
            _inventoryContext = new InventoryContext();
        }
        internal void AddTransaction(Transaction transaction)
        {
            _inventoryContext.transactions.Add(transaction);
            _inventoryContext.SaveChanges();
        }

        public Product GetProduct(Product product)
        {
            var products = _inventoryContext.products.Include(i=>i.Inventory).ToList();
            return products.Find(i=>i.Id == product.Id);
        }
        internal List<Transaction> GetAllTransactions(Product product)
        {
            List<Transaction> productTransactions = new List<Transaction>();
            foreach (var transaction in _inventoryContext.transactions)
            {
                if(transaction.ProductId == product.Id)
                    productTransactions.Add(transaction);
            }
            return productTransactions;
        }
    }
}
