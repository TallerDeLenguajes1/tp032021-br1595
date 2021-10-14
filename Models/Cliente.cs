using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntidadesSistema
{
    public class Cliente
    {

        private string id;
        private string nombre;
        private string direccion;
        private string telefono;

        public string Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }

        public Cliente() { }
        public Cliente(string _DNI, string _Nombre, string _Direccion, string _Telefono)
        {
            Id = _DNI;
            Nombre = _Nombre;
            Direccion = _Direccion;
            Telefono = _Telefono;
        }
    }
}
