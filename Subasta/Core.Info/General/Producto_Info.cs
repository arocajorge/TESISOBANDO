using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Info.General
{
    public class Producto_Info
    {
        public decimal IdProducto { get; set; }
        public string pr_Codigo { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio")]
        [StringLength(1000, MinimumLength = 0, ErrorMessage = "el campo descripción debe tener máximo 1000")]
        public string pr_Descripcion { get; set; }
        public string pr_Observacion { get; set; }
        public bool pr_Estado { get; set; }
        [Required(ErrorMessage = "El campo grupo es obligatorio")]
        public int IdGrupo { get; set; }
        [Required(ErrorMessage = "El campo tipo es obligatorio")]
        public int IdCatalogoTipo { get; set; }
        [Required(ErrorMessage = "El campo marca es obligatorio")]
        public int IdCatalogoMarca { get; set; }
        [Required(ErrorMessage = "El campo modelo es obligatorio")]
        public int IdCatalogoModelo { get; set; }
        [Required(ErrorMessage = "El campo impuesto es obligatorio")]
        public int IdImpuestoIva { get; set; }
    }
}
