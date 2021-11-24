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
    public class PedidoController : Controller
    {
        private readonly ILogger<PedidoController> _logger;
        //private readonly DBTemporal _dB;
        private readonly RepositorioPedido _dBP;
        private readonly RepositorioCadete _dB;
        private readonly RepositorioCliente _dBCL;

        public PedidoController(ILogger<PedidoController> logger, RepositorioPedido DBP/*DBTemporal DB*/, RepositorioCadete DB, RepositorioCliente DBCL) 
        {
            _logger = logger;
            _dBP = DBP;
            _dB = DB;
            _dBCL = DBCL;
        }
        public IActionResult Index()
        {
            return View(_dBP.getAll());
        }

        public IActionResult AltaPedido()
        {
            return View(_dBP.getOneCadetesClientes(_dB, _dBCL));
        }
        public IActionResult AgregarPedido()
        {
            return View(new Pedido());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AgregarPedido(Pedido _Pedido)
        {
            //string estado = "En curso";
            //int numero = _dB.ReadPedidosAlmacenados().Count() + 1;
            //_dB.AddPedido(numero, _Observacion, estado, _DNI, _Nombre, _Direccion, _Telefono, _CodigoCadete);
            _dBP.addPedido(_Pedido);
            return Redirect("Index");
        }

        public IActionResult ListaPedidos()
        {
            //return View(_dB.ReadPedidosAlmacenados());
            return View();
        }
    }
}
