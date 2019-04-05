using Core.Data.General;
using Core.Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Bus.General
{
    public class RPT_002_Bus
    {
        RPT_002_Data odata = new RPT_002_Data();
        public List<RPT_002_Info> GetList(int IdProveedor, DateTime fechaIni, DateTime fechaFin)
        {
            try
            {
                return odata.GetList(IdProveedor, fechaIni, fechaFin);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
