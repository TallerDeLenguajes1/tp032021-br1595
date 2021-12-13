using System.Collections.Generic;
using EntidadesSistema;

namespace tp032021_br1595.Models.SQLite
{
    public interface IRepositorioUsuarios
    {
        List<Usuario> GetAll();
        Usuario StartLogin(string _Username, string _Contrasena);
        List<OpcionMenu> ObtenerOpciones(int id);
        void addUsuario(Usuario _Usuario);
        string obtenerCodigo(int _Codigo);
        int getID(string cadeteNombre);
        bool controlNombreCadete(string cadeteNombre);
    }
}
