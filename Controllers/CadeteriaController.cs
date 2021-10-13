using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using EntidadesSistema;

namespace tp032021_br1595.Controllers
{
    public class CadeteriaController : Controller
    {
        private readonly ILogger<CadeteriaController> _logger;
        private readonly DBTemporal _dB;

        public CadeteriaController(ILogger<CadeteriaController> logger, DBTemporal DB) 
        {
            _logger = logger;
            _dB = DB;
        }
        public IActionResult Index()
        {
            return View(_dB.ReadCadetesAlmacenados());
        }
    }
}
