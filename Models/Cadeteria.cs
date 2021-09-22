using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntidadesSistema
{
    public class Cadeteria
    {
        //private List<Cadete> listadoCadetes = new List<Cadete>();
        private List<Cadete> cadetes;
        private List<Pedido> pedidos;
        public List<Cadete> Cadetes { get => cadetes; set => cadetes = value; }
        public List<Pedido> Pedidos { get => pedidos; set => pedidos = value; }
        //public string Nombre { get => nombre; set => nombre = value; }
        //public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }

        public Cadeteria(/*string _Nombre*/)
        {
            //this.nombre = _Nombre;
            Cadetes = new List<Cadete>();
            Pedidos = new List<Pedido>();
        }

    }
}
