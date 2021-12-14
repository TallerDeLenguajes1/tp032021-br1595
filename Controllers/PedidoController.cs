using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using EntidadesSistema;
using Microsoft.AspNetCore.Http;
using tp032021_br1595.Models;
using tp032021_br1595.Models.Repostorios;
using AutoMapper;

namespace tp032021_br1595.Controllers
{
    public class PedidoController : Controller
    {
        private readonly DataContext _db;
        private readonly ILogger<PedidoController> _logger;
        private readonly IMapper mapper;

        public PedidoController(ILogger<PedidoController> logger, DataContext DB, IMapper mapper)
        {
            _logger = logger;
            _db = DB;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            try
            {
                List<Pedido> listadoPedidos = _db.Pedidos.getAll();
                var listPedidoViewModel = mapper.Map<List<PedidoViewModel>>(listadoPedidos);
                return View(listPedidoViewModel);
            }
            catch
            {
                return NotFound();
            }
        }

        public IActionResult AltaPedido()
        {///VER
            return View(_db.Pedidos.getOneCadetesClientes(_db));
        }
        public IActionResult AgregarPedido()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AgregarPedido(string Observacion, string Direccion)
        {
            try
            {
                Pedido pedido = new Pedido()
                {
                    ClienteID = Convert.ToInt32(HttpContext.Session.GetString("UsuarioID")),
                    Direccion = Direccion,
                    Observacion = Observacion

                };
                _db.Pedidos.addPedido(pedido);
                if(HttpContext.Session.GetInt32("Clearance") != 1)
                {
                    return RedirectToAction(nameof(EstadoPedidos));
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return NotFound();
            }
        }
        public IActionResult ListaPedidos()
        {
            try
            {
                List<Pedido> listadoPedidos = _db.Pedidos.getAllDisponibles();
                var listPedidoViewModel = mapper.Map<List<PedidoViewModel>>(listadoPedidos);
                return View(listPedidoViewModel);
            }
            catch
            {
                return NotFound();
            }
        }

        public IActionResult CancelarPedido(int _Id)
        {
            _db.Pedidos.cancelPedido(_Id);
            if(HttpContext.Session.GetInt32("Clearance") == 3)
            {
                return RedirectToAction("ListaPedidosCadete");
            }
            else
            {
                return RedirectToAction("EstadoPedidos");
            }

        }
        public IActionResult AceptarPedido(int _Id)
        {
            _db.Pedidos.AceptarPedido(_Id, Convert.ToInt32(HttpContext.Session.GetString("Codigo")));
            _db.Cadetes.CantidadPedidosActivos(Convert.ToInt32(HttpContext.Session.GetString("Codigo")));
            return RedirectToAction("ListaPedidos");
        }

        public IActionResult completarPedido(int _Id)
        {
            _db.Pedidos.finishPedido(_Id);
            _db.Cadetes.CantidadPedidosRealizados(Convert.ToInt32(HttpContext.Session.GetString("Codigo")));
            return RedirectToAction("ListaPedidosCadete");
        }
        public IActionResult ListaPedidosCadete()
        {
            try
            {
                List<Pedido> listadoPedidos = _db.Pedidos.getAllPedidosCadete(Convert.ToInt32(HttpContext.Session.GetString("Codigo")));
                var listPedidoViewModel = mapper.Map<List<PedidoViewModel>>(listadoPedidos);
                return View(listPedidoViewModel);
            }
            catch
            {
                return NotFound();
            }
        }
        public IActionResult EstadoPedidos()
        {
            try
            {
                List<Pedido> listadoPedidos = _db.Pedidos.getAllPedidosCliente(Convert.ToInt32(HttpContext.Session.GetString("UsuarioID")));
                var listPedidoViewModel = mapper.Map<List<PedidoViewModel>>(listadoPedidos);
                return View(listPedidoViewModel);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
