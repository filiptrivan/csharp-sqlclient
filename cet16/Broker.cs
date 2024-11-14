using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cet16
{
    public class Broker
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-LRUAM92\SQLEXPRESS;Initial Catalog=0000_ProSoft;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        public List<srb_rec> Getsrb_recList()
        {
            try
            {
                List<srb_rec> result = new List<srb_rec>();

                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = $"select * from srb_rec";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new srb_rec
                    {
                        id = reader.GetInt64(0),
                        naziv = reader.GetString(1),
                        napravljen = reader.GetDateTime(2),
                        skracenica = reader.IsDBNull(3) == true || string.IsNullOrEmpty(reader.GetString(3)) ? null : Enum.Parse<Skracenica>(reader.GetString(3))
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

        public srb_rec Getsrb_rec(long id)
        {
            try
            {
                List<srb_rec> result = new List<srb_rec>();

                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = $"select * from srb_rec where id = {id}";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new srb_rec
                    {
                        id = reader.GetInt64(0),
                        naziv = reader.GetString(1),
                        napravljen = reader.GetDateTime(2),
                        skracenica = reader.IsDBNull(3) == true ? null : Enum.Parse<Skracenica>(reader.GetString(3))
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

        public void Insertsrb_rec(srb_rec srb_rec)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = $"insert into srb_rec values (N'{srb_rec.naziv}', '{srb_rec.napravljen.ToString("yyyy-MM-dd")}', '{srb_rec.skracenica}')";

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception)
            {
                conn?.Close();
                throw;
            }
        }

        public List<prevod> GetprevodList(long recid)
        {
            try
            {
                List<prevod> result = new List<prevod>();

                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = $"select * from prevod where srb_recid = {recid}";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new prevod
                    {
                        id = reader.GetInt64(0),
                        srb_recid = reader.GetInt64(1),
                        jezikid = reader.GetInt64(2),
                        naziv = reader.GetString(3)
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

        public List<prevod> GetprevodList(long? recid = null, long? jezikid = null)
        {
            try
            {
                List<prevod> result = new List<prevod>();

                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                if (recid != null && jezikid != null)
                    cmd.CommandText = $"select * from prevod where srb_recid = {recid} and jezikid = {jezikid};";
                else if (jezikid != null)
                    cmd.CommandText = $"select * from prevod where jezikid = {jezikid};";
                else if (recid != null)
                    cmd.CommandText = $"select * from prevod where srb_recid = {recid};";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new prevod
                    {
                        id = reader.GetInt64(0),
                        srb_recid = reader.GetInt64(1),
                        jezikid = reader.GetInt64(2),
                        naziv = reader.GetString(3)
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

        public prevod Getprevod(long id)
        {
            try
            {
                List<prevod> result = new List<prevod>();

                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = $"select * from prevod where id = {id};";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new prevod
                    {
                        id = reader.GetInt64(0),
                        srb_recid = reader.GetInt64(1),
                        jezikid = reader.GetInt64(2),
                        naziv = reader.GetString(3)
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

        public List<jezik> GetjezikList()
        {
            try
            {
                List<jezik> result = new List<jezik>();

                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = $"select * from jezik;";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new jezik
                    {
                        id = reader.GetInt64(0),
                        naziv = reader.GetString(1),
                        skraceni_naziv = reader.GetString(2)
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

        public jezik Getjezik(long id)
        {
            try
            {
                List<jezik> result = new List<jezik>();

                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = $"select * from jezik where id = {id};";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new jezik
                    {
                        id = reader.GetInt64(0),
                        naziv = reader.GetString(1),
                        skraceni_naziv = reader.GetString(2)
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

        public void Deleteprevod(long id)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = $"delete prevod where id = {id};";

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception)
            {
                conn?.Close();
                throw;
            }
        }
    }

    public class srb_rec
    {
        public long id { get; set; }
        public string naziv { get; set; }
        public DateTime napravljen { get; set; }
        public Skracenica? skracenica { get; set; }
    }

    public enum Skracenica
    {
        srp,
        en,
        ge
    }

    public class jezik
    {
        public long id { get; set; }
        public string naziv { get; set; }
        public string skraceni_naziv { get; set; }
    }

    public class prevod
    {
        public long id { get; set; }
        public long srb_recid { get; set; }
        public long jezikid { get; set; }
        public string naziv { get; set; }
    }
}
