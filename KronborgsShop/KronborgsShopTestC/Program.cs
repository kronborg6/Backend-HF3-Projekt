using KronborgsSHopCL;
using KronborgsShopORM;
using System;

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
        }
    }
}
