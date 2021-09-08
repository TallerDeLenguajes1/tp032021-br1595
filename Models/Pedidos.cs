using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp032021_br1595.Models
{
    public class Pedidos
    {
        private int numero;
        private string observacion;
        private Cliente destinatario;
        private string estado;

        public int Numero { get => numero; set => numero = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public Cliente Destinatario { get => destinatario; set => destinatario = value; }
        public string Estado { get => estado; set => estado = value; }
    }
}
