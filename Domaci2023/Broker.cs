using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci2023
{
    public class Broker
    {
        SqlConnection _connection;

        public Broker()
        {
            _connection = new SqlConnection(Settings.ConnectionString);
        }

        public long InsertNastavnik(Nastavnik nastavnik)
        {
            try
            {
                _connection.Open();

                SqlCommand cmd = _connection.CreateCommand();

                cmd.CommandText = $"insert into Nastavnik (Ime, Prezime, Zvanje_Id) output inserted.id values (N'{nastavnik.Ime}', N'{nastavnik.Prezime}', {nastavnik.Zvanje_Id});";

                long newId = (long)cmd.ExecuteScalar();

                _connection.Close();

                return newId;
            }
            catch (Exception)
            {
                _connection?.Close();
                throw;
            }
        }

        public void UpdateNastavnik(Nastavnik nastavnik)
        {
            try
            {
                _connection.Open();

                SqlCommand cmd = _connection.CreateCommand();

                cmd.CommandText = $"update Nastavnik set Ime = N'{nastavnik.Ime}', Prezime = N'{nastavnik.Prezime}', Zvanje_Id = {nastavnik.Zvanje_Id} where Id = {nastavnik.Id};";

                cmd.ExecuteNonQuery();

                _connection.Close();
            }
            catch (Exception)
            {
                _connection?.Close();
                throw;
            }
        }

        public void DeleteNastavnik(long nastavnikId)
        {
            try
            {
                _connection.Open();

                SqlCommand cmd = _connection.CreateCommand();

                cmd.CommandText = $"delete Nastavnik where Id = {nastavnikId};";

                cmd.ExecuteNonQuery();

                _connection.Close();
            }
            catch (Exception)
            {
                _connection?.Close();
                throw;
            }
        }

        public List<Nastavnik> GetNastavnikList()
        {
            try
            {
                List<Nastavnik> result = new List<Nastavnik>();

                _connection.Open();

                SqlCommand cmd = _connection.CreateCommand();

                cmd.CommandText = $"select * from Nastavnik;";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Nastavnik obj = new Nastavnik 
                    {
                        Id = reader.GetInt64(0),
                        Ime = reader.GetString(1),
                        Prezime = reader.GetString(2),
                        Zvanje_Id = reader.GetInt64(3),
                    };

                    result.Add(obj);
                }

                _connection.Close();

                return result;
            }
            catch (Exception)
            {
                _connection?.Close();
                throw;
            }
        }

        public Nastavnik GetNastavnik(long zvanjeId)
        {
            try
            {
                Nastavnik result = null;

                _connection.Open();

                SqlCommand cmd = _connection.CreateCommand();

                cmd.CommandText = $"select * from Nastavnik where Id = {zvanjeId};";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Nastavnik obj = new Nastavnik
                    {
                        Id = reader.GetInt64(0),
                        Ime = reader.GetString(1),
                        Prezime = reader.GetString(2),
                        Zvanje_Id = reader.GetInt64(3),
                    };

                    result = obj;
                }

                _connection.Close();

                return result;
            }
            catch (Exception)
            {
                _connection?.Close();
                throw;
            }
        }

        public List<Zvanje> GetZvanjeList()
        {
            try
            {
                List<Zvanje> result = new List<Zvanje>();

                _connection.Open();

                SqlCommand cmd = _connection.CreateCommand();

                cmd.CommandText = $"select * from Zvanje;";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Zvanje obj = new Zvanje
                    {
                        Id = reader.GetInt64(0),
                        Naziv = reader.GetString(1),
                    };

                    result.Add(obj);
                }

                _connection.Close();

                return result;
            }
            catch (Exception)
            {
                _connection?.Close();
                throw;
            }
        }

        public Zvanje GetZvanje(long zvanjeId)
        {
            try
            {
                Zvanje result = null;

                _connection.Open();

                SqlCommand cmd = _connection.CreateCommand();

                cmd.CommandText = $"select * from Zvanje where Id = {zvanjeId};";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Zvanje obj = new Zvanje
                    {
                        Id = reader.GetInt64(0),
                        Naziv = reader.GetString(1),
                    };

                    result = obj;
                }

                _connection.Close();

                return result;
            }
            catch (Exception)
            {
                _connection?.Close();
                throw;
            }
        }
    }

    public class Nastavnik
    {
        public long Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public Zvanje Zvanje { get; set; }
        public long Zvanje_Id { get; set; }
    }

    public class Zvanje
    {
        public long Id { get; set; }
        public string Naziv { get; set; }
    }

    public class Predmet
    {
        public long Id { get; set; }
        public string Naziv { get; set; }
        public int ESPB { get; set; }
    }
}
