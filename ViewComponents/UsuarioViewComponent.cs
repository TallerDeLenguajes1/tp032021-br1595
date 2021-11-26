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
            List<OpcionMenu> resultado;
            if (HttpContext.Session.GetString("Usuario") != null)
            {
                resultado = _dbu.ObtenerOpciones(Convert.ToInt32(HttpContext.Session.GetInt32("Clearance")));
            }    
            else
            {
                resultado = _dbu.ObtenerOpciones(0);
            }
            
            return Task.FromResult(resultado);
        }
    }
}