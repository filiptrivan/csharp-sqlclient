using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth
{
    public class BrokerBP
    {
        SqlConnection _connection;

        public BrokerBP()
        {
           _connection = new SqlConnection(Settings.ConnectionString);
        }

        public long InsertProfesor(Profesor profesor)
        {
            try
            {
                _connection.Open();

                SqlCommand comm = _connection.CreateCommand();
                comm.CommandText = $"insert into Profesor (Name, Surname, LevelId, UserEmail) output inserted.[Id] values (N'{profesor.Name}', N'{profesor.Surname}', {profesor.LevelId}, N'{profesor.UserEmail}');";

                long newId = (long)comm.ExecuteScalar();

                _connection.Close();

                return newId;
            }
            catch (Exception)
            {
                _connection?.Close();
                throw;
            }
        }

        public void UpdateProfesor(Profesor profesor)
        {
            try
            {
                _connection.Open();

                SqlCommand comm = _connection.CreateCommand();

                comm.CommandText = $"update Profesor set " +
                    $"Name = N'{profesor.Name}', " +
                    $"Surname = N'{profesor.Surname}', " +
                    $"LevelId = {profesor.LevelId}, " +
                    $"UserEmail = N'{profesor.UserEmail}' " +
                    $"where Id = {profesor.Id};";

                comm.ExecuteNonQuery();

                _connection.Close();
            }
            catch (Exception)
            {
                _connection?.Close();
                throw;
            }
        }

        public void DeleteAllSubjectsForProfesor(long profesorId)
        {
            try
            {
                List<Subject> result = new List<Subject>();

                _connection.Open();

                SqlCommand comm = _connection.CreateCommand();

                comm.CommandText = $"delete ProfesorSubject where ProfesorId = {profesorId};";

                comm.ExecuteNonQuery();

                _connection.Close();
            }
            catch (Exception)
            {
                _connection?.Close();
                throw;
            }
        }

        public void DeleteProfesor(long id)
        {
            try
            {
                List<Subject> result = new List<Subject>();

                _connection.Open();

                SqlCommand comm = _connection.CreateCommand();

                comm.CommandText = $"delete Profesor where Id = {id};";

                comm.ExecuteNonQuery();

                _connection.Close();
            }
            catch (Exception)
            {
                _connection?.Close();
                throw;
            }
        }

        public List<Profesor> GetProfesors()
        {
            try
            {
                List<Profesor> result = new List<Profesor>();

                _connection.Open();

                SqlCommand comm = _connection
                    .CreateCommand();

                comm.CommandText = $"select * from [Profesor];";

                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    Profesor obj = new Profesor
                    {
                        Id = reader.GetInt64(reader.GetOrdinal("Id")),
                        Name = reader.GetString(reader.GetOrdinal("Name")),
                        Surname = reader.GetString(reader.GetOrdinal("Surname")),
                        LevelId = reader.GetInt64(reader.GetOrdinal("LevelId")),
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

        public void InsertProfesorSubject(ProfesorSubject profesorSubject)
        {
            try
            {
                _connection.Open();

                SqlCommand comm = _connection.CreateCommand();
                comm.CommandText = $"insert into ProfesorSubject (ProfesorId, SubjectId) values ({profesorSubject.ProfesorId}, {profesorSubject.SubjectId});";
                comm.ExecuteNonQuery();

                _connection.Close();
            }
            catch (Exception)
            {
                _connection?.Close();
                throw;
            }
        }

        public List<ProfesorSubject> GetProfesorSubjects(long profesorId)
        {
            try
            {
                List<ProfesorSubject> result = new List<ProfesorSubject>();

                _connection.Open();

                SqlCommand comm = _connection.CreateCommand();
                comm.CommandText = $"select * from ProfesorSubject where ProfesorId = {profesorId};";

                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    ProfesorSubject obj = new ProfesorSubject
                    {
                        ProfesorId = reader.GetInt64(reader.GetOrdinal("ProfesorId")),
                        SubjectId = reader.GetInt64(reader.GetOrdinal("SubjectId"))
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

        public List<Level> GetLevels()
        {
            try
            {
                List<Level> result = new List<Level>();

                _connection.Open();

                SqlCommand comm = _connection
                    .CreateCommand();

                comm.CommandText = $"select * from [Level];";

                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    Level obj = new Level
                    {
                        Id = reader.GetInt64(reader.GetOrdinal("Id")),
                        Name = reader.GetString(reader.GetOrdinal("Name"))
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

        public List<Subject> GetSubjects()
        {
            try
            {
                List<Subject> result = new List<Subject>();

                _connection.Open();

                SqlCommand comm = _connection
                    .CreateCommand();

                comm.CommandText = $"select * from [Subject];";

                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    Subject obj = new Subject
                    {
                        Id = reader.GetInt64(reader.GetOrdinal("Id")),
                        Name = reader.GetString(reader.GetOrdinal("Name")),
                        Code = reader.GetString(reader.GetOrdinal("Code")),
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

        public List<Subject> GetSubjects(List<long> subjectIds)
        {
            try
            {
                List<Subject> result = new List<Subject>();

                _connection.Open();

                SqlCommand comm = _connection
                    .CreateCommand();

                comm.CommandText = $"select * from [Subject] where Id in ({string.Join(", ", subjectIds)});";

                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    Subject obj = new Subject
                    {
                        Id = reader.GetInt64(reader.GetOrdinal("Id")),
                        Name = reader.GetString(reader.GetOrdinal("Name")),
                        Code = reader.GetString(reader.GetOrdinal("Code")),
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
}
