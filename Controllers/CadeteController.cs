using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using EntidadesSistema;

namespace tp032021_br1595.Controllers
{
    public class CadeteController : Controller
    {
        static int id = 0;
        private readonly ILogger<CadeteController> _logger;
        private readonly DBTemporal _dB;
        public IActionResult Index()
        {
            return View(_dB.Cadeteria.Cadetes);
        }
        public CadeteController(ILogger<CadeteController> logger, DBTemporal DB)
        {
            _logger = logger;
            _dB = DB;
        }

        public IActionResult CreadorCadete()
        {
            return View();
        }
        public IActionResult AltaCadete(string _Nombre, string _Direccion, string _Telefono)
        {
            if (_Nombre != null || _Direccion != null || _Telefono != null)
            {
                Cadete nuevoCadete = new Cadete(id, _Nombre, _Direccion, _Telefono);
                id++;
                _dB.Cadeteria.Cadetes.Add(nuevoCadete);
                //Cambiar por db_listadoCadetes.Add(nuevoCadete);
                return Redirect("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
