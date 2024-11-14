using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cet09
{
    public class Controller
    {
        Broker _broker = new Broker();

        public List<Rec> GetRecList()
        {
            return _broker.GetRecList();
        }

        public List<Prevod> GetPrevodList(long recid)
        {
            return _broker.GetPrevodList(recid);
        }

        public List<Jezik> GetJezikList()
        {
            return _broker.GetJezikList();
        }

        public List<Prevod> GetPrevodList(long? recid, long? jezikid)
        {
            return _broker.GetPrevodList(recid, jezikid);
        }

        public void InsertPrevodi(long recid, long jezikid, string prevodi)
        {
            _broker.InsertPrevodi(recid, jezikid, prevodi);
        }
    }
}
