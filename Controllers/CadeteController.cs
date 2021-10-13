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
        private readonly ILogger<CadeteController> _logger;
        private readonly DBTemporal _dB;
        public CadeteController(ILogger<CadeteController> logger, DBTemporal DB)
        {
            _logger = logger;
            _dB = DB;
        }
        public IActionResult Index()
        {
            return View(_dB.ReadCadetesAlmacenados());
        }

        public IActionResult AltaCadete()
        {
            return View();
        }
        public IActionResult AgregarCadete(int _IdCadete, int _Dni, string _Nombre, string _Direccion, string _Telefono)
        {
            _dB.SaveCadete(_Dni, _Nombre, _Direccion, _Telefono);
            return Redirect("Index");
        }

        public IActionResult DeleteCadete(int _Id)
        {
            Cadete cadeteToDelete = _dB.ObtenerUnCadete(_Id);
            return View(cadeteToDelete);
        }
    }
}
