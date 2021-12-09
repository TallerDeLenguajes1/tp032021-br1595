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
using tp032021_br1595.Models.Repostorios;

namespace tp032021_br1595.ViewComponents
{
    [ViewComponent(Name = "Usuario")]
    public class UsuarioViewComponent : ViewComponent
    {
        private readonly DataContext _db;

        public UsuarioViewComponent(DataContext db)
        {
            _db = db;
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
                resultado = _db.Usuarios.ObtenerOpciones(Convert.ToInt32(HttpContext.Session.GetInt32("Clearance")));
            }    
            else
            {
                resultado = _db.Usuarios.ObtenerOpciones(0);
            }
            
            return Task.FromResult(resultado);
        }
    }
}