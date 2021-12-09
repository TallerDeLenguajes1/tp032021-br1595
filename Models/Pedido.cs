using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntidadesSistema
{
    public class Pedido
    {
        public int Numero { get; set; }
        public string Observacion { get; set; }
        public int ClienteID { get; set; }
        public string Estado { get; set; }
        public int CodigoCadete { get; set; }
        public string Direccion { get; set; }
        public Pedido() { }
        public Pedido(int _Numero, string _Observacion, string _Estado, int _ClienteID, string _Direccion)
        {
            this.ClienteID = _ClienteID;
            this.Numero = _Numero;
            this.Observacion = _Observacion;
            this.Estado = _Estado;
            this.Direccion = _Direccion;
            this.CodigoCadete = 0;
        }
    }
}
