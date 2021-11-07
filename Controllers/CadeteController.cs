using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using EntidadesSistema;
using tp032021_br1595.Models;

namespace tp032021_br1595.Controllers
{
    public class CadeteController : Controller
    {
        //private readonly DBTemporal _dB;
        private readonly ILogger<CadeteController> _logger;
        private readonly RepositorioCadete _dB;
        private readonly RepositorioCadeteria _dBC;
        public CadeteController(ILogger<CadeteController> logger,  RepositorioCadete DB, RepositorioCadeteria DBC /*DBTemporal DB*/)
        {
            _logger = logger;
            _dB = DB;
            _dBC = DBC;
        }
        public IActionResult Index()
        {
            //return View(_dB.ReadCadetesAlmacenados());
            return View(_dB.getAll());
        }

        public IActionResult AltaCadete()
        {
            return View(_dBC.getAll());
        }
        public ActionResult AgregarCadete()
        {
            return View(new Cadete());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AgregarCadete(Cadete _Cadete)
        {
            //_dB.SaveCadete(_Dni, _Nombre, _Direccion, _Telefono);
            _dB.addCadete(_Cadete);
            return Redirect("Index");
        }

        public IActionResult DeleteCadete(int _Id)
        {
            return View(_dB.getOne(_Id));
        }

        public IActionResult DeleteForGoodCadete(int _Id)
        {
            _dB.deleteCadete(_Id);
            return RedirectToAction("Index");
        }
    }
}
