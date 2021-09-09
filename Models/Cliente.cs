using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp032021_br1595.Models
{
    public class Cliente
    {
        private static int NumeroCliente = 0;

        private int id;
        private string nombre;
        private string direccion;
        private string telefono;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
    
        void AgregarCliente(string _Nombre, string _Direccion, string _Telefono)
        {
            this.id = NumeroCliente++;
            this.Nombre = _Nombre;
            this.Direccion = _Direccion;
            this.Telefono = _Telefono;
        }
    }
}
