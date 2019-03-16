using Core.Data.General;
using Core.Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Bus.General
{
    public class CatalogoTipo_Bus
    {
        CatalogoTipo_Data odata = new CatalogoTipo_Data();
        public List<CatalogoTipo_Info> GetList()
        {
            try
            {
                return odata.GetList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public CatalogoTipo_Info GetInfo(int IdCatalogoTipo)
        {
            try
            {
                return odata.GetInfo(IdCatalogoTipo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GuardarDB(CatalogoTipo_Info info)
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

        public bool ModificarDB(CatalogoTipo_Info info)
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

    }
}
