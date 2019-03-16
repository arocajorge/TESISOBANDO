using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Info.General
{
    public class Subasta_Info
    {
        public decimal IdSubasta { get; set; }
        public string su_Descripcion { get; set; }
        public decimal IdProducto { get; set; }
        public double su_Cantidad { get; set; }
        public string su_Observacion { get; set; }
        public bool su_EstadoCierre { get; set; }
        public System.DateTime su_FechaFin { get; set; }
        public bool su_Estado { get; set; }
        public string IdUsuario { get; set; }
    }
}
