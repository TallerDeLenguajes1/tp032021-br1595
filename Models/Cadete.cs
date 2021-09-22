using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntidadesSistema;

namespace EntidadesSistema

{
    public class Cadete
    {

        private int id;
        private string nombre;
        private string direccion;
        private string telefono;
        private List<Pedido> listadoPedidos;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }


        public Cadete() 
        {
            ListadoPedidos = new List<Pedido>();
        }

        public Cadete(int NumeroCadete, string _Nombre, string _Direccion, string _Telefono)
        {
            this.id = NumeroCadete;
            this.Nombre = _Nombre;
            this.Direccion = _Direccion;
            this.Telefono = _Telefono;
            this.ListadoPedidos = new List<Pedido>();
        }


        public void AgregarPedido(Pedido _Pedido)
        {
            ListadoPedidos.Add(_Pedido);
        }

        public void EliminarPedido(Pedido _Pedido)
        {
            ListadoPedidos.Remove(_Pedido);
        }

    }
}
