using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronborgsSHopCL
{
    public class Postnummer
    {
        public int PostnummerID { get; set; }
        public string City { get; set; }
        public Postnummer(int ID, string City)
        {
            this.PostnummerID = ID;
            this.City = City;
        }
    }
}
