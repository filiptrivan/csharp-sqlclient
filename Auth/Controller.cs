using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth
{
    public class Controller
    {
        private readonly BrokerBP _broker;

        List<User> users = new List<User>
        {
            new User{ Name="Filip", Surname="Trivan", Email="f", Password="t" },
            new User{ Name="Aleksa", Surname="Trivan", Email="a", Password="t" },
        };

        public Controller()
        {
            _broker = new BrokerBP();
        }

        public User Login(string email, string password)
        {
            User user = users.Where(x => x.Email == email && x.Password == password).SingleOrDefault();

            if (user == null)
                throw new BusinessException("Korisnik ne postoji u sistemu.");

            return user;
        }

        public void InsertProfesor(Profesor profesor, List<Subject> selectedSubjects)
        {
            long savedProfesorId = _broker.InsertProfesor(profesor);
            profesor.Id = savedProfesorId;

            foreach (Subject subject in selectedSubjects)
            {
                _broker.InsertProfesorSubject(new ProfesorSubject { ProfesorId = savedProfesorId, SubjectId = subject.Id });
            }
        }

        public void UpdateProfesor(Profesor profesor, List<Subject> selectedSubjects)
        {
            _broker.UpdateProfesor(profesor);
            _broker.DeleteAllSubjectsForProfesor(profesor.Id);

            foreach (Subject subject in selectedSubjects)
            {
                _broker.InsertProfesorSubject(new ProfesorSubject
                {
                    ProfesorId=profesor.Id,
                    SubjectId=subject.Id,
                });
            }
        }

        public void DeleteProfesor(long id)
        {
            _broker.DeleteProfesor(id);
        }

        public List<Level> GetLevels()
        {
            return _broker.GetLevels();
        }

        public List<Subject> GetSubjects()
        {
            return _broker.GetSubjects();
        }

        public List<Subject> GetSubjects(List<long> subjectIds)
        {
            return _broker.GetSubjects(subjectIds);
        }

        public List<ProfesorSubject> GetProfesorSubjects(long profesorId)
        {
            return _broker.GetProfesorSubjects(profesorId);
        }

        public List<Profesor> GetProfesors()
        {
            return _broker.GetProfesors();
        }
    }

    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class Profesor
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public long LevelId { get; set; }
        public string UserEmail { get; set; }
    }

    public class Subject
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int ESPB { get; set; }
    }

    public class ProfesorSubject
    {
        public long ProfesorId { get; set; }
        public long SubjectId { get; set; }
    }

    public class Level
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public class BusinessException : Exception
    {
        public BusinessException(string message)
            : base(message) { }
    }
}

