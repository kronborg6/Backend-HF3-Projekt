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

            ORM.EditProduct(3, "Fanta", 21);

            //Postnummer cust1 = ORM.GetPostnummer(5690);
            //customers = ORM.GetCustomers();
            //Console.WriteLine(cust1.PostnummerID + ": " + cust1.City);
            //Console.WriteLine("\n");

            //List<Product> products = new List<Product>();
            //products = ORM.GetProducts();

            //foreach (Product product in products)
            //{
            //    Console.WriteLine(product.ProductID + ": " + product.Name + "Price: " + product.Price);
            //}

            //List<Postnummer> postnummers = new List<Postnummer>();
            //postnummers = ORM.GetPostnummers();

            //foreach (Postnummer postnummer in postnummers)
            //{
            //    Console.WriteLine(postnummer.PostnummerID + ": " + postnummer.City);
            //}

            //List<Address> addresses = new List<Address>();
            //addresses = ORM.GetAddress(1);
            //Address address = null;
            //address = ORM.GetAddress(1);


            //Console.WriteLine("");

            //Member member = null;

            //Postnummer postnummer = null;
            //Address address = null;

            //postnummer = new Postnummer(5690)
            //{
            //    City = "Tommerup"
            //};
            //address = new Address(postnummer)
            //{
            //    StreetName = "Skovstrupvej",
            //    StreetNumber = "46",
            //    AddressID = 1
            //};
            //member = new Member(1, address)
            //{
            //    Fristname = "Mikkel",
            //    Lastname = "Kronborg",
            //    Email = "mkronborg7@gmail.com",
            //    Mobil = 60677407
            //};


            //ORM.CreateAddress(address);


            //member = ORM.GetMember(1);
            //Console.WriteLine("ID: {0} Fristname: {1} Lastname: {2} Mobil: {3} Email: {4} Vejnavn: {5} Vejnummer {6}",
            //    member.MemberID, member.Fristname, member.Lastname, member.Mobil, member.Email, member.Address.StreetName, member.Address.StreetNumber);

            //Console.WriteLine("ID: {0} Postnummer: {1} By: {2} Gade: {3} Nummer: {4}", address.AddressID, address.postnummer.PostnummerID, address.postnummer.City, address.StreetName, address.StreetNumber);

        }
    }
}
