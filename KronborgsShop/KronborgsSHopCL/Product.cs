using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KronborgsSHopCL
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        //public Product() : this(0)
        //{

        //}
        [JsonConstructor]
        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }
        public Product(int id)
        {
            this.ProductID = id;
        }
        public void SetProductID(int id)
        {
            ProductID = id;
        }

    }
}
