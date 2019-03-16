using Core.Bus.General;
using Core.Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Core.Web.Controllers
{
    public class ProductoController : Controller
    {
        Producto_Bus bus_producto = new Producto_Bus();
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_producto()
        {
            var model = bus_producto.GetList(true);
            return PartialView("_GridViewPartial_producto", model);
        }

        #region Acciones

        public ActionResult Nuevo()
        {
            Producto_Info model = new Producto_Info();
            return View(model);
        }

        [HttpPost]
        public ActionResult Nuevo(Producto_Info model)
        {
            if (!bus_producto.GuardarDB(model))
            {
                return View(model);
            }

            return RedirectToAction("Index");
        }
        public ActionResult Modificar(decimal IdProducto = 0)
        {
            Producto_Info model = bus_producto.GetInfo(IdProducto);
            if (model == null)
                return RedirectToAction("Index");
            return View(model);
        }

        [HttpPost]
        public ActionResult Modificar(Producto_Info model)
        {
            if (!bus_producto.ModificarDB(model))
            {
                return View(model);
            }
            return RedirectToAction("Index");

        }
        public ActionResult Anular(decimal IdProducto = 0)
        {
            Producto_Info model = bus_producto.GetInfo(IdProducto);
            if (model == null)
                return RedirectToAction("Index");
            return View(model);
        }

        [HttpPost]
        public ActionResult Anular(Producto_Info model)
        {
            if (!bus_producto.AnularDB(model))
            {
                return View(model);
            }
            return RedirectToAction("Index");

        }
        #endregion
    }
}