using Core.Data.General;
using Core.Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Bus.General
{
    public class RPT_001_Bus
    {
        RPT_001_Data odata = new RPT_001_Data();
        public List<RPT_001_Info> GetList(decimal IdSubasta)
        {
            try
            {
                return odata.GetList(IdSubasta);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
