using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp032021_br1595.Models;
using EntidadesSistema;

namespace tp032021_br1595.ViewComponents
{
    public class UsuarioViewComponent : ViewComponent
    {
        private readonly RepositorioUsuario _dbu;

        public UsuarioViewComponent(RepositorioUsuario dBU)
        {
            _dbu = dBU;
        }
        /*
        public async Task<IViewComponentResult> InvokeAsync(
        int maxPriority, bool isDone)
        {
            var items = await GetItemsAsync(maxPriority, isDone);
            return View(items);
        }/*
        private Task<List<string>> GetItemsAsync(int maxPriority, bool isDone)
        {
            return _dbu.ObtenerOpciones.Where(x => x.IsDone == isDone &&
                                 x.Priority <= maxPriority).ToListAsync();
        }*/
    }
}