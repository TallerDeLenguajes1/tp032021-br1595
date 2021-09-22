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
        private Cliente destinatario;
        private string estado;

        public int Numero { get => numero; set => numero = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public Cliente Destinatario { get => destinatario; set => destinatario = value; }
        public string Estado { get => estado; set => estado = value; }


        public Pedido() { }
        public Pedido(int _Numero, string _Observacion, string _Estado, string _DNI, string _Nombre, string _Direccion, string _Telefono)
        {
            Destinatario = new Cliente(_DNI, _Nombre, _Direccion, _Telefono);
            Numero = _Numero;
            Observacion = _Observacion;
            Estado = _Estado;
        }

    }
}
