using Core.Data.General;
using Core.Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Bus.General
{
    public class ProveedorSucursal_Bus
    {
        ProveedorSucursal_Data odata = new ProveedorSucursal_Data();

        public List<ProveedorSucursal_Info> GetList(decimal IdProveedor, bool mostrar_Anulados)
        {
            try
            {
                return odata.GetList(IdProveedor, mostrar_Anulados);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
