using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntidadesSistema;
using System.ComponentModel.DataAnnotations;

namespace EntidadesSistema
{
    public class PedidoViewModel
    {
        public int Numero;
        [Required(ErrorMessage = "El campo Observacion es requerido")]
        [StringLength(100)]
        public string Observacion;
        public int ClienteID;
        [Required(ErrorMessage = "El campo Estado es requerido")]
        [StringLength(100)]
        public string Estado;
        [Required(ErrorMessage = "El campo Dirección es requerido")]
        [StringLength(100)]
        public string Direccion;
        public int CodigoCadete;
        public List<Cadete> Cadetes { get; set; }
        public PedidoViewModel() { }
        public Pedido Pedido { get; set; }
}

    public class AltaPedidoViewModel
    {
        public int ClienteID;
        [Required(ErrorMessage = "El campo observación es requerido")]
        [StringLength(100)]
        public string Observacion { get; set; }
        [Required(ErrorMessage = "El campo dirección es requerido")]
        [StringLength(100)]
        public string Direccion { get; set; }
        public AltaPedidoViewModel() { }
    }

    public class ModifyPedidoViewModel
    {
        public int Numero;
        [Required(ErrorMessage = "El campo Observacion es requerido")]
        [StringLength(100)]
        public string Observacion;
        public int ClienteID;
        [Required(ErrorMessage = "El campo Estado es requerido")]
        [StringLength(100)]
        public string Estado;
        public int CodigoCadete;
        public ModifyPedidoViewModel() { }
    }
}
