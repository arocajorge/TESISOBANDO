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
    
    public partial class Auditoria
    {
        public decimal IdAuditoria { get; set; }
        public string au_Pantalla { get; set; }
        public System.DateTime au_Fecha { get; set; }
        public string au_MotivoAnulacion { get; set; }
        public string au_Objeto { get; set; }
        public string IdUsuario { get; set; }
    
        public virtual Usuario Usuario { get; set; }
    }
}