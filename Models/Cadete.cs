using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp032021_br1595.Models
{
    public class Cadete
    {
        private int id;
        private string nombre;
        private string direccion;
        private string telefono;
        private List<Pedidos> listadoPedidos;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public List<Pedidos> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }
    }
}
