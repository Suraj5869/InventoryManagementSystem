using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Exceptions
{
    internal class InvalidInventoryException:Exception
    {
        public InvalidInventoryException(string msg):base(msg) 
        {
            
        }
    }
}
