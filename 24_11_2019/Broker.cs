using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24_11_2019
{
    public class Broker
    {
        SqlConnection _connection;

        public Broker()
        {
            _connection = new SqlConnection(Settings.ConnectionString);
        }

        public List<Profesor2> GetProfesor2List()
        {
            try
            {
                List<Profesor2> result = new List<Profesor2>();

                _connection.Open();

                SqlCommand cmd = _connection.CreateCommand();
                cmd.CommandText = $"select * from Profesor2";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Profesor2 profesor = new Profesor2
                    {
                        Id = reader.GetInt64(reader.GetOrdinal("Id")),
                        Ime = reader.GetString(reader.GetOrdinal("Ime")),
                        Prezime = reader.GetString(reader.GetOrdinal("Prezime")),
                        Status = reader.GetString(reader.GetOrdinal("Status")),
                        Zvanje = reader.GetString(reader.GetOrdinal("Zvanje")),
                    };

                    result.Add(profesor);
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

        public void UpdateProfesor2(Profesor2 profesor)
        {
            try
            {
                _connection.Open();

                SqlCommand cmd = _connection.CreateCommand();

                cmd.CommandText = $"update Profesor2 set Ime=N'{profesor.Ime}', Prezime=N'{profesor.Prezime}', Zvanje=N'{profesor.Zvanje}' where Id={profesor.Id};";

                cmd.ExecuteNonQuery();

                _connection.Close();
            }
            catch (Exception)
            {
                _connection?.Close();
                throw;
            }
        }

        public List<Subject> GetSubjects()
        {
            try
            {
                List<Subject> result = new List<Subject>();

                _connection.Open();

                SqlCommand cmd = _connection.CreateCommand();
                cmd.CommandText = $"select * from Subject";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Subject obj = new Subject
                    {
                        Id = reader.GetInt64(reader.GetOrdinal("Id")),
                        Name = reader.GetString(reader.GetOrdinal("Name")),
                        ESPB = reader.GetInt32(reader.GetOrdinal("ESPB")),
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

        public List<long> GetSubjectIdsForProfesorIds(List<long> profesorIds)
        {
            try
            {
                List<long> result = new List<long>();
                if (profesorIds.Count == 0)
                    return result;

                _connection.Open();

                SqlCommand cmd = _connection.CreateCommand();
                cmd.CommandText = $"select * from Profesor2Predmet where Profesor2Id in ({string.Join(", ", profesorIds)})";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    long subjectId = reader.GetInt64(reader.GetOrdinal("PredmetId"));

                    result.Add(subjectId);
                }

                _connection.Close();

                return result.Distinct().ToList();
            }
            catch (Exception)
            {
                _connection?.Close();
                throw;
            }
        }

        public List<Subject> GetSubjects(List<long> ids)
        {
            try
            {
                List<Subject> result = new List<Subject>();
                if (ids.Count == 0)
                    return result;

                _connection.Open();

                SqlCommand cmd = _connection.CreateCommand();
                cmd.CommandText = $"select * from Subject where Id in ({string.Join(", ", ids)});";
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Subject obj = new Subject
                    {
                        Id = reader.GetInt64(reader.GetOrdinal("Id")),
                        Name = reader.GetString(reader.GetOrdinal("Name")),
                        ESPB = reader.GetInt32(reader.GetOrdinal("ESPB")),
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
    }

    public class Profesor2
    {
        public long Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Zvanje { get; set; }
        public string Status { get; set; }
    }

    public class Subject
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int ESPB { get; set; }
    }
}
