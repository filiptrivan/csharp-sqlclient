using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27._12._2023_server
{
    public class BrokerBazePodataka
    {
        SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=27_12_2023;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        public List<User> GetUsers()
        {
            conn.Open();

            SqlCommand command = conn.CreateCommand();
            command.Transaction = conn.BeginTransaction();

            try
            {
                command.CommandText = $"select * from [User]";

                var r = command.ExecuteReader();

                List<User> users = new();

                while (r.Read())
                {
                    users.Add(new User
                    {
                        id = (long)r.GetValue(0),
                        username = (string)r.GetValue(1),
                        password = (string)r.GetValue(2)
                    });
                }
                r.Close();

                command.Transaction.Commit();
                conn.Close();

                return users;
            }
            catch (Exception)
            {
                command.Transaction.Rollback();
                conn?.Close();
                throw;
            }
        }

        public User Login(User login)
        {
            return GetUsers().Where(x => x.username == login.username && x.password == login.password).FirstOrDefault();
        }


        public class User
        {
            public long id { get; set; }
            public string username { get; set; }

            public string password { get; set; }
        }
    }
}
