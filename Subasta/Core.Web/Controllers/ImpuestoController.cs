using Core.Bus.General;
using Core.Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Core.Web.Controllers
{
    public class ImpuestoController : Controller
    {
        Impuesto_Bus bus_impuesto = new Impuesto_Bus();
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_impuesto()
        {
            var model = bus_impuesto.GetList(true);
            return PartialView("_GridViewPartial_impuesto", model);
        }

        #region Acciones

        public ActionResult Nuevo()
        {
            Impuesto_Info model = new Impuesto_Info();
            return View(model);
        }

        [HttpPost]
        public ActionResult Nuevo(Impuesto_Info model)
        {
            if (!bus_impuesto.GuardarDB(model))
            {
                return View(model);
            }

            return RedirectToAction("Index");
        }
        public ActionResult Modificar(int IdImpuesto = 0)
        {
            Impuesto_Info model = bus_impuesto.GetInfo(IdImpuesto);
            if (model == null)
                return RedirectToAction("Index");
            return View(model);
        }

        [HttpPost]
        public ActionResult Modificar(Impuesto_Info model)
        {
            if (!bus_impuesto.ModificarDB(model))
            {
                return View(model);
            }
            return RedirectToAction("Index");

        }
        public ActionResult Anular(int IdImpuesto = 0)
        {
            Impuesto_Info model = bus_impuesto.GetInfo(IdImpuesto);
            if (model == null)
                return RedirectToAction("Index");
            return View(model);
        }

        [HttpPost]
        public ActionResult Anular(Impuesto_Info model)
        {
            if (!bus_impuesto.AnularDB(model))
            {
                return View(model);
            }
            return RedirectToAction("Index");

        }
        #endregion
    }
}