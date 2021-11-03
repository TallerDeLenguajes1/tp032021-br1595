using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntidadesSistema
{
    public class Pedido
    {
        private int numero;
        private string observacion;
        private int clienteID;
        private string estado;
        private int codigoCadete;

        public int Numero { get => numero; set => numero = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public int ClienteID { get => clienteID; set => clienteID = value; }
        public string Estado { get => estado; set => estado = value; }
        public int CodigoCadete { get => codigoCadete; set => codigoCadete = value; }

        public Pedido() { }
        public Pedido(int _Numero, string _Observacion, string _Estado, int _ClienteID)
        {
            this.ClienteID = _ClienteID;
            this.Numero = _Numero;
            this.Observacion = _Observacion;
            this.Estado = _Estado;
            this.CodigoCadete = 0;
        }
    }
}
