using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntidadesSistema
{
    public class Usuario
    {
        private string nombre;
        private int clearance;

        public string Nombre { get => nombre; set => nombre = value; }
        public int Clearance { get => clearance; set => clearance = value; }
    }
}
