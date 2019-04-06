﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Info.General
{
   public class cl_filtros_Info
    {
        [DataType(DataType.Date, ErrorMessage = "El campo fecha inicio debe ser una fecha en formato dd/MM/yyyy")]
        public DateTime fecha_ini { get; set; }
        [Required(ErrorMessage = "El campo fecha fin es obligatorio")]
        [DataType(DataType.Date, ErrorMessage = "El campo fecha fin debe ser una fecha en formato dd/MM/yyyy")]
        public DateTime fecha_fin { get; set; }
        public int IdProveedor { get; set; }
        public cl_filtros_Info()
        {
            fecha_ini = DateTime.Now.Date.AddMonths(-1);
            fecha_fin = DateTime.Now.Date;
        }
    }
}
