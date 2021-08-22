using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KronborgsSHopCL
{
    public class Address // : EntityBase
    {
        public int AddressID { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public Postnummer postnummer { get; set; }


        [JsonConstructor]
        public Address(string streetName, string streetNumber)
        {
            StreetName = streetName;
            StreetNumber = streetNumber;
            //postnummer.PostnummerID = postnummerID;
        }

        //public Address() : this(0)
        //{

        //}
        public Address(Postnummer postnummer)
        {
            this.postnummer = postnummer;
        }

        //public override bool Validate()
        //{
        //    throw new NotImplementedException();
        //}
        public void SetAddressID(int id)
        {
            AddressID = id;
        }
    }
}
