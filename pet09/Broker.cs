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
        SqlConnection _conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=0000_ProSoft;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        public List<Osoba> GetOsobaList()
        {
            try
            {
                List<Osoba> result = new List<Osoba>();

                _conn.Open();

                SqlCommand cmd = _conn.CreateCommand();

                cmd.CommandText = $"select * from osoba;";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new Osoba
                    {
                        JMBG = reader.GetString(0),
                        Ime = reader.GetString(1),
                        Prezime = reader.GetString(2),
                    });
                }

                _conn.Close();

                return result;
            }
            catch (Exception)
            {
                _conn?.Close();
                throw;
            }
        }

        public List<Instrument> GetInstrumentList()
        {
            try
            {
                List<Instrument> result = new List<Instrument>();

                _conn.Open();

                SqlCommand cmd = _conn.CreateCommand();

                cmd.CommandText = $"select * from instrument;";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new Instrument
                    {
                        Id = reader.GetInt64(0),
                        Naziv = reader.GetString(1),
                    });
                }

                _conn.Close();

                return result;
            }
            catch (Exception)
            {
                _conn?.Close();
                throw;
            }
        }

        public List<Instrument> GetInstrumentList(List<long> instrumentids)
        {
            try
            {
                List<Instrument> result = new List<Instrument>();

                if (instrumentids == null || instrumentids.Count == 0)
                {
                    return result;
                }

                _conn.Open();

                SqlCommand cmd = _conn.CreateCommand();

                cmd.CommandText = $"select * from instrument where id in ({string.Join(", ", instrumentids)});";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new Instrument
                    {
                        Id = reader.GetInt64(0),
                        Naziv = reader.GetString(1),
                    });
                }

                _conn.Close();

                return result;
            }
            catch (Exception)
            {
                _conn?.Close();
                throw;
            }
        }

        public List<Osoba> GetOsobaList(List<string> osobaJMBGs)
        {
            try
            {
                List<Osoba> result = new List<Osoba>();

                if (osobaJMBGs == null || osobaJMBGs.Count == 0)
                {
                    return result;
                }

                _conn.Open();

                SqlCommand cmd = _conn.CreateCommand();

                cmd.CommandText = $"select * from osoba where JMBG in ({string.Join(", ", osobaJMBGs.Select(x => $"N'{x}'"))});";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new Osoba
                    {
                        JMBG = reader.GetString(0),
                        Ime = reader.GetString(1),
                        Prezime = reader.GetString(2),
                    });
                }

                _conn.Close();

                return result;
            }
            catch (Exception)
            {
                _conn?.Close();
                throw;
            }
        }

        public List<OsobaInstrument> GetOsobaInstrumentIdsForOsoba(string osobaJMBG)
        {
            try
            {
                List<OsobaInstrument> result = new List<OsobaInstrument>();

                if (osobaJMBG == null)
                {
                    return result;
                }

                _conn.Open();

                SqlCommand cmd = _conn.CreateCommand();

                cmd.CommandText = $"select * from osobainstrument where JMBG = N'{osobaJMBG}';";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new OsobaInstrument{
                       JMBG = reader.GetString(reader.GetOrdinal("JMBG")),
                       InstrumentId = reader.GetInt64(reader.GetOrdinal("instrumentid")),
                    });
                }

                _conn.Close();

                return result;
            }
            catch (Exception)
            {
                _conn?.Close();
                throw;
            }
        }

        public List<OsobaInstrument> GetOsobaInstrumentForinstrument(long instrumentid)
        {
            try
            {
                List<OsobaInstrument> result = new List<OsobaInstrument>();

                _conn.Open();

                SqlCommand cmd = _conn.CreateCommand();

                cmd.CommandText = $"select * from osobainstrument where instrumentid = {instrumentid};";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new OsobaInstrument
                    {
                        JMBG = reader.GetString(reader.GetOrdinal("JMBG")),
                        InstrumentId = reader.GetInt64(reader.GetOrdinal("instrumentid")),
                    });
                }

                _conn.Close();

                return result;
            }
            catch (Exception)
            {
                _conn?.Close();
                throw;
            }
        }

        public void DeleteOsoba(string osobaJMBG)
        {
            try
            {
                _conn.Open();

                SqlCommand cmd = _conn.CreateCommand();

                cmd.CommandText = $"delete osobainstrument where JMBG = N'{osobaJMBG}';";

                cmd.ExecuteNonQuery();

                _conn.Close();
            }
            catch (Exception)
            {
                _conn?.Close();
                throw;
            }
        }
    }

    public class Osoba 
    {
        public string JMBG {get; set;}
        public string Ime {get; set;}
        public string Prezime { get; set; }

    }

    public class Instrument
    {
        public long Id { get; set;}
        public string Naziv { get; set;}

    }

    public class OsobaInstrument
    {
        public string JMBG { get; set; }
        public long InstrumentId { get; set; }
    }
}
