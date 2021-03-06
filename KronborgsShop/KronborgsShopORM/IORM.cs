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
        public Member CreateMember(Member member);
        public void DeleteMember(int id);
        public Member EditMember(int id, string Fristname, string Lastname, string Email, int Mobil);
        public List<Address> GetAddresses();
        public Address GetAddress(int id);
        public Address CreateAddress(Address address);
        public Address EditAddress(int id, int postnummer, string Streetname, string Steetnumber);
        public void DeleteAddress(int id);
        public List<Product> GetProducts();
        public Product GetProduct(int id);
        public Product CreateProduct(Product product);
        public Product EditProduct(int id, string Name, int Price);
        public void DeleteProduct(int id);
        public List<Postnummer> GetPostnummers();
        public Postnummer GetPostnummer(int id);
        public List<Order> GetOrders();
        public Order GetOrder();
    }
}
