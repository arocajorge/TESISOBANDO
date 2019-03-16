using Core.Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.General
{
   public class ProveedorSucursal_Data
    {
        public List<ProveedorSucursal_Info> GetList(decimal IdProveedor, bool mostrar_Anulados)
        {
            try
            {
                List<ProveedorSucursal_Info> Lista;
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    if(mostrar_Anulados)
                    {
                        Lista = db.ProveedorSucursal.Where(q => q.IdProveedor == IdProveedor).Select(q => new ProveedorSucursal_Info
                        {
                            IdProveedor = q.IdProveedor,
                            ps_CodigoEstablecimiento = q.ps_CodigoEstablecimiento,
                            ps_Correo = q.ps_Correo,
                            ps_Direccion = q.ps_Direccion,
                            ps_Estado = q.ps_Estado,
                            ps_Telefono = q.ps_Telefono,
                            Secuencia = q.Secuencia

                        }).ToList();
                    }
                    else
                    {
                        Lista = db.ProveedorSucursal.Where(q => q.IdProveedor == IdProveedor && q.ps_Estado == true).Select(q => new ProveedorSucursal_Info
                        {
                            IdProveedor = q.IdProveedor,
                            ps_CodigoEstablecimiento = q.ps_CodigoEstablecimiento,
                            ps_Correo = q.ps_Correo,
                            ps_Direccion = q.ps_Direccion,
                            ps_Estado = q.ps_Estado,
                            ps_Telefono = q.ps_Telefono,
                            Secuencia = q.Secuencia

                        }).ToList();
                    }
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
