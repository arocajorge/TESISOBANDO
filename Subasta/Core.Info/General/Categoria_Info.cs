using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Info.General
{
    public class Categoria_Info
    {
        public int IdCategoria { get; set; }
        public string ca_Codigo { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio")]
        [StringLength(1000, MinimumLength = 0, ErrorMessage = "el campo descripción debe tener máximo 1000")]
        public string ca_Descripcion { get; set; }
        public bool ca_Estado { get; set; }
    }
}
