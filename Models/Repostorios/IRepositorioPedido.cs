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
        void cancelPedido(int _CodigoPedido);
        void finishPedido(int _CodigoPedido);
        void AceptarPedido(int _CodigoPedido, int Codigo);
        PedidoViewModel getOneCadetesClientes(DataContext _DB);
        List<Pedido> getAllPedidosCliente(int _CodigoCliente);
        List<Pedido> getAllDisponibles();
        List<Pedido> getAllPedidosCadete(int _CodigoCliente);

    }
}
