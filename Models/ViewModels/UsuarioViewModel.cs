using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EntidadesSistema
{
    public class AltaUsuarioViewModel
    {

        [Required(ErrorMessage = "Este Campo es requerido")]
        [StringLength(100, ErrorMessage = "El campo debe tener como máximo {0}")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este Campo es requerido")]
        [StringLength(10, ErrorMessage = "El campo debe tener como máximo {0}")]
        public string Contrasenia { get; set; }

        [Required(ErrorMessage = "Este Campo es requerido")]
        [EmailAddress(ErrorMessage = "El campo no coincide con un email válido")]
        public string Email { get; set; }
        public AltaUsuarioViewModel()
        {
        }
    }

    public class UsuarioViewModel
    {
        public int UsuarioID { get; set; }
        public int Clearance { get; set; }

        [Required(ErrorMessage = "Este Campo es requerido")]
        [StringLength(200, ErrorMessage = "El campo debe tener como máximo {0}")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este Campo es requerido")]
        [EmailAddress(ErrorMessage = "El campo no coincide con un email válido")]
        public string Email { get; set; }
        public string Contrasenia { get; set; }
        public List<UsuarioViewModel> Usuarios { get; set; }
        public UsuarioViewModel()
        {
        }
    }
    public class EditUsuarioViewModel
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Este Campo es requerido")]
        [StringLength(200, ErrorMessage = "El campo debe tener como máximo {0}")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este Campo es requerido")]
        [StringLength(10, ErrorMessage = "El campo debe tener como máximo {0}")]
        public string Contrasenia { get; set; }

        [Required(ErrorMessage = "Este Campo es requerido")]
        [EmailAddress(ErrorMessage = "El campo no coincide con un email válido")]
        public string Email { get; set; }
        public EditUsuarioViewModel()
        {
        }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Este Campo es requerido")]
        [StringLength(200, ErrorMessage = "El campo debe tener como máximo {0}")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este Campo es requerido")]
        [StringLength(10, ErrorMessage = "El campo debe tener como máximo {0}")]
        public string Contrasenia { get; set; }

        public LoginViewModel(){}

    }
}
