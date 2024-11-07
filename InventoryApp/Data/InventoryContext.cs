using InventoryApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Data
{
    internal class InventoryContext:DbContext
    {
        public DbSet<Product> products {  get; set; }
        public DbSet<Supplier> suppliers { get; set; }
        public DbSet<Transaction> transactions { get; set; }
        public DbSet<Inventory> inventories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.AppSettings["connString"]);
        }
    }
}
