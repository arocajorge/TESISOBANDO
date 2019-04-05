using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Core.Info.General;
using System.Collections.Generic;
using Core.Bus.General;

namespace Core.Web.Reportes
{
    public partial class RPT_001_Rpt : DevExpress.XtraReports.UI.XtraReport
    {
        public RPT_001_Rpt()
        {
            InitializeComponent();
        }

        private void RPT_001_Rpt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            int IdSubasta = p_IdSubasta.Value == null ? 0 : Convert.ToInt32(p_IdSubasta.Value);

            RPT_001_Bus bus_rpt = new RPT_001_Bus();
            List<RPT_001_Info> lst_rpt = bus_rpt.GetList(IdSubasta);
            this.DataSource = lst_rpt;

        }
    }
}
