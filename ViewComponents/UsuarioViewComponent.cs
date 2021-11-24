using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp032021_br1595.Models;
using EntidadesSistema;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;

namespace tp032021_br1595.ViewComponents
{
    [ViewComponent(Name = "Usuario")]
    public class UsuarioViewComponent : ViewComponent
    {
        private readonly RepositorioUsuario _dbu;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public UsuarioViewComponent(RepositorioUsuario dBU)
        {
            _dbu = dBU;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await GetItemsAsync();
            return View(items);
        }
        private Task<List<OpcionMenu>> GetItemsAsync()
        {
            var resultado = _dbu.ObtenerOpciones(Convert.ToInt32(_session.GetInt32("Clearance")));
            return Task.FromResult(resultado);
        }
    }
}