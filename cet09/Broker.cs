using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cet09
{
    public class Broker
    {
        SqlConnection _con = new SqlConnection(@"Data Source=DESKTOP-LRUAM92\SQLEXPRESS;Initial Catalog=cet09;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        public List<Rec> GetRecList()
        {
            try
            {
                List<Rec> list = new List<Rec>();

                _con.Open();

                SqlCommand cmd = _con.CreateCommand();
                cmd.CommandText = "select * from Rec;";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Rec
                    {
                        Id = reader.GetInt64(reader.GetOrdinal("Id")),
                        Naziv = reader.GetString(reader.GetOrdinal("Naziv")),
                    });
                }

                _con.Close();

                return list;
            }
            catch (Exception)
            {
                _con?.Close();
                throw;
            }
        }

        public List<Prevod> GetPrevodList(long recid)
        {
            try
            {
                List<Prevod> list = new List<Prevod>();
                _con.Open();

                SqlCommand cmd = _con.CreateCommand();
                cmd.CommandText = $"select * from Prevod where RecId = {recid};";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Prevod
                    {
                        Id = reader.GetInt64(reader.GetOrdinal("Id")),
                        RecId = reader.GetInt64(reader.GetOrdinal("RecId")),
                        JezikId = reader.GetInt64(reader.GetOrdinal("JezikId")),
                        Naziv = reader.GetString(reader.GetOrdinal("Naziv")),
                    });
                }

                _con.Close();

                return list;
            }
            catch (Exception)
            {
                _con?.Close();
                throw;
            }
        }

        public List<Jezik> GetJezikList()
        {
            try
            {
                List<Jezik> list = new List<Jezik>();

                _con.Open();

                SqlCommand cmd = _con.CreateCommand();
                cmd.CommandText = "select * from Jezik;";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Jezik
                    {
                        Id = reader.GetInt64(reader.GetOrdinal("Id")),
                        Naziv = reader.GetString(reader.GetOrdinal("Naziv")),
                    });
                }

                _con.Close();

                return list;
            }
            catch (Exception)
            {
                _con?.Close();
                throw;
            }
        }

        public List<Prevod> GetPrevodList(long? recid, long? jezikid)
        {
            try
            {
                List<Prevod> list = new List<Prevod>();

                _con.Open();

                SqlCommand cmd = _con.CreateCommand();

                if(recid == null)
                    cmd.CommandText = $"select * from Prevod where JezikId = {jezikid};";
                else if (jezikid == null)
                    cmd.CommandText = $"select * from Prevod where RecId = {recid};";
                else
                    cmd.CommandText = $"select * from Prevod where RecId = {recid} and JezikId = {jezikid};";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Prevod
                    {
                        Id = reader.GetInt64(reader.GetOrdinal("Id")),
                        RecId = reader.GetInt64(reader.GetOrdinal("RecId")),
                        JezikId = reader.GetInt64(reader.GetOrdinal("JezikId")),
                        Naziv = reader.GetString(reader.GetOrdinal("Naziv")),
                    });
                }

                _con.Close();

                return list;
            }
            catch (Exception)
            {
                _con?.Close();
                throw;
            }
        }

        public void InsertPrevodi(long recid, long jezikid, string prevodi)
        {
            try
            {
                List<Prevod> list = new List<Prevod>();

                _con.Open();

                SqlCommand cmd = _con.CreateCommand();

                List<string> inserti = prevodi.Split('#').ToList();

                foreach (string item in inserti)
                {
                    cmd.CommandText += $"insert into Prevod values ({recid}, {jezikid}, N'{item}');";
                }

                cmd.ExecuteNonQuery();

                _con.Close();
            }
            catch (Exception)
            {
                _con?.Close();
                throw;
            }
        }
    }

    public class Rec
    {
        public long Id { get; set; }
        public string Naziv { get; set; }
    }

    public class Jezik
    {
        public long Id { get; set; }
        public string Naziv { get; set; }
    }

    public class Prevod
    {
        public long Id { get; set; }
        public long RecId { get; set; }
        public long JezikId { get; set; }
        public string Naziv { get; set; }
    }
}
