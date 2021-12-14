using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntidadesSistema
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int UsuarioID { get; set; }

        public Cliente() { }
        public Cliente(string _DNI, string _Nombre, string _Direccion, string _Telefono)
        {
            this.Nombre = _Nombre;
            this.Direccion = _Direccion;
            this.Telefono = _Telefono;
        }
    }
}
