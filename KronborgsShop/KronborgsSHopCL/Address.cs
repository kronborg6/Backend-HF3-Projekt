using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronborgsSHopCL
{
    public class Address : EntityBase
    {
        public int AddressID { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }

        public Address() : this(0)
        {

        }
        public Address(int AddressID)
        {
            if (AddressID == 0)
            {

            }
        }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
