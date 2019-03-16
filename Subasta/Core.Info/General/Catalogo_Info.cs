using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Info.General
{
    public class Catalogo_Info
    {
        public int IdCatalogo { get; set; }
        [Required(ErrorMessage = "El campo cátalogo es obligatorio")]
        public int IdCatalogoTipo { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio")]
        [StringLength(1000, MinimumLength = 0, ErrorMessage = "el campo descripción debe tener máximo 1000")]
        public string ct_Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}
