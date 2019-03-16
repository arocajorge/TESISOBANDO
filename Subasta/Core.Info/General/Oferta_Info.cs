using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Info.General
{
    public class Oferta_Info
    {
        public decimal IdOferta { get; set; }
        [Required(ErrorMessage = "El campo subasta es obligatorio")]
        public decimal IdSubasta { get; set; }
        [Required(ErrorMessage = "El campo proveedor es obligatorio")]
        public decimal IdProveedor { get; set; }
        public int Secuencia { get; set; }
        public string of_Observacion { get; set; }
        public bool of_Estado { get; set; }
        [Required(ErrorMessage = "El campo fecha es obligatorio")]
        public System.DateTime of_Fecha { get; set; }
        [Required(ErrorMessage = "El campo fecha fin es obligatorio")]
        public System.DateTime of_FechaFin { get; set; }
        [Required(ErrorMessage = "El campo plazo es obligatorio")]
        public int of_Plazo { get; set; }
        public bool of_EstadoGanador { get; set; }
    }
}
