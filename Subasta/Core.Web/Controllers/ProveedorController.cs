using Core.Bus.General;
using Core.Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Core.Web.Controllers
{
    public class ProveedorController : Controller
    {
        Proveedor_Bus bus_proveedor = new Proveedor_Bus();
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_Proveedor()
        {
            var model = bus_proveedor.GetList(true);
            return PartialView("_GridViewPartial_Proveedor", model);
        }

        #region Acciones

        public ActionResult Nuevo()
        {
            Proveedor_Info model = new Proveedor_Info();
            return View(model);
        }

        [HttpPost]
        public ActionResult Nuevo(Proveedor_Info model)
        {
            if (!bus_proveedor.GuardarDB(model))
            {
                return View(model);
            }

            return RedirectToAction("Index");
        }
        public ActionResult Modificar(decimal IdProveedor = 0)
        {
            Proveedor_Info model = bus_proveedor.GetInfo(IdProveedor);
            if (model == null)
                return RedirectToAction("Index");
            return View(model);
        }

        [HttpPost]
        public ActionResult Modificar(Proveedor_Info model)
        {
            if (!bus_proveedor.ModificarDB(model))
            {
                return View(model);
            }
            return RedirectToAction("Index");

        }
        public ActionResult Anular(decimal IdProveedor = 0)
        {
            Proveedor_Info model = bus_proveedor.GetInfo(IdProveedor);
            if (model == null)
                return RedirectToAction("Index");
            return View(model);
        }

        [HttpPost]
        public ActionResult Anular(Proveedor_Info model)
        {
            if (!bus_proveedor.AnularDB(model))
            {
                return View(model);
            }
            return RedirectToAction("Index");

        }
        #endregion

    }
}