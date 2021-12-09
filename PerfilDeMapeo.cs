using AutoMapper;
using EntidadesSistema;

namespace SistemaDeCadeterias
{
    public class PerfilDeMapeo : Profile
    { 
        public PerfilDeMapeo()
        {
            //mapeos para pedidos
            CreateMap<Pedido, PedidoViewModel>().ReverseMap();
            CreateMap<Pedido, AltaPedidoViewModel>().ReverseMap();
            CreateMap<Pedido, ModifyPedidoViewModel>().ReverseMap();

            //mapeos para cadetes
            CreateMap <Cadete, AltaCadeteViewModel>().ReverseMap();
            CreateMap<Cadete, DeleteCadeteViewModel > ().ReverseMap();
            CreateMap<Cadete, CadeteViewModel>().ReverseMap();

            //mapeos para usuarios
            CreateMap<Usuario, AltaUsuarioViewModel>().ReverseMap();
            CreateMap<Usuario, EditUsuarioViewModel>().ReverseMap();
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
            CreateMap<Usuario, LoginViewModel>().ReverseMap();
        }
    }
}
