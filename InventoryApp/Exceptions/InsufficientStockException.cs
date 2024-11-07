using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Exceptions
{
    class InsufficientStockException:Exception
    {
        public InsufficientStockException(string msg):base(msg)
        {
            
        }
    }
}
