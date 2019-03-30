using Core.Data;
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
    public class Grupo_Bus
    {
        Grupo_Data odata = new Grupo_Data();
        public List<Grupo_Info> GetList(int IdLinea, bool mostrar_anulados)
        {
            try
            {
                return odata.GetList(IdLinea, mostrar_anulados);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Grupo_Info GetInfo(int IdLinea, int IdGrupo)
        {
            try
            {
                return odata.GetInfo(IdLinea, IdGrupo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GuardarDB(Grupo_Info info)
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

        public bool ModificarDB(Grupo_Info info)
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

        public bool AnularDB(Grupo_Info info)
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
        public List<Grupo_Info> GetList(ListEditItemsRequestedByFilterConditionEventArgs args, int IdLinea)
        {
            try
            {
                return odata.GetList(args, IdLinea);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Grupo_Info GetInfo(ListEditItemRequestedByValueEventArgs args, int IdLinea)
        {
            try
            {
                return odata.GetInfo(args, IdLinea);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
