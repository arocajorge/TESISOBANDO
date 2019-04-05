using Core.Web.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Core.Web.Controllers
{
    public class ReportesController : Controller
    {
        public ActionResult RPT_001(decimal IdSubasta = 0)
        {
            RPT_001_Rpt model = new RPT_001_Rpt();
            model.p_IdSubasta.Value = IdSubasta;
            return View(model);
        }

    }
}