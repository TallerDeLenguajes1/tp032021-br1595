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
        private int dni;
        private float totalPagos;
        private int cantidadEntregasRealizadas;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }
        public int Dni { get => dni; set => dni = value; }
        public float TotalPagos { get => totalPagos; set => totalPagos = value; }
        public int CantidadEntregasRealizadas { get => cantidadEntregasRealizadas; set => cantidadEntregasRealizadas = value; }

        public Cadete() 
        {
            ListadoPedidos = new List<Pedido>();
        }

        public Cadete(int _IdCadete, int _Dni, string _Nombre, string _Direccion, string _Telefono)
        {
            this.id = _IdCadete;
            this.dni = _Dni;
            this.Nombre = _Nombre;
            this.Direccion = _Direccion;
            this.Telefono = _Telefono;
            this.ListadoPedidos = new List<Pedido>();
            this.CantidadEntregasRealizadas = 0;
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
