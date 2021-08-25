using KronborgsSHopCL;
using System;
using System.Collections.Generic;
using System.Data;
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


        //public List<Address> GetAddress()
        //{
        //    List<Address> addresses = new List<Address>();


        //    string query = "SELECT Postnummer, Bynavn FROM Postnummer WHERE Postnummer = @val";
        //    SqlCommand cmd = new SqlCommand(query, dbConn);
        //    //cmd.Parameters.AddWithValue("@val", id);

        //    if (dbConn.State == System.Data.ConnectionState.Closed)
        //    {
        //        try
        //        {
        //            // open database connection
        //            dbConn.Open();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }

        //        SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        //        int i = 0;
        //        while (reader.Read())
        //        {
        //            addresses.Add(new Address(Convert.ToInt32(reader["Postnummer"]))
        //            {
        //                StreetName = reader["Bynavn"].ToString(),
        //                StreetNumber = reader["Bynavn"].ToString()
        //            });
        //            i++;
        //        }
        //        dbConn.Close();
        //        reader.Close();
        //        if (i != 1) return null;
        //    }

        //    return addresses;
        //}

        public Address GetAddress(int id)
        {
            Address address = null;

            string query = "SELECT dbo.Adresse.AdresseID, dbo.Adresse.VejNavn, dbo.Adresse.Vejnummer, dbo.Postnummer.Postnummer, dbo.Postnummer.Bynavn";
            query += " FROM dbo.Adresse INNER JOIN";
            query += " dbo.Postnummer ON dbo.Adresse.Postnummer = dbo.Postnummer.Postnummer";
            query += " WHERE dbo.Adresse.AdresseID = @val";

            //string query = "SELECT id, navn, pris FROM produkt WHERE id = @val";


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
                Postnummer postnummer = null;
                if (reader.Read())
                {

                    postnummer = new Postnummer(Convert.ToInt32(reader["Postnummer"]))
                    {
                        City = reader["Bynavn"].ToString()
                    };



                    address = new Address(postnummer, Convert.ToInt32(reader["AdresseID"]))
                    {
                        AddressID = Convert.ToInt32(reader["AdresseID"]),
                        StreetName = reader["VejNavn"].ToString(),
                        StreetNumber = reader["Vejnummer"].ToString()
                    };
                }
                dbConn.Close();
                reader.Close();
            }

            return address;
        }

        public List<Address> GetAddresses()
        {
            List<Address> addresses = new List<Address>();
            //List<Postnummer> postnummers = new List<Postnummer>();
            Postnummer postnummer = null;


            string query = "SELECT dbo.Adresse.AdresseID, dbo.Adresse.VejNavn, dbo.Adresse.Vejnummer, dbo.Postnummer.Postnummer, dbo.Postnummer.Bynavn";
            query += " FROM dbo.Adresse INNER JOIN";
            query += " dbo.Postnummer ON dbo.Adresse.Postnummer = dbo.Postnummer.Postnummer";
            //query += " WHERE dbo.Adresse.AdresseID = @val";
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
                    postnummer = new Postnummer(Convert.ToInt32(reader["Postnummer"]))
                    {
                        City = reader["Bynavn"].ToString()
                    };
                    addresses.Add(new Address(postnummer, Convert.ToInt32(reader["AdresseID"]))
                    {
                        AddressID = Convert.ToInt32(reader["AdresseID"]),
                        StreetName = reader["VejNavn"].ToString(),
                        StreetNumber = reader["Vejnummer"].ToString()
                    });
                    postnummer = null;

                    i++;
                }
                dbConn.Close();
                reader.Close();
                //if (i != 1) return null;
            }

            return addresses;
        }
        public Address CreateAddress(Address address)
        {
            string query = "INSERT INTO Adresse (VejNavn, Vejnummer, Postnummer) VALUES (@val1, @val2, @val3); SELECT SCOPE_IDENTITY() AS id;";
            SqlCommand cmd = new SqlCommand(query, dbConn);
            cmd.Parameters.AddWithValue("@val1", address.StreetName);
            cmd.Parameters.AddWithValue("@val2", address.StreetNumber);
            cmd.Parameters.AddWithValue("@val3", address.postnummer.PostnummerID);
            //cmd.Parameters.AddWithValue("@val4", address.Mobil);
            //cmd.Parameters.AddWithValue("@val2", product.Price);

            if (dbConn.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    dbConn.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            address.SetAddressID(Convert.ToInt32(cmd.ExecuteScalar()));
            dbConn.Close();

            return address;
        }
        public void DeleteAddress(int id)
        {
            string query = "DELETE FROM Adresse WHERE AdresseID = @val";
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
                cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                dbConn.Close();
            }
        }

        public Member GetMember(int id)
        {
            Member member = null;

            string query = "SELECT dbo.Kunder.KundeID, dbo.Kunder.Fornavn, dbo.Kunder.Efternavn, dbo.Kunder.Mobil, dbo.Kunder.Email, dbo.Adresse.VejNavn, dbo.Adresse.Vejnummer, dbo.Postnummer.Postnummer, dbo.Postnummer.Bynavn, dbo.Adresse.AdresseID";
            query += " FROM dbo.Adresse INNER JOIN";
            query += " dbo.Postnummer ON dbo.Adresse.Postnummer = dbo.Postnummer.Postnummer INNER JOIN";
            query += " dbo.Kunder ON dbo.Adresse.AdresseID = dbo.Kunder.AdresseID";
            query += " WHERE  dbo.Kunder.KundeID = @val";
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
                    Postnummer postnummer = null;
                    Address address = null;

                    postnummer = new Postnummer(Convert.ToInt32(reader["Postnummer"]))
                    {
                        City = reader["Bynavn"].ToString()
                    };
                    address = new Address(postnummer, Convert.ToInt32(reader["AdresseID"]))
                    {
                        //AddressID = Convert.ToInt32(reader["AdresseID"]),
                        StreetName = reader["VejNavn"].ToString(),
                        StreetNumber = reader["Vejnummer"].ToString()
                    };

                    member = new Member(Convert.ToInt32(reader["KundeID"]))
                    {
                        Fristname = reader["Fornavn"].ToString(),
                        Lastname = reader["Efternavn"].ToString(),
                        Email = reader["Email"].ToString(),
                        Mobil = Convert.ToInt32(reader["Mobil"]),
                        Address = address
                    };
                    i++;
                    postnummer = null;
                    address = null;
                }
                dbConn.Close();
                reader.Close();
                if (i != 1) return null;
            }

            return member;
        }
        public List<Member> GetMembers()
        {
            List<Member> members = new List<Member>();
            Postnummer postnummer = null;
            Address address = null;


            string query = "SELECT dbo.Kunder.KundeID, dbo.Kunder.Fornavn, dbo.Kunder.Efternavn, dbo.Kunder.Mobil, dbo.Kunder.Email, dbo.Adresse.VejNavn, dbo.Adresse.Vejnummer, dbo.Postnummer.Postnummer, dbo.Postnummer.Bynavn, dbo.Adresse.AdresseID";
            query += " FROM dbo.Adresse INNER JOIN";
            query += " dbo.Postnummer ON dbo.Adresse.Postnummer = dbo.Postnummer.Postnummer INNER JOIN";
            query += " dbo.Kunder ON dbo.Adresse.AdresseID = dbo.Kunder.AdresseID";
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
                    postnummer = new Postnummer(Convert.ToInt32(reader["Postnummer"]))
                    {
                        City = reader["Bynavn"].ToString()
                    };
                    address = new Address(postnummer, Convert.ToInt32(reader["AdresseID"]))
                    {
                        //AddressID = Convert.ToInt32(reader["AdresseID"]),
                        StreetName = reader["VejNavn"].ToString(),
                        StreetNumber = reader["Vejnummer"].ToString()
                    };
                    members.Add(new Member(Convert.ToInt32(reader["KundeID"]))
                    {
                        Fristname = reader["Fornavn"].ToString(),
                        Lastname = reader["Efternavn"].ToString(),
                        Email = reader["Email"].ToString(),
                        Mobil = Convert.ToInt32(reader["Mobil"]),
                        Address = address
                    });
                    address = null;
                    postnummer = null;
                    i++;
                }
                dbConn.Close();
                reader.Close();
                //if (i != 1) return null;
            }

            return members;
        }
        public Member CreateMember(Member member)
        {
            string query = "INSERT INTO Kunder (Fornavn, Efternavn, Email, Mobil, AdresseID) VALUES (@val1, @val2, @val3, @val4, @val5); SELECT SCOPE_IDENTITY() AS id;";
            SqlCommand cmd = new SqlCommand(query, dbConn);
            cmd.Parameters.AddWithValue("@val1", member.Fristname);
            cmd.Parameters.AddWithValue("@val2", member.Lastname);
            cmd.Parameters.AddWithValue("@val3", member.Email);
            cmd.Parameters.AddWithValue("@val4", member.Mobil);
            cmd.Parameters.AddWithValue("@val5", member.Address.AddressID);
            //cmd.Parameters.AddWithValue("@val2", product.Price);

            if (dbConn.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    dbConn.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            member.SetMemberID(Convert.ToInt32(cmd.ExecuteScalar()));
            dbConn.Close();

            return member;
        }
        public void DeleteMember(int id)
        {
            string query = "DELETE FROM Kunder WHERE KundeID = @val";
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
                cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                dbConn.Close();
            }


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
                //if (i != 1) return null;
            }

            return products;
        }
        public Product CreateProduct(Product product)
        {
            string query = "INSERT INTO Produkt (ProduktNavn, Prise) VALUES (@val1, @val2); SELECT SCOPE_IDENTITY() AS id;";
            SqlCommand cmd = new SqlCommand(query, dbConn);
            cmd.Parameters.AddWithValue("@val1", product.Name);
            cmd.Parameters.AddWithValue("@val2", product.Price);

            if (dbConn.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    dbConn.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            product.SetProductID(Convert.ToInt32(cmd.ExecuteScalar()));
            dbConn.Close();

            return product;
        }

        public Product EditProduct(int id, string Name, int Price)
        {
            Product product = null;
            string query = "UPDATE Produkt SET ProduktNavn = @Navn, Prise = @Price WHERE ProduktID = @val;";
            SqlCommand cmd = new SqlCommand(query, dbConn);
            cmd.Parameters.Add("@Navn", SqlDbType.VarChar).Value = string.IsNullOrEmpty(Name) ? (object)DBNull.Value : Name;
            cmd.Parameters.Add("@Price", SqlDbType.Int).Value = Equals(Price, 0) ? (object)DBNull.Value : Price;


            cmd.Parameters.AddWithValue("@val", id);

            if (dbConn.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    dbConn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            dbConn.Close();

            return product;

        }

        public void DeleteProduct(int id)
        {
            //Product product = null;

            string query = "DELETE FROM Produkt WHERE ProduktID = @val";
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
                cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
               
                dbConn.Close();
            }

        }

        public Member EditMember(int id, string Fristname, string Lastname, string Email, int Mobil)
        {
            Member member = null;
            string query = "UPDATE Kunder SET Fornavn = @Fristname, Efternavn = @Lastname, Mobil = @Number, @Email = email WHERE KundeID = @val;";
            SqlCommand cmd = new SqlCommand(query, dbConn);
            cmd.Parameters.Add("@Fristname", SqlDbType.VarChar).Value = string.IsNullOrEmpty(Fristname) ? (object)DBNull.Value : Fristname;
            cmd.Parameters.Add("@Lastname", SqlDbType.VarChar).Value = string.IsNullOrEmpty(Lastname) ? (object)DBNull.Value : Lastname;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = string.IsNullOrEmpty(Email) ? (object)DBNull.Value : Email;
            cmd.Parameters.Add("@Number", SqlDbType.Int).Value = Equals(Mobil, 0) ? (object)DBNull.Value : Mobil;

            cmd.Parameters.AddWithValue("@val", id);

            if (dbConn.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    dbConn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            dbConn.Close();

            return member;
        }

        public Address EditAddress(int id, int postnummer, string Streetname, string Steetnumber)
        {
            Address address = null;
            string query = "UPDATE Adresse SET Postnummer = @postnummer, VejNavn = @streetname, Vejnummer = @steetnumber WHERE AdresseID = @val;";
            SqlCommand cmd = new SqlCommand(query, dbConn);
            cmd.Parameters.Add("@steetnumber", SqlDbType.VarChar).Value = string.IsNullOrEmpty(Steetnumber) ? (object)DBNull.Value : Steetnumber;
            cmd.Parameters.Add("@streetname", SqlDbType.VarChar).Value = string.IsNullOrEmpty(Streetname) ? (object)DBNull.Value : Streetname;
            cmd.Parameters.Add("@postnummer", SqlDbType.Int).Value = Equals(postnummer, 0) ? (object)DBNull.Value : postnummer;

            cmd.Parameters.AddWithValue("@val", id);

            if (dbConn.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    dbConn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            dbConn.Close();

            return address;
        }
    }
}
