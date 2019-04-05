using Core.Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.General
{
    public class RPT_001_Data
    {
        public List<RPT_001_Info> GetList(decimal IdSubasta)
        {
            try
            {
                List<RPT_001_Info> Lista;
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    Lista = db.VWRPT_001.Where(q=>q.IdSubasta == IdSubasta).Select(q => new RPT_001_Info
                    {
                        IdOferta = q.IdOferta,
                        IdProducto = q.IdProducto,
                        IdProveedor = q.IdProveedor,
                        IdSubasta = q.IdSubasta,
                        of_EstadoGanador = q.of_EstadoGanador,
                        of_Observacion = q.of_Observacion,
                        of_Plazo = q.of_Plazo,
                        of_Total = q.of_Total,
                        pr_Descripcion = q.pr_Descripcion,
                        pv_Descripcion = q.pv_Descripcion,
                        su_Descripcion = q.su_Descripcion,
                        su_Cantidad = q.su_Cantidad,
                        su_Estado = q.su_Estado,
                        su_EstadoCierre = q.su_EstadoCierre,
                        su_FechaFin = q.su_FechaFin

                    }).ToList();
                }
                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
