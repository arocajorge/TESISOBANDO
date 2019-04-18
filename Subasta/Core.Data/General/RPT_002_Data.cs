using Core.Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.General
{
    public class RPT_002_Data
    {
        public List<RPT_002_Info> GetList(int IdProveedor, DateTime fechaIni, DateTime fechaFin)
        {
            try
            {
                int IdProveedorIni = IdProveedor;
                int IdProveedorFin = IdProveedor == 0 ? 999999 : IdProveedor;
                List<RPT_002_Info> Lista;
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    Lista = db.SPRPT_002(IdProveedorIni, IdProveedorFin, fechaIni, fechaFin).Select(q => new RPT_002_Info
                    {
                        IdProveedor = q.IdProveedor,
                        OfertasGanadas = q.OfertasGanadas,
                        OfertasParticipadas = q.OfertasParticipadas,
                        PorcentajeGanadas = q.PorcentajeGanadas,
                        pv_Descripcion = q.pv_Descripcion
                    }).ToList();
                }
                return Lista;
            }
            catch (Exception EX)
            {

                throw;
            }
        }
    }
}
