using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntidadesSistema;

namespace tp032021_br1595.Models.SQLite
{
    public interface IRepositorioClientes
    {
        List<Cliente> getAll();
        void addCliente(Cliente _Cliente);
        void deleteCliente(int _Cliente);
        void readmitCliente(int _Cliente);
    }
}
