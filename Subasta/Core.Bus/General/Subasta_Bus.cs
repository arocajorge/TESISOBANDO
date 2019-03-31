using Core.Data.General;
using Core.Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Bus.General
{
    public class Subasta_Bus
    {
        Subasta_Data odata = new Subasta_Data();
        public List<Subasta_Info> GetList(string IdUsuario)
        {
            try
            {
                return odata.GetList(IdUsuario);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Subasta_Info GetInfo(decimal IdSubasta)
        {
            try
            {
                return odata.GetInfo(IdSubasta);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GuardarDB(Subasta_Info info)
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

        public bool ModificarDB(Subasta_Info info)
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

        public bool AnularDB(Subasta_Info info)
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
