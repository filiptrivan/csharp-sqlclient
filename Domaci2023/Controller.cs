using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci2023
{
    public class Controller
    {
        Broker _broker;

        public Controller()
        {
            _broker = new Broker();
        }

        public long InsertNastavnik(Nastavnik nastavnik)
        {
            return _broker.InsertNastavnik(nastavnik);
        }

        public void UpdateNastavnik(Nastavnik nastavnik)
        {
            _broker.UpdateNastavnik(nastavnik);
        }

        public void DeleteNastavnik(long nastavnikId)
        {
            _broker.DeleteNastavnik(nastavnikId);
        }

        public List<Nastavnik> GetNastavnikList()
        {
            return _broker.GetNastavnikList();
        }

        public Nastavnik GetNastavnik(long nastavnikId)
        {
            return _broker.GetNastavnik(nastavnikId);
        }

        public List<Zvanje> GetZvanjeList()
        {
            return _broker.GetZvanjeList();
        }

        public Zvanje GetZvanje(long zvanjeId)
        {
            return _broker.GetZvanje(zvanjeId);
        }
    }
}
