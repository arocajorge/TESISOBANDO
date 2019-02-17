using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Web.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "El campo usuario es obligatorio")]
        public string IdUsuario { get; set; }
        public string Contrasena { get; set; }
        public string new_Contrasena { get; set; }
    }
}
