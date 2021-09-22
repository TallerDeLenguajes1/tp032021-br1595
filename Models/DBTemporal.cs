using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesSistema
{
    public class DBTemporal
    {

        public Cadeteria Cadeteria { get; set; }

        public DBTemporal()
        {
            this.Cadeteria = new Cadeteria();
        }
    }
}
