using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using tp032021_br1595.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using EntidadesSistema;

namespace tp032021_br1595.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly RepositorioUsuario _dBU;
        public UsuarioController(ILogger<UsuarioController> logger, RepositorioUsuario DBU)
        {
            _logger = logger;
            _dBU = DBU;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string _Username, string _Contrasena)
        {
            Usuario usuario = _dBU.StartLogin(_Username, _Contrasena);
            if (usuario.Clearance != 0)
            {
                HttpContext.Session.SetString("Usuario",_Username);
                HttpContext.Session.SetInt32("Clearance", usuario.Clearance);
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
