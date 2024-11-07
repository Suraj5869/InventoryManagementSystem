using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Exceptions
{
    internal class DuplicateSupplierException:Exception
    {
        public DuplicateSupplierException(string msg):base(msg) 
        {
            
        }
    }
}
