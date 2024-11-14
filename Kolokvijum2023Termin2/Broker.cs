using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Kolokvijum2023Termin2
{
    public class Broker
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-LRUAM92\SQLEXPRESS;Initial Catalog=termin_2;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        public long InsertRadnik(Radnik radnik)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = $"insert into radnik (radna_knjizica, jmbg, ime, prezime, oj) output inserted.id values (N'{radnik.radna_knjizica}', N'{radnik.jmbg}', N'{radnik.ime}', N'{radnik.prezime}', {radnik.oj});";

                long id = (long)cmd.ExecuteScalar();

                conn.Close();

                return id;
            }
            catch (Exception)
            {
                conn?.Close();
                throw;
            }
        }

        public void UpdateRadnik(Radnik radnik)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = $"update radnik set radna_knjizica = N'{radnik.radna_knjizica}', jmbg = N'{radnik.jmbg}', ime = N'{radnik.ime}', prezime = N'{radnik.prezime}', oj = {radnik.oj} " +
                    $"where id = {radnik.id};";

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception)
            {
                conn?.Close();
                throw;
            }
        }

        public List<Radnik> GetRadnikList()
        {
            try
            {
                List<Radnik> result = new List<Radnik>();

                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = $"select * from radnik;";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new Radnik
                    {
                        id = reader.GetInt64(reader.GetOrdinal("id")),
                        radna_knjizica = reader.GetString(reader.GetOrdinal("radna_knjizica")),
                        jmbg = reader.GetString(reader.GetOrdinal("jmbg")),
                        ime = reader.GetString(reader.GetOrdinal("ime")),
                        prezime = reader.GetString(reader.GetOrdinal("prezime")),
                        oj = reader.GetInt64(reader.GetOrdinal("oj")),
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

        public Radnik GetRadnik(long id)
        {
            try
            {
                List<Radnik> result = new List<Radnik>();

                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = $"select * from radnik where id = {id};";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new Radnik
                    {
                        id = reader.GetInt64(reader.GetOrdinal("id")),
                        radna_knjizica = reader.GetString(reader.GetOrdinal("radna_knjizica")),
                        jmbg = reader.GetString(reader.GetOrdinal("jmbg")),
                        ime = reader.GetString(reader.GetOrdinal("ime")),
                        prezime = reader.GetString(reader.GetOrdinal("prezime")),
                        oj = reader.GetInt64(reader.GetOrdinal("oj")),
                    });
                }

                conn.Close();

                return result.SingleOrDefault();
            }
            catch (Exception)
            {
                conn?.Close();
                throw;
            }
        }

        public List<Organizaciona_Jedinica> GetOrganizaciona_JedinicaList()
        {
            try
            {
                List<Organizaciona_Jedinica> result = new List<Organizaciona_Jedinica>();

                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = $"select * from Organizaciona_Jedinica;";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new Organizaciona_Jedinica
                    {
                        id = reader.GetInt64(reader.GetOrdinal("id")),
                        naziv = reader.GetString(reader.GetOrdinal("naziv")),
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

        public Organizaciona_Jedinica GetOrganizaciona_Jedinica(long id)
        {
            try
            {
                List<Organizaciona_Jedinica> result = new List<Organizaciona_Jedinica>();

                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = $"select * from Organizaciona_Jedinica where id = {id};";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new Organizaciona_Jedinica
                    {
                        id = reader.GetInt64(reader.GetOrdinal("id")),
                        naziv = reader.GetString(reader.GetOrdinal("naziv")),
                    });
                }

                conn.Close();

                return result.SingleOrDefault();
            }
            catch (Exception)
            {
                conn?.Close();
                throw;
            }
        }

    }

    public class Radnik
    {
        public long id { get; set; }
        public string radna_knjizica { get; set; }
        public string jmbg {  get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public long oj { get; set; }
        public string ojNaziv { get; set; }
    }

    public class Organizaciona_Jedinica
    {
        public long id { get; set; }
        public string naziv {  get; set; }
    }
}
