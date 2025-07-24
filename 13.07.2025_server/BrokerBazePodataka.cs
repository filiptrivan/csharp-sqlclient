using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13._07._2025_server
{
    public class BrokerBazePodataka
    {
        SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=nastava;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        public List<Predmet> GetPredmets()
        {
            conn.Open();
            var com = conn.CreateCommand();

            com.CommandText = "select * from Predmet";

            var r = com.ExecuteReader();

            List<Predmet> res = new List<Predmet>();
            while (r.Read())
            {
                res.Add(new Predmet
                {
                    Id = (long)r.GetValue(0),
                    Name = (string)r.GetValue(1),
                });
            }

            conn.Close();

            return res;
        }
        public List<Nastavnik> GetNastavniks()
        {
            conn.Open();
            var com = conn.CreateCommand();

            com.CommandText = "select * from Nastavnik";

            var r = com.ExecuteReader();

            List<Nastavnik> res = new List<Nastavnik>();
            while (r.Read())
            {
                res.Add(new Nastavnik
                {
                    Id = (long)r.GetValue(0),
                    Name = (string)r.GetValue(1),
                    Password = (string)r.GetValue(2),
                });
            }

            conn.Close();

            return res;
        }
        public List<TipAngazovanja> GetTipAngazovanjas()
        {
            conn.Open();
            var com = conn.CreateCommand();

            com.CommandText = "select * from TipAngazovanja";

            var r = com.ExecuteReader();

            List<TipAngazovanja> res = new List<TipAngazovanja>();
            while (r.Read())
            {
                res.Add(new TipAngazovanja
                {
                    Id = (long)r.GetValue(0),
                    Name = (string)r.GetValue(1),
                });
            }

            conn.Close();

            return res;
        }
        public List<NastavnikPredmet> GetNastavnikPredmets()
        {
            conn.Open();
            var com = conn.CreateCommand();

            com.CommandText = "select * from NastavnikPredmet";

            var r = com.ExecuteReader();

            List<NastavnikPredmet> predmets = new List<NastavnikPredmet>();
            while (r.Read())
            {
                predmets.Add(new NastavnikPredmet
                {
                    NastavnikId = (long)r.GetValue(0),
                    PredmetId = (long)r.GetValue(1),
                    TipAngazovanjaId = (long)r.GetValue(2),
                });
            }

            conn.Close();

            return predmets;
        }

        public string UpdateAngazovanja(NastavnikPredmet nastavnikPredmet)
        {
            conn.Open();
            var com = conn.CreateCommand();
            com.Transaction = conn.BeginTransaction();
            com.CommandText = "";

            try
            {
                var nastavnik = GetNastavniks().Where(x => x.Id == nastavnikPredmet.NastavnikId).FirstOrDefault();
                List<NastavnikPredmet> nastavnikPredmets = GetNastavnikPredmets()
                    .Where(x => x.NastavnikId== nastavnikPredmet.NastavnikId)
                    .ToList();

                if (nastavnikPredmets.Any(x => x.TipAngazovanjaId == 1) &&
                    nastavnikPredmets.Any(x => x.TipAngazovanjaId == 2) == false &&
                    nastavnikPredmet.TipAngazovanjaId == 2
                    )
                {
                    com.CommandText = $"insert into NastavnikPredmet (NastavnikId, PredmetId, TipAngazovanjaId) values ({nastavnik.Id}, {nastavnikPredmet.PredmetId}, {nastavnikPredmet.TipAngazovanjaId})";
                    com.ExecuteNonQuery();
                }

                if (nastavnikPredmets.Any(x => x.TipAngazovanjaId == 1) == false &&
                    nastavnikPredmets.Any(x => x.TipAngazovanjaId == 2) &&
                    nastavnikPredmet.TipAngazovanjaId == 0
                    )
                {
                    com.CommandText = $"delete from NastavnikPredmet where NastavnikId={nastavnik.Id} and PredmetId={nastavnikPredmet.PredmetId} and TipAngazovanjaId={nastavnikPredmet.TipAngazovanjaId}";
                    com.ExecuteNonQuery();
                }

                if (nastavnikPredmets.Any() == false)
                {
                    //
                }


                com.Transaction.Commit();

                return "uspesno";
            }
            catch (Exception e)
            {
                com.Transaction.Rollback();
                return e.Message;
            }
        }
    }


    public class Predmet
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public class Nastavnik
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string TipAngazovanja { get; set; }
    }

    public class NastavnikPredmet
    {
        public long NastavnikId { get; set; }
        public long PredmetId { get; set; }
        public long TipAngazovanjaId { get; set; }
    }

    public class TipAngazovanja
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public class Request
    {
        public string Data { get; set; }
        public string Method { get; set; }
    }
}
