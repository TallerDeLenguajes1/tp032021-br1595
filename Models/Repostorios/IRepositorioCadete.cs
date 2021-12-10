using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntidadesSistema;
using tp032021_br1595.Models.Repostorios;

namespace tp032021_br1595.Models.SQLite
{
    public interface IRepositorioCadetes
    {
        List<Cadete> getAll();
        Cadete getOne(int _CadeteCodigo, int _CodigoUsuario);
        CadeteViewModel getOneCadeteria(int _CadeteCodigo, DataContext _db);
        void addCadete(Cadete _Cadete);
        void modifyCadete(Cadete _Cadete);
        void readmitCadete(int _CadeteCodigo);
        void deleteCadete(int _CadeteCodigo);
    }
}
