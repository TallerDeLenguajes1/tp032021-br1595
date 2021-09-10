using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using tp032021_br1595.Models;

namespace tp032021_br1595.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly List<Cadete> _listadoCadetes;/*No olvidar de agregar*/

        public HomeController(ILogger<HomeController> logger, List<Cadete> ListadoCadetes)
        {
            _logger = logger;
            _listadoCadetes = ListadoCadetes;
        }

        public IActionResult Index()
        {
            return View(_listadoCadetes);
        }

        public IActionResult DarAltaCadete(string _Nombre, string _Direccion, string _Telefono)
        {
            if(_Nombre != null || _Direccion != null || _Telefono  != null)
            {
                Cadete nuevoCadete = new Cadete(_Nombre, _Direccion, _Telefono);
                _listadoCadetes.Add(nuevoCadete);
                return View();
            }
            else
            {
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
