using KronborgsSHopCL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace KronborgsShopORM
{
    public class ORM_MsSql : IORM
    {
        private readonly SqlConnection dbConn;
        private string host = "DESKTOP-ESAG33B";
        private string username = "KronborgsShop";
        private string password = "KronborgsShop";
        private string database = "BackendStoreDB";


        public ORM_MsSql()
        {
            SqlConnectionStringBuilder conString = new SqlConnectionStringBuilder()
            {
                InitialCatalog = database,
                UserID = username,
                Password = password,
                DataSource = host

            };

            dbConn = new SqlConnection(conString.ToString());
        }
        public Address GetAddress()
        {
            throw new NotImplementedException();
        }

        public List<Address> GetAddresses()
        {
            throw new NotImplementedException();
        }

        public Member GetMember()
        {
            throw new NotImplementedException();
        }

        public List<Member> GetMembers()
        {
            throw new NotImplementedException();
        }

        public Order GetOrder()
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrders()
        {
            throw new NotImplementedException();
        }

        public Postnummer GetPostnummer(int id)
        {
            Postnummer postnummer = null;

            string query = "SELECT Postnummer, Bynavn FROM Postnummer WHERE Postnummer = @val";
            SqlCommand cmd = new SqlCommand(query, dbConn);
            cmd.Parameters.AddWithValue("@val", id);

            if (dbConn.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    // open database connection
                    dbConn.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                int i = 0;
                while (reader.Read())
                {
                    postnummer = new Postnummer(reader.GetInt32(0), reader.GetString(1));
                    i++;
                }
                dbConn.Close();
                reader.Close();
                if (i != 1) return null;
            }

            return postnummer;
        }

        public List<Postnummer> GetPostnummers()
        {
            throw new NotImplementedException();
        }

        public Product GetProduct()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
