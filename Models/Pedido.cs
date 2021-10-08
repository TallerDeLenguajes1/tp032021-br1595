using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntidadesSistema
{
    public enum Estado
    {
        Entregado,
        NoEntregado,
        EnCurso,
    }
    public class Pedido
    {
        private int numero;
        private string observacion;
        private Cliente destinatario;
        private Estado estado;
        private string nombreCadete;



        public int Numero { get => numero; set => numero = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public Cliente Destinatario { get => destinatario; set => destinatario = value; }
        public Estado Estado { get => estado; set => estado = value; }
        public string NombreCadete { get => nombreCadete; set => nombreCadete = value; }

        public Pedido() { }
        public Pedido(int _Numero, string _Observacion, Estado _Estado, string _DNI, string _Nombre, string _Direccion, string _Telefono)
        {
            Destinatario = new Cliente(_DNI, _Nombre, _Direccion, _Telefono);
            Numero = _Numero;
            Observacion = _Observacion;
            Estado = _Estado;
        }

        public Pedido(int _Numero, string _Observacion, Estado _Estado, Cliente _Cliente)
        {
            Destinatario = new Cliente(_Cliente.Id, _Cliente.Nombre, _Cliente.Direccion, _Cliente.Telefono);
            Numero = _Numero;
            Observacion = _Observacion;
            Estado = _Estado;
        }

    }
}
