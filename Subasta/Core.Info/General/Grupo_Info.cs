using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Info.General
{
    public class Grupo_Info
    {
        public int IdGrupo { get; set; }
        [Required(ErrorMessage = "El campo linea es obligatorio")]
        public int IdLinea { get; set; }
        public int IdCategoria { get; set; }
        public string gr_Codigo { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio")]
        [StringLength(1000, MinimumLength = 0, ErrorMessage = "el campo descripción debe tener máximo 1000")]
        public string gr_Descripcion { get; set; }
        public bool gr_Estado { get; set; }
    }
}
