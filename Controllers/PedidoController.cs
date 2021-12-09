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
        public IActionResult AgregarPedido(string Observacion)
        {
            try
            {
                Pedido pedido = new Pedido()
                {
                    ClienteID = Convert.ToInt32(HttpContext.Session.GetString("UsuarioID")),
                    Observacion = Observacion

                };
                _db.Pedidos.addPedido(pedido);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return NotFound();
            }
        }

        public IActionResult ListaPedidos()
        {
            return View(_db.Pedidos.getAll());
        }
    }
}
