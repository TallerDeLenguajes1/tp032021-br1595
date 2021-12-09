using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntidadesSistema
{
    public class Cadeteria
    {
        public string CadeteriaID { get; set; }
        public string CadeteriaNombre { get; set; }
        public Cadeteria() { }
        public Cadeteria(string _CadeteriaID, string _CadeteriaNombre)
        {
            this.CadeteriaID = _CadeteriaID;
            this.CadeteriaNombre = _CadeteriaNombre;
        }

    }
}
