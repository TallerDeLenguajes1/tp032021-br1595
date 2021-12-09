using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EntidadesSistema
{ 
    public class CadeteViewModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Nombre es requerido")]
        [StringLength(100)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo dirección es requerido")]
        [StringLength(100)]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "El campo telefono es requerido")]
        [StringLength(100)]
        public string Telefono { get; set; }
        public List<Pedido> ListadoPedidos { get; set; }
        [Required(ErrorMessage = "El campo Nombre es requerido")]
        [StringLength(100)]
        public string CadeteriaId { get; set; }
        public int PedidosRealizados { get; set; }
        public int PedidosActivos { get; set; }
        public int Activo { get; set; }
        public List<Cadeteria> ListaCadeterias { get; set; }
        public Cadete Cadete;
        public CadeteViewModel(){}
    }

    public class AltaCadeteViewModel
    {
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo dirección es requerido")]
        [StringLength(100)]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "El campo telefono es requerido")]
        [StringLength(100)]
        public string Telefono { get; set; }
        public List<Pedido> ListadoPedidos { get; set; }
        [Required(ErrorMessage = "El campo Nombre es requerido")]
        [StringLength(100)]
        public string CadeteriaId { get; set; }
        public List<Cadeteria> ListaCadeterias { get; set; }
        public AltaCadeteViewModel() { }
    }
   
    public class DeleteCadeteViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int PedidosRealizados { get; set; }
        public int PedidosActivos { get; set; }
        public DeleteCadeteViewModel() { }
    }
}
