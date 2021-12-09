using tp032021_br1595.Models;
using tp032021_br1595.Models.SQLite;

namespace tp032021_br1595.Models.Repostorios
{
    public class DataContext
    {
        public IRepositorioCadetes Cadetes { get; set; }
        public IRepositorioPedidos Pedidos { get; set; }
        public IRepositorioUsuarios Usuarios { get; set; }
        public IRepositorioClientes Clientes { get; set; }
        public IRepositorioCadeterias Cadeterias { get; set; }

        public DataContext(IRepositorioCadetes Cadetes, IRepositorioPedidos Pedidos, IRepositorioUsuarios Usuarios, IRepositorioClientes Clientes, IRepositorioCadeterias Cadeterias)
        {
            this.Cadetes = Cadetes;
            this.Pedidos = Pedidos;
            this.Usuarios = Usuarios;
            this.Clientes = Clientes;
            this.Cadeterias = Cadeterias;                 
        }
    }
}
