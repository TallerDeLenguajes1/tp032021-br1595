using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntidadesSistema
{ 
    public class CadeteCadeteriasViewModel
    {
        private List<Cadeteria> listaCadeterias;
        private Cadete cadete;

        public List<Cadeteria> ListaCadeterias { get => listaCadeterias; set => listaCadeterias = value; }
        public Cadete Cadete { get => cadete; set => cadete = value; }


    }
}
