using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Core.Bus.General;
using Core.Info.General;
using System.Collections.Generic;

namespace Core.Web.Reportes
{
    public partial class RPT_002_Rpt : DevExpress.XtraReports.UI.XtraReport
    {
        public RPT_002_Rpt()
        {
            InitializeComponent();
        }

        private void RPT_002_Rpt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            int IdProveedor = p_IdProveedor.Value == null ? 0 : Convert.ToInt32(p_IdProveedor.Value);
            DateTime fechaIni = p_fechaIni.Value == null ? DateTime.Now : Convert.ToDateTime(p_fechaIni.Value);
            DateTime fechaFin = p_fechaFin.Value == null ? DateTime.Now : Convert.ToDateTime(p_fechaFin.Value);

            RPT_002_Bus bus_rpt = new RPT_002_Bus();
            List<RPT_002_Info> lst_rpt = bus_rpt.GetList(IdProveedor, fechaIni, fechaFin);
            this.DataSource = lst_rpt;
        }
    }
}
