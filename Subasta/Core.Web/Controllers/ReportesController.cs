using Core.Bus.General;
using Core.Info.General;
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
        private void cargar_Combos(cl_filtros_Info model)
        {
            Proveedor_Bus bus_proveedor = new Proveedor_Bus();
            var lst_proveedor = bus_proveedor.GetInfo(model.IdProveedor);
            ViewBag.lst_proveedor = lst_proveedor;
        }
        public ActionResult RPT_001(decimal IdSubasta = 0)
        {
            RPT_001_Rpt model = new RPT_001_Rpt();
            model.p_IdSubasta.Value = IdSubasta;
            return View(model);
        }

        public ActionResult RPT_002()
        {
            cl_filtros_Info model = new cl_filtros_Info
            {
                IdProveedor = 0
            };
            RPT_002_Rpt report = new RPT_002_Rpt();
            cargar_Combos(model);
            report.p_IdProveedor.Value = model.IdProveedor;
            report.p_fechaIni.Value = model.fecha_ini;
            report.p_fechaFin.Value = model.fecha_fin;
            ViewBag.Report = report;
            return View(model);
        }
        [HttpPost]
        public ActionResult RPT_002(cl_filtros_Info model)
        {
            RPT_002_Rpt report = new RPT_002_Rpt();
            report.p_IdProveedor.Value = model.IdProveedor;
            report.p_fechaIni.Value = model.fecha_ini;
            report.p_fechaFin.Value = model.fecha_fin;
            ViewBag.Report = report;
            cargar_Combos(model);
            return View(model);
        }
    }
}