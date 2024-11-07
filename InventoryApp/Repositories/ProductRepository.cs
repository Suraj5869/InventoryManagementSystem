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

        //Get the product details by its name if not exist then return null
        internal Product GetProduct(string name)
        {
            var product = _inventoryContext.products.FirstOrDefault(product => product.Name == name);
            if (product != null)
            {
                return product;
            }
            return null;
        }

        //Add product in the database
        public void AddProduct(Product product)
        {
            _inventoryContext.products.Add(product);
            _inventoryContext.SaveChanges();
        }

        //Get product by its name from the database if it is not exist then throws an exception
        internal Product GetByName(string name)
        {
            var product = _inventoryContext.products.FirstOrDefault(product => product.Name == name);
            if (product != null)
            {
                return product;
            }
            throw new InvalidProductException("No such product exist!!");
        }

        //Get product by its id from the database if it is not exist then throws an exception
        internal Product GetById(int id)
        {
            var product = _inventoryContext.products.FirstOrDefault(product => product.Id == id);
            if (product != null)
            {
                return product;
            }
            throw new InvalidProductException("No such product exist!!");
        }

        //Return list of products available in database
        internal List<Product> GetAllProducts()
        {
            var products = _inventoryContext.products.ToList();
            return products;
        }

        //Delete the product from database
        internal void RemoveProduct(Product product)
        {
            _inventoryContext.products.Remove(product);
            _inventoryContext.SaveChanges();
        }

        //checks if the product is already exist in database or not
        internal void CheckProductExist(string name)
        {
            Product oldProduct = GetProduct(name);
            if (oldProduct != null)
            {
                throw new DuplicateProductException("Product is already exist!!\n");
            }
        }

        //Update the data of the product
        internal void UpdateProduct(Product product, string name, string? description, double price)
        {
            product.Name = name;
            product.Description = description;
            product.Price = price;
            _inventoryContext.SaveChanges();
        }
    }
}
