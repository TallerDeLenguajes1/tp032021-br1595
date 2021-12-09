using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntidadesSistema
{
    public class Usuario
    {
        public string UsuarioID { get; set; }
        public string Nombre { get; set; }
        public int Clearance { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }
    }
}
