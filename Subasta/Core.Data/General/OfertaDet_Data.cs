using Core.Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.General
{
   public class OfertaDet_Data
    {
        public List<OfertaDet_Info> GetList(decimal IdOferta)
        {
            try
            {
                List<OfertaDet_Info> Lista;
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    Lista = db.OfertaDet.Where(q => q.IdOferta == IdOferta).Select(q => new OfertaDet_Info
                    {
                        IdOferta = q.IdOferta,
                        IdImpuesto = q.IdImpuesto,
                        od_Cantidad = q.od_Cantidad,
                        od_DescuentoUni = q.od_DescuentoUni,
                        od_Iva = q.od_Iva,
                        od_Observacion = q.od_Observacion,
                        od_Porcentaje = q.od_Porcentaje,
                        od_PorDescuento = q.od_PorDescuento,
                        od_PrecioFinal = q.od_PrecioFinal,
                        od_PrecioUni = q.od_PrecioUni,
                        od_Subtotal = q.od_Subtotal,
                        od_Total = q.od_Total,
                        Secuencia = q.Secuencia
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
