//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class VWRPT_001
    {
        public decimal IdSubasta { get; set; }
        public decimal IdOferta { get; set; }
        public string su_Descripcion { get; set; }
        public string pr_Descripcion { get; set; }
        public double su_Cantidad { get; set; }
        public string su_EstadoCierre { get; set; }
        public System.DateTime su_FechaFin { get; set; }
        public bool su_Estado { get; set; }
        public decimal IdProducto { get; set; }
        public decimal IdProveedor { get; set; }
        public int of_Plazo { get; set; }
        public string pv_Descripcion { get; set; }
        public string of_Observacion { get; set; }
        public double of_Total { get; set; }
        public string of_EstadoGanador { get; set; }
    }
}
