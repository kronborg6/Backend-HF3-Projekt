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
        public Postnummer() : this(0)
        {

        }
        public Postnummer(int ID)
        {
            this.PostnummerID = ID;
        }
    }
}
