using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntidadesSistema;

namespace EntidadesSistema
{
    public class PedidoCadetesViewModel
    {
        private List<Cadete> cadetes;
        private Pedido pedido;
        private List<Cliente> clientes;

        public List<Cadete> Cadetes { get => cadetes; set => cadetes = value; }
        public Pedido Pedido { get => pedido; set => pedido = value; }
        public List<Cliente> Clientes { get => clientes; set => clientes = value; }
    }
}
