using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntidadesSistema
{
    public class Cadeteria
    {
        private List<Cadete> cadetes;
        private List<Pedido> pedidos;
        private string cadeteriaID;
        private string cadeteriaNombre;
        public List<Cadete> Cadetes { get => cadetes; set => cadetes = value; }
        public List<Pedido> Pedidos { get => pedidos; set => pedidos = value; }
        public string CadeteriaID { get => cadeteriaID; set => cadeteriaID = value; }
        public string CadeteriaNombre { get => cadeteriaNombre; set => cadeteriaNombre = value; }

        public Cadeteria() { }
        public Cadeteria(string _CadeteriaID, string _CadeteriaNombre)
        {
            this.cadeteriaID = _CadeteriaID;
            this.cadeteriaNombre = _CadeteriaNombre;
        }

    }
}
