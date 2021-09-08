using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp032021_br1595.Models
{
    public class Cadeteria
    {
        private string nombre;
        private List<Cadete> listadoCadetes;

        public string Nombre { get => nombre; set => nombre = value; }
        public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
    }
}
