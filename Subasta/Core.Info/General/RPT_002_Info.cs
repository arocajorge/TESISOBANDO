using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Info.General
{
    public class RPT_002_Info
    {
        public decimal IdProveedor { get; set; }
        public string pv_Descripcion { get; set; }
        public int OfertasGanadas { get; set; }
        public int OfertasParticipadas { get; set; }
        public Nullable<int> PorcentajeGanadas { get; set; }
    }
}
