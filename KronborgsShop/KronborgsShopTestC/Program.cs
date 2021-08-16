using KronborgsSHopCL;
using KronborgsShopORM;
using System;
using System.Collections.Generic;

namespace KronborgsShopTestC
{
    class Program
    {
        static void Main(string[] args)
        {
            ORM_MsSql ORM = new ORM_MsSql();
            Postnummer cust1 = ORM.GetPostnummer(5690);
            //customers = ORM.GetCustomers();
            Console.WriteLine(cust1.PostnummerID + ": " + cust1.City);
            Console.WriteLine("\n");

            List<Postnummer> postnummers = new List<Postnummer>();
            postnummers = ORM.GetPostnummers();

            foreach (Postnummer postnummer in postnummers)
            {
                Console.WriteLine(postnummer.PostnummerID + ": " + postnummer.City);
            }

        }
    }
}
