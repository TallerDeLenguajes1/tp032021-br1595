using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntidadesSistema;

namespace tp032021_br1595.Models.SQLite
{
    public interface IRepositorioCadeterias
    {        
        List<Cadeteria> getAll();
    }
}
