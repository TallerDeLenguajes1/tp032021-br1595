using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp032021_br1595.Models
{
    public class Cadete
    {
        private static int NumeroCadete = 0;

        private int id;
        private string nombre;
        private string direccion;
        private string telefono;
        private List<Pedidos> listadoPedidos;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        

        public Cadete() { }

        public Cadete(string _Nombre, string _Direccion, string _Telefono)
        {
            this.id = NumeroCadete++;
            this.Nombre = _Nombre;
            this.Direccion = _Direccion;
            this.Telefono = _Telefono;
        }

        public void AgregarPedido(Pedidos _Pedido)
        {
            listadoPedidos.Add(_Pedido);
        }

        public void QuitarPedido() { }
    }
}
