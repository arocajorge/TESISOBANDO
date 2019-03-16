using Core.Data.General;
using Core.Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Bus.General
{
    public class Producto_Bus
    {
        Producto_Data odata = new Producto_Data();
        public List<Producto_Info> GetList(bool mostrar_anulados)
        {
            try
            {
                return odata.GetList(mostrar_anulados);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Producto_Info GetInfo(decimal IdProducto)
        {
            try
            {
                return odata.GetInfo(IdProducto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GuardarDB(Producto_Info info)
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

        public bool ModificarDB(Producto_Info info)
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

        public bool AnularDB(Producto_Info info)
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
