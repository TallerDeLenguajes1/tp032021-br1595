using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntidadesSistema;

namespace EntidadesSistema

{
    public class Cadete : Usuario
    {
        private List<Pedido> listadoPedidos;
        private decimal totalPagos;
        private string cadeteriaId;
        private int pedidosRealizados;
        private int pedidosActivos;
        private int activo;

        public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }
        public decimal TotalPagos { get => totalPagos; set => totalPagos = value; }
        public string CadeteriaId { get => cadeteriaId; set => cadeteriaId = value; }
        public int PedidosRealizados { get => pedidosRealizados; set => pedidosRealizados = value; }
        public int PedidosActivos { get => pedidosActivos; set => pedidosActivos = value; }
        public int Activo { get => activo; set => activo = value; }

        public Cadete() 
        {
            ListadoPedidos = new List<Pedido>();
        }

        public Cadete(int _IdCadete, string _Nombre, string _Direccion, string _Telefono)
        {
            this.Id = _IdCadete;
            this.Nombre = _Nombre;
            this.Direccion = _Direccion;
            this.Telefono = _Telefono;
            this.ListadoPedidos = new List<Pedido>();
            this.Activo = 1;
            this.TotalPagos = 0;
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
