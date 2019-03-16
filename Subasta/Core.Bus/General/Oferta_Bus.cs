using Core.Data.General;
using Core.Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Bus.General
{
   public class Oferta_Bus
    {
        Oferta_Data odata = new Oferta_Data();
        public List<Oferta_Info> GetList(bool mostrar_anulados)
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

        public Oferta_Info GetInfo(decimal IdOferta)
        {
            try
            {
                return odata.GetInfo(IdOferta);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GuardarDB(Oferta_Info info)
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

        public bool ModificarDB(Oferta_Info info)
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

        public bool AnularDB(Oferta_Info info)
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
