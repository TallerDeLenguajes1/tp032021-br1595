using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using EntidadesSistema;
using tp032021_br1595.Models;
using tp032021_br1595.Models.Repostorios;
using AutoMapper;

namespace tp032021_br1595.Controllers
{
    public class CadeteController : Controller
    {
        private readonly DataContext _db;
        private readonly ILogger<CadeteController> _logger;
        private readonly IMapper mapper;
        public CadeteController(ILogger<CadeteController> logger,  DataContext DB, IMapper mapper)
        {
            _logger = logger;
            _db = DB;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            try
            {
                List<Cadete> listaCadetes = _db.Cadetes.getAll();
                var listCadetes = mapper.Map<List<CadeteViewModel>>(listaCadetes);
                return View(listCadetes);
            }
            catch(Exception ex)
            {
                string error = ex.ToString();
                return NotFound();
            }
        }

        public IActionResult IndexReadmit()
        {
            try
            {
                List<Cadete> listaCadetes = _db.Cadetes.getAll();
                var listCadetes = mapper.Map<List<CadeteViewModel>>(listaCadetes);
                return View(listCadetes);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return NotFound();
            }
        }

        public IActionResult AltaCadete()
        {
            try
            {
                List<Cadeteria> listaCadeterias = _db.Cadeterias.getAll();
                AltaCadeteViewModel listCadeterias = new AltaCadeteViewModel()
                {
                    ListaCadeterias = listaCadeterias
                };
                return View(listCadeterias);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return NotFound();
            }
        }
        public ActionResult AgregarCadete()
        {
            return View(new AltaCadeteViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AgregarCadete(AltaCadeteViewModel _Cadete)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var cadetedb = mapper.Map<Cadete>(_Cadete);
                    _db.Cadetes.addCadete(cadetedb);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction(nameof(AgregarCadete));
                }
            }
            catch
            {
                return NotFound();
            }
        }

        public IActionResult DeleteCadete(int _Id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Cadete cadete = _db.Cadetes.getOne(_Id, 0);
                    var cadeteVM = mapper.Map<DeleteCadeteViewModel>(cadete);
                    return View(cadeteVM);
                }
                else
                {
                    return RedirectToAction(nameof(ModifyCadete));
                }                
            }
            catch(Exception ex)
            {
                string error = ex.ToString();
                return NotFound();
            }
        }

        public IActionResult DeleteForGoodCadete(int _Id)
        {
            _db.Cadetes.deleteCadete(_Id);
            return RedirectToAction("Index");
        }

        public IActionResult ReadmitCadete(int _Id)
        {
            _db.Cadetes.readmitCadete(_Id);
            return RedirectToAction("Index");
        }

        public IActionResult ModifyCadete(int _Id)
        {
            try
            {
                var cadeteModificar = _db.Cadetes.getOneCadeteria(_Id, _db);
                return View(cadeteModificar);
            }
            catch
            {
                return NotFound();
            }
        }

        public IActionResult ModifyForGoodCadete(CadeteViewModel _Cadete)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var cadetedb = mapper.Map<Cadete>(_Cadete);
                    _db.Cadetes.modifyCadete(cadetedb);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction(nameof(ModifyCadete));
                }
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
