using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using EntidadesSistema;
using tp032021_br1595.Models.Repostorios;
using AutoMapper;

namespace tp032021_br1595.Controllers
{
    public class CadeteriaController : Controller
    {
        private readonly DataContext _db;
        private readonly ILogger<CadeteriaController> _logger;
        private readonly IMapper mapper;

        public CadeteriaController(ILogger<CadeteriaController> logger, DataContext DB)
        {
            _logger = logger;
            _db = DB;
        }
        public IActionResult Index()
        {
            return View(/*_dB.ReadCadetesAlmacenados()*/);
        }
    }
}
