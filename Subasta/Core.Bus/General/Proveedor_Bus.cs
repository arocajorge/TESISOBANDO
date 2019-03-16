using Core.Data.General;
using Core.Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Bus.General
{
   public class Proveedor_Bus
    {
        Proveedor_Data odata = new Proveedor_Data();
        public List<Proveedor_Info> GetList(bool mostrar_Anulados)
        {
            try
            {
                return odata.GetList(mostrar_Anulados);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Proveedor_Info GetInfo(decimal IdProveedor)
        {
            try
            {
                return odata.GetInfo(IdProveedor);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GuardarDB(Proveedor_Info info)
        {
            try
            {
                return odata.GuardarDB(info);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ModificarDB(Proveedor_Info info)
        {
            try
            {
                return odata.ModificarDB(info);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AnularDB(Proveedor_Info info)
        {
            try
            {
                return odata.AnularDB(info);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
