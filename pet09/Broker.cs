using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet09
{
    public class Broker
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=0000_ProSoft;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        public List<osoba> GetosobaList()
        {
            try
            {
                List<osoba> result = new List<osoba>();

                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = $"select * from osoba;";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new osoba
                    {
                        jmbg = reader.GetString(0),
                        ime = reader.GetString(1),
                        prezime = reader.GetString(2),
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

        public List<instrument> GetinstrumentList()
        {
            try
            {
                List<instrument> result = new List<instrument>();

                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = $"select * from instrument;";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new instrument
                    {
                        id = reader.GetInt64(0),
                        naziv = reader.GetString(1),
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

        public List<instrument> GetinstrumentList(List<long> instrumentids)
        {
            try
            {
                List<instrument> result = new List<instrument>();

                if (instrumentids == null || instrumentids.Count == 0)
                {
                    return result;
                }

                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = $"select * from instrument where id in ({string.Join(", ", instrumentids)});";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new instrument
                    {
                        id = reader.GetInt64(0),
                        naziv = reader.GetString(1),
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

        public List<osoba> GetosobaList(List<string> osobajmbgs)
        {
            try
            {
                List<osoba> result = new List<osoba>();

                if (osobajmbgs == null || osobajmbgs.Count == 0)
                {
                    return result;
                }

                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = $"select * from osoba where jmbg in ({string.Join(", ", osobajmbgs.Select(x => $"N'{x}'"))});";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new osoba
                    {
                        jmbg = reader.GetString(0),
                        ime = reader.GetString(1),
                        prezime = reader.GetString(2),
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

        public List<osobainstrument> GetosobainstrumentIdsForosoba(string osobajmbg)
        {
            try
            {
                List<osobainstrument> result = new List<osobainstrument>();

                if (osobajmbg == null)
                {
                    return result;
                }

                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = $"select * from osobainstrument where jmbg = N'{osobajmbg}';";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new osobainstrument{
                       jmbg = reader.GetString(reader.GetOrdinal("jmbg")),
                       instrumentid = reader.GetInt64(reader.GetOrdinal("instrumentid")),
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

        public List<osobainstrument> GetosobainstrumentForinstrument(long instrumentid)
        {
            try
            {
                List<osobainstrument> result = new List<osobainstrument>();

                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = $"select * from osobainstrument where instrumentid = {instrumentid};";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new osobainstrument
                    {
                        jmbg = reader.GetString(reader.GetOrdinal("jmbg")),
                        instrumentid = reader.GetInt64(reader.GetOrdinal("instrumentid")),
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

        public void Deleteosoba(string osobajmbg)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = $"delete osobainstrument where jmbg = N'{osobajmbg}';";

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

    public class osoba 
    {
        public string jmbg {get; set;}
        public string ime {get; set;}
        public string prezime { get; set; }

    }

    public class instrument
    {
        public long id { get; set;}
        public string naziv { get; set;}

    }

    public class osobainstrument
    {
        public string jmbg { get; set; }
        public long instrumentid { get; set; }
    }
}
