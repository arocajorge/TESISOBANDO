using Core.Data.General;
using Core.Info.General;
using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Bus.General
{
   public class Linea_Bus
    {
        Linea_Data odata = new Linea_Data();
        public List<Linea_Info> GetList(int IdCategoria, bool mostrar_anulados)
        {
            try
            {
                return odata.GetList(IdCategoria, mostrar_anulados);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Linea_Info GetInfo(int IdCategoria, int IdLinea)
        {
            try
            {
                return odata.GetInfo(IdCategoria, IdLinea);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GuardarDB(Linea_Info info)
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

        public bool ModificarDB(Linea_Info info)
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

        public bool AnularDB(Linea_Info info)
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

        #region Bajo demanda
        public List<Linea_Info> GetList(ListEditItemsRequestedByFilterConditionEventArgs args, int IdCategoria)
        {
            try
            {
                return odata.GetList(args, IdCategoria);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Linea_Info GetInfo(ListEditItemRequestedByValueEventArgs args, int IdCategoria)
        {
            try
            {
                return odata.GetInfo(args, IdCategoria);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        #endregion
    }
}
