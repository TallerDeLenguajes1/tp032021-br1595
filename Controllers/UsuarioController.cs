
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
using tp032021_br1595.Models.Repostorios;
using AutoMapper;

namespace tp032021_br1595.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly DataContext _db;
        private readonly ILogger<UsuarioController> _logger;
        private readonly IMapper mapper;
        public UsuarioController(ILogger<UsuarioController> logger, DataContext DB, IMapper mapper)
        {
            _logger = logger;
            _db = DB;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            try
            {
                List<Usuario> listadoUsuarios = _db.Usuarios.GetAll();
                var listUsuariosViewModel = mapper.Map<List<UsuarioViewModel>>(listadoUsuarios);
                return View(listUsuariosViewModel);
            }
            catch
            {
                return NotFound();
            }
        }

        public ActionResult AltaUsuario()
        {
            return View(new AltaUsuarioViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AltaUsuario(AltaUsuarioViewModel _Usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuariodb = mapper.Map<Usuario>(_Usuario);
                    if (_db.Usuarios.controlNombre(usuariodb.Nombre))
                    {
                        usuariodb.Clearance = 4;
                        _db.Usuarios.addUsuario(usuariodb);
                        usuariodb.UsuarioID = _db.Usuarios.getID(usuariodb.Nombre).ToString();
                        Cliente clientedb = new Cliente()
                        {
                            Nombre = usuariodb.Nombre,
                            Direccion = _Usuario.Direccion,
                            UsuarioID = Convert.ToInt32(usuariodb.UsuarioID),
                            Telefono = _Usuario.Telefono
                        };
                        _db.Clientes.addCliente(clientedb);
                        return RedirectToAction(nameof(Index), "Home");
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return RedirectToAction(nameof(AltaUsuario));
                }
            }
            catch
            {
                return NotFound();
            }
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string _Username, string _Contrasena)
        {
            try
            {
                Usuario usuario = _db.Usuarios.StartLogin(_Username, _Contrasena);
                if (usuario.Clearance != 0)
                {
                    HttpContext.Session.SetString ("Usuario", _Username);
                    HttpContext.Session.SetInt32("Clearance", usuario.Clearance);
                    HttpContext.Session.SetString("UsuarioID", usuario.UsuarioID);
                    if(usuario.Clearance == 3)
                    {
                        usuario.Codigo = _db.Usuarios.obtenerCodigo(Convert.ToInt32(usuario.UsuarioID));
                        HttpContext.Session.SetString("Codigo", usuario.Codigo);
                    }
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch(Exception ex)
            {
                string error = ex.ToString();
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
