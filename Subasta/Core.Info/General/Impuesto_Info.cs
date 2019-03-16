using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Info.General
{
    public class Impuesto_Info
    {
        public int IdImpuesto { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio")]
        [StringLength(1000, MinimumLength = 0, ErrorMessage = "el campo descripción debe tener máximo 1000")]
        public string im_Descripcion { get; set; }
        [Required(ErrorMessage = "El campo porcentaje es obligatorio")]
        public double im_Porcentaje { get; set; }
        public bool im_Estado { get; set; }
    }
}
