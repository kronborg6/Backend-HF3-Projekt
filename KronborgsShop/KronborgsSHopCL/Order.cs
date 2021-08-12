using System;
using System.Collections.Generic;

using System.Data;
using System.Data.SqlClient;

namespace KronborgsSHopCL
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime OpretDate { get; set; }
        public List<Product> Products { get; set; }
    }
}
 