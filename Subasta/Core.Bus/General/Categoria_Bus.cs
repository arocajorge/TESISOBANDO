using Core.Data.General;
using Core.Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Bus.General
{
  public class Categoria_Bus
    {
        Categoria_Data odata = new Categoria_Data();
        public List<Categoria_Info> GetList(bool mostrar_anulados)
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

        public Categoria_Info GetInfo(int IdCategoria)
        {
            try
            {
                return odata.GetInfo(IdCategoria);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GuardarDB(Categoria_Info info)
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

        public bool ModificarDB(Categoria_Info info)
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

        public bool AnularDB(Categoria_Info info)
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
