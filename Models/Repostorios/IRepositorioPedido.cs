using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntidadesSistema;
using tp032021_br1595.Models.Repostorios;

namespace tp032021_br1595.Models.SQLite
{
    public interface IRepositorioPedidos
    {
        List<Pedido> getAll();
        void addPedido(Pedido _Pedido);
        void addPedidoCadete(Pedido _Pedido, Cadete _Cadete);
        void cancelPedido(Pedido _Pedido);
        void finishPedido(Pedido _Pedido);
        PedidoViewModel getOneCadetesClientes(DataContext _DB);

    }
}
