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
        public Member GetMember(int id);
        public List<Address> GetAddresses();
        public Address GetAddress(int id);
        public List<Product> GetProducts();
        public Product GetProduct(int id);
        public List<Postnummer> GetPostnummers();
        public Postnummer GetPostnummer(int id);
        public List<Order> GetOrders();
        public Order GetOrder();
        //public 

    }
}
