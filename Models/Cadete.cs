using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntidadesSistema

{
    public class Cadete
    {
        private int id;
        private string nombre;
        private string direccion;
        private string telefono;
        private List<Pedido> listadoPedidos;
        private string cadeteriaId;
        private int pedidosRealizados;
        private int pedidosActivos;
        private int activo;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }
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
        }
    }
}
