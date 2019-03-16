using Core.Data.General;
using Core.Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Bus.General
{
   public class OfertaDet_Bus
    {
        OfertaDet_Data odata = new OfertaDet_Data();
        public List<OfertaDet_Info> GetList(decimal IdOferta)
        {
            try
            {
                return odata.GetList(IdOferta);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
