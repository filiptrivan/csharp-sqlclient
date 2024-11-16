using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci2024
{
    public class Broker
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-LRUAM92\SQLEXPRESS;Initial Catalog=Domaci2024;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        public long Insertprofesor(profesor profesor)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = $"insert into profesor output inserted.id values('{profesor.ime}', '{profesor.prezime}', '{profesor.zvanje}', '{profesor.email_kreatora}');";

                long newid = (long)cmd.ExecuteScalar();

                conn.Close();

                return newid;
            }
            catch (Exception)
            {
                conn?.Close();
                throw;
            }
        }

        public void Insertangazovanje(long profesorid, long predmetid)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = $"insert into angazovanje values ({profesorid}, {predmetid});";

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception)
            {
                conn?.Close();
                throw;
            }
        }

        public void Deleteangazovanje(long profesorid, long predmetid)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = $"delete angazovanje where profesorid = {profesorid} and predmetid = {predmetid};";

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception)
            {
                conn?.Close();
                throw;
            }
        }

        public List<predmet> GetpredmetList()
        {
            try
            {
                List<predmet> result = new List<predmet>();

                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = $"select * from predmet;";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new predmet
                    {
                        id = reader.GetInt64(0),
                        naziv = reader.GetString(1),
                        kod = reader.GetString(2),
                        espb = reader.GetInt32(3),
                    });
                }

                conn.Close();

                return result;
            }
            catch (Exception)
            {
                conn?.Close();
                throw;
            }
        }
        
    }

    public class profesor
    {
        public long id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public Zvanje zvanje { get; set; }
        public string email_kreatora { get; set; }
    }

    public enum Zvanje
    {
        Docent,
        Redovni,
        Vanredni
    }

    public class predmet
    {
        public long id { get; set; }
        public string naziv { get; set; }
        public string kod { get; set; }
        public int espb { get; set; }
    }

    public class angazovanje
    {
        public long profesorid { get; set; }
        public long predmetid { get; set; }
    }
}
