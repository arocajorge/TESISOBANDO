using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Info.General
{
    public class OfertaDet_Info
    {
        public decimal IdOferta { get; set; }
        public int Secuencia { get; set; }
        public double od_Cantidad { get; set; }
        public double od_PrecioUni { get; set; }
        public double od_PorDescuento { get; set; }
        public double od_DescuentoUni { get; set; }
        public double od_PrecioFinal { get; set; }
        public double od_Subtotal { get; set; }
        public int IdImpuesto { get; set; }
        public double od_Porcentaje { get; set; }
        public double od_Iva { get; set; }
        public double od_Total { get; set; }
        public string od_Observacion { get; set; }
    }
}
