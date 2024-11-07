using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryApp.Type;

namespace InventoryApp.Models
{
    internal class Transaction
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public TransactionType Type { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }

       
        public Inventory Inventory { get; set; }

        [ForeignKey("Inventory")]
        public int InventoryId { get; set; }

        public override string ToString()
        {
            return $"{Id}\t\t{ProductId}\t\t{Type}\t{Quantity}\t\t{Date}\t{InventoryId}";
        }
    }
}
