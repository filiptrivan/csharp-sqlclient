using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokvijum2023Termin1
{
    public class Controller
    {
        Broker _broker = new Broker();

        public long InsertPredmet(Predmet predmet)
        {
            return _broker.InsertPredmet(predmet);
        }

        public void UpdatePredmet(Predmet predmet)
        {
            _broker.UpdatePredmet(predmet);
        }

        public Predmet GetPredmet(long predmetId)
        {
            return _broker.GetPredmet(predmetId);
        }

        public List<Predmet> GetPredmetList()
        {
            return _broker.GetPredmetList();
        }


        public List<Katedra> GetKatedraList()
        {
            return _broker.GetKatedraList();
        }

        public Katedra GetKatedra(long id)
        {
            return _broker.GetKatedra(id);
        }
    }
}
