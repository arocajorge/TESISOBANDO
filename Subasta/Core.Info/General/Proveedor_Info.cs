using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Info.General
{
    public class Proveedor_Info
    {
        public decimal IdProveedor { get; set; }
        public string pv_Codigo { get; set; }
        [Required(ErrorMessage = "El campo tipo de documento es obligatorio")]
        public string pv_TipoDoc { get; set; }
        [Required(ErrorMessage = "El campo cédula es obligatorio")]
        public string pv_CedulaRuc { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio")]
        [StringLength(1000, MinimumLength = 0, ErrorMessage = "el campo descripción debe tener máximo 1000")]
        public string pv_Descripcion { get; set; }
        [Required(ErrorMessage = "El campo correo es obligatorio")]
        public string pv_Correo { get; set; }
        public string pv_Telefono { get; set; }
        public string pv_Direccion { get; set; }
        [Required(ErrorMessage = "El campo plazo es obligatorio")]
        public int pv_Plazo { get; set; }
        public bool pv_Estado { get; set; }
    }
}
