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
    internal class ProductRepository
    {
        private InventoryContext _inventoryContext;

        public ProductRepository()
        {
            _inventoryContext = new InventoryContext();
        }

        internal Product GetProduct(string name)
        {
            var product = _inventoryContext.products.FirstOrDefault(product => product.Name == name);
            if (product != null)
            {
                return product;
            }
            return null;
        }

        public void AddProduct(Product product)
        {
            _inventoryContext.products.Add(product);
            _inventoryContext.SaveChanges();
        }

        internal Product GetByName(string name)
        {
            var product = _inventoryContext.products.FirstOrDefault(product => product.Name == name);
            if (product != null)
            {
                return product;
            }
            throw new InvalidProductException("No such product exist!!");
        }

        internal Product GetById(int id)
        {
            var product = _inventoryContext.products.FirstOrDefault(product => product.Id == id);
            if (product != null)
            {
                return product;
            }
            throw new InvalidProductException("No such product exist!!");
        }

        internal List<Product> GetAllProducts()
        {
            var products = _inventoryContext.products.ToList();
            return products;
        }

        internal void RemoveProduct(Product product)
        {
            _inventoryContext.products.Remove(product);
            _inventoryContext.SaveChanges();
        }

        internal void CheckProductExist(string name)
        {
            Product oldProduct = GetProduct(name);
            if (oldProduct != null)
            {
                throw new DuplicateProductException("Product is already exist!!\n");
            }
        }
    }
}
