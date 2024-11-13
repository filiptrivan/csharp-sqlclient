using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24_11_2019
{
    public class Controller
    {
        Broker _broker;

        public Controller() 
        {
            _broker = new Broker();
        }

        #region Z2

        public List<Profesor2> GetProfesor2List()
        {
            return _broker.GetProfesor2List();
        }

        public void UpdateProfesor2(Profesor2 profesor)
        {
            _broker.UpdateProfesor2(profesor);
        }

        #endregion

        #region Z3

        public List<Subject> GetSubjects()
        {
            return _broker.GetSubjects();
        }

        public List<Subject> GetSubjectsForProfesorIds(List<long> profesorIds)
        {
            List<long> ids = _broker.GetSubjectIdsForProfesorIds(profesorIds);

            return _broker.GetSubjects(ids);
        }

        #endregion
    }
}
