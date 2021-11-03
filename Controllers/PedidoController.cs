using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using EntidadesSistema;

namespace tp032021_br1595.Controllers
{
    public class PedidoController : Controller
    {
        private readonly ILogger<PedidoController> _logger;
        private readonly DBTemporal _dB;

        public PedidoController(ILogger<PedidoController> logger, DBTemporal DB) 
        {
            _logger = logger;
            _dB = DB;
        }
        public IActionResult Index()
        {
            //return View(_dB.ReadCadetesAlmacenados());
            return View();
        }

        public IActionResult AgregarPedido(string _Observacion, int _DNI, string _Nombre, string _Direccion, string _Telefono, int _CodigoCadete)
        {
            string estado = "En curso";
            //int numero = _dB.ReadPedidosAlmacenados().Count() + 1;
            //_dB.AddPedido(numero, _Observacion, estado, _DNI, _Nombre, _Direccion, _Telefono, _CodigoCadete);

            return Redirect("Index");
        }

        public IActionResult ListaPedidos()
        {
            //return View(_dB.ReadPedidosAlmacenados());
            return View();
        }
    }
}
