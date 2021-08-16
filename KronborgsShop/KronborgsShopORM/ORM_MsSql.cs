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

        public Address GetAddress(int id)
        {
            Address address = null;

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
                    address = new Address(Convert.ToInt32(reader["Postnummer"]))
                    {
                        //City = reader["Bynavn"].ToString()
                    };
                    i++;
                }
                dbConn.Close();
                reader.Close();
                if (i != 1) return null;
            }

            return address;
        }

        public List<Address> GetAddresses()
        {
            throw new NotImplementedException();
        }

        public Member GetMember()
        {
            throw new NotImplementedException();
        }

        public Member GetMember(int id)
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
                    postnummer = new Postnummer(Convert.ToInt32(reader["Postnummer"]))
                    {
                        City = reader["Bynavn"].ToString()
                    };
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
            List<Postnummer> postnummers = new List<Postnummer>();

            string query = "SELECT Postnummer, Bynavn FROM Postnummer";
            SqlCommand cmd = new SqlCommand(query, dbConn);
            //cmd.Parameters.AddWithValue("@val", id);

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
                while (reader.Read())
                {
                    //customer = new Customer(reader.GetInt32(0), reader.GetString(1));
                    postnummers.Add(new Postnummer(Convert.ToInt32(reader["Postnummer"]))
                    {
                        City = reader["Bynavn"].ToString()
                    });
                }
                dbConn.Close();
                reader.Close();
            }

            return postnummers;
        }

        public Product GetProduct(int id)
        {
            Product product = null;

            string query = "SELECT ProduktID, ProduktNavn, Prise FROM Produkt WHERE ProduktID = @val";
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
                    product = new Product(Convert.ToInt32(reader["ProduktID"]))
                    {
                        Name = reader["ProduktNavn"].ToString(),
                        Price = Convert.ToDouble(reader["Prise"])
                    };
                    i++;
                }
                dbConn.Close();
                reader.Close();
                if (i != 1) return null;
            }

            return product;
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();


            string query = "SELECT ProduktID, ProduktNavn, Prise FROM Produkt";
            SqlCommand cmd = new SqlCommand(query, dbConn);
            //cmd.Parameters.AddWithValue("@val", id);

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
                    products.Add(new Product(Convert.ToInt32(reader["ProduktID"]))
                    {
                        Name = reader["ProduktNavn"].ToString(),
                        Price = Convert.ToDouble(reader["Prise"])
                    });
                    i++;
                }
                dbConn.Close();
                reader.Close();
                if (i != 1) return null;
            }

            return products;
        }
    }
}
