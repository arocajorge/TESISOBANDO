using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Info.General
{
    public class Linea_Info
    {
        public int IdLinea { get; set; }
        [Required(ErrorMessage = "El campo línea es obligatorio")]
        public int IdCategoria { get; set; }
        public string li_Codigo { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio")]
        [StringLength(1000, MinimumLength = 0, ErrorMessage = "el campo descripción debe tener máximo 1000")]
        public string li_Descripcion { get; set; }
        public bool li_Estado { get; set; }
    }
}
