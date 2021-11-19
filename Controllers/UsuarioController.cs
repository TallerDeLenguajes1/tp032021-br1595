using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using tp032021_br1595.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

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
            if(_dBU.StartLogin(_Username, _Contrasena))
            {
                HttpContext.Session.SetString("Usuario",_Username);
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
