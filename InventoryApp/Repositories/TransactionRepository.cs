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
    internal class TransactionRepository
    {
        private InventoryContext _inventoryContext;

        public TransactionRepository()
        {
            _inventoryContext = new InventoryContext();
        }
        //adds the transaction of the product in database
        internal void AddTransaction(Transaction transaction)
        {
            _inventoryContext.transactions.Add(transaction);
            _inventoryContext.SaveChanges();
        }

        //Get the products detail including its inventory details
        public Product GetProduct(Product product)
        {
            var products = _inventoryContext.products.Include(i=>i.Inventory).ToList();
            return products.Find(i=>i.Id == product.Id);
        }

        //get the list of transacations from the database
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

        //checks the sufficient stock is available or not if not then throws an exeption
        internal void CheckStock(Product productData, int quantity)
        {
            if (quantity > productData.Quantity)
            {
                throw new InsufficientStockException("Insufficient stock available!!\n");
            }
        }
    }
}
