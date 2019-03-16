using Core.Data.General;
using Core.Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Bus.General
{
    public class Impuesto_Bus
    {
        Impuesto_Data odata = new Impuesto_Data();
        public List<Impuesto_Info> GetList(bool mostrar_anulados)
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

        public Impuesto_Info GetInfo(int IdImpuesto)
        {
            try
            {
                return odata.GetInfo(IdImpuesto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GuardarDB(Impuesto_Info info)
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

        public bool ModificarDB(Impuesto_Info info)
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

        public bool AnularDB(Impuesto_Info info)
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
