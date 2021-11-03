using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntidadesSistema
{
    public class Cliente : Usuario
    {
        public Cliente() { }
        public Cliente(int _DNI, string _Nombre, string _Direccion, string _Telefono)
        {
            this.Id = _DNI;
            this.Nombre = _Nombre;
            this.Direccion = _Direccion;
            this.Telefono = _Telefono;
        }
    }
}
