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
        static int numeroPedido = 0;
        private readonly ILogger<PedidoController> _logger;
        private readonly DBTemporal _dB;

        public PedidoController(ILogger<PedidoController> logger, DBTemporal DB) 
        {
            _logger = logger;
            _dB = DB;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AgregarPedido(string _Observacion, string _Estado, string _DNI, string _Nombre, string _Direccion, string _Telefono)
        {
            Pedido nuevoPedido = new Pedido(numeroPedido, _Observacion, _Estado, _DNI, _Nombre, _Direccion, _Telefono);
            int totalCadetes = _dB.Cadeteria.Cadetes.Count();
             Random cualquiera = new Random();
             int idCadete = cualquiera.Next(totalCadetes + 1);            
             
            Cadete cadeteElegido = _dB.Cadeteria.Cadetes.Find(x => x.Id == idCadete);
            if(cadeteElegido != null)
            {
                cadeteElegido.ListadoPedidos.Add(nuevoPedido);
            }
            return Redirect("Index");
        }

        public IActionResult ListaPedidos()
        {
            return View(_dB.Cadeteria.Pedidos);
        }
    }
}
