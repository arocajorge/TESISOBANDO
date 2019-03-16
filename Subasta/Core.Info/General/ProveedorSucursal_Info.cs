using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Info.General
{
    public class ProveedorSucursal_Info
    {
        public decimal IdProveedor { get; set; }
        public int Secuencia { get; set; }
        [Required(ErrorMessage = "El campo código es obligatorio")]
        [StringLength(10, MinimumLength = 0, ErrorMessage = "el campo código debe tener máximo 10")]
        public string ps_CodigoEstablecimiento { get; set; }
        public string ps_Direccion { get; set; }
        public string ps_Telefono { get; set; }
        [Required(ErrorMessage = "El campo correo es obligatorio")]
        [StringLength(200, MinimumLength = 0, ErrorMessage = "el campo correo debe tener máximo 200")]
        public string ps_Correo { get; set; }
        public bool ps_Estado { get; set; }
    }
}
