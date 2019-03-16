using Core.Data.General;
using Core.Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Bus.General
{
   public class Catalogo_Bus
    {
        Catalogo_Data odata = new Catalogo_Data();
        public List<Catalogo_Info> GetList(int IdCatalogoTipo, bool mostrar_anulados)
        {
            try
            {
                return odata.GetList(IdCatalogoTipo, mostrar_anulados);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Catalogo_Info GetInfo(int IdCatalogoTipo, int IdCatalogo)
        {
            try
            {
                return odata.GetInfo(IdCatalogoTipo, IdCatalogo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GuardarDB(Catalogo_Info info)
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

        public bool ModificarDB(Catalogo_Info info)
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

        public bool AnularDB(Catalogo_Info info)
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
