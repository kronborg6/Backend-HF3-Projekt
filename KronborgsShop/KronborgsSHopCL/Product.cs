using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronborgsSHopCL
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Product() : this(0)
        {

        }
        public Product(int id)
        {
            this.ProductID = id;
        }
    }
}
