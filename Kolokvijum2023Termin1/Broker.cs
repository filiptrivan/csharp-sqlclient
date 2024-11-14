using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokvijum2023Termin1
{
    public class Broker
    {
        SqlConnection _connection = new SqlConnection(@"Data Source=DESKTOP-LRUAM92\SQLEXPRESS;Initial Catalog=termin_1;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        public long InsertPredmet(Predmet predmet)
        {
            try
            {
                _connection.Open();

                SqlCommand cmd = _connection.CreateCommand();

                cmd.CommandText = $"insert into Predmet output inserted.Id values (N'{predmet.Naziv}', {predmet.ESPB}, {predmet.KatedraId});";

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

        public void UpdatePredmet(Predmet predmet)
        {
            try
            {
                _connection.Open();

                SqlCommand cmd = _connection.CreateCommand();

                cmd.CommandText = $"update Predmet set Naziv = N'{predmet.Naziv}', ESPB = {predmet.ESPB}, KatedraId = {predmet.KatedraId} where Id = {predmet.Id};";

                cmd.ExecuteNonQuery();

                _connection.Close();
            }
            catch (Exception)
            {
                _connection?.Close();
                throw;
            }
        }

        public Predmet GetPredmet(long predmetId)
        {
            try
            {
                List<Predmet> result = new List<Predmet>();

                _connection.Open();

                SqlCommand cmd = _connection.CreateCommand();

                cmd.CommandText = $"select * from Predmet where Id = {predmetId};";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new Predmet
                    {
                        Id = reader.GetInt64(0),
                        Naziv = reader.GetString(1),
                        ESPB = reader.GetInt32(2),
                        KatedraId = reader.GetInt64(3),
                    });
                }

                _connection.Close();

                return result.SingleOrDefault();
            }
            catch (Exception)
            {
                _connection?.Close();
                throw;
            }
        }

        public List<Predmet> GetPredmetList()
        {
            try
            {
                List<Predmet> result = new List<Predmet>();

                _connection.Open();

                SqlCommand cmd = _connection.CreateCommand();

                cmd.CommandText = $"select * from Predmet;";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Predmet obj = new Predmet
                    {
                        Id = reader.GetInt64(0),
                        Naziv = reader.GetString(1),
                        ESPB = reader.GetInt32(2),
                        KatedraId = reader.GetInt64(3),
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

        public List<Katedra> GetKatedraList()
        {
            try
            {
                List<Katedra> result = new List<Katedra>();

                _connection.Open();

                SqlCommand cmd = _connection.CreateCommand();

                cmd.CommandText = $"select * from Katedra;";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Katedra obj = new Katedra
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

        public Katedra GetKatedra(long id)
        {
            try
            {
                List<Katedra> result = new List<Katedra>();

                _connection.Open();

                SqlCommand cmd = _connection.CreateCommand();

                cmd.CommandText = $"select * from Katedra where Id = {id};";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Katedra obj = new Katedra
                    {
                        Id = reader.GetInt64(0),
                        Naziv = reader.GetString(1),
                    };

                    result.Add(obj);
                }

                _connection.Close();

                return result.SingleOrDefault();
            }
            catch (Exception)
            {
                _connection?.Close();
                throw;
            }
        }
    }

    public class Predmet
    {
        public long Id { get; set; }
        public string Naziv { get; set; }
        public int ESPB { get; set; }
        public long KatedraId { get; set; }
        public string KatedraNaziv { get; set; }
    }

    public class Katedra
    {
        public long Id { get; set; }
        public string Naziv { get; set; }
    }
}
