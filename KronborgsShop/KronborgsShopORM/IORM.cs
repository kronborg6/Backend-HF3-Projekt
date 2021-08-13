using KronborgsSHopCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronborgsShopORM
{
    public interface IORM
    {
        public List<Member> GetMembers();
        public Member GetMember();
        public List<Address> GetAddresses();
        public Address GetAddress();
        public List<Product> GetProducts();
        public Product GetProduct();
        public List<Postnummer> GetPostnummers();
        public Postnummer GetPostnummer(int id);
        public List<Order> GetOrders();
        public Order GetOrder();
        //public 

    }
}
