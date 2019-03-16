using Core.Bus.General;
using Core.Info.General;
using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Core.Web.Controllers
{
    public class CategoriaController : Controller
    {
        Categoria_Bus bus_categoria = new Categoria_Bus();
        public ActionResult Index()
        {
            return View();
        }
        #region Acciones

        public ActionResult Nuevo()
        {
            Categoria_Info model = new Categoria_Info();
            return View(model);
        }

        [HttpPost]
        public ActionResult Nuevo(Categoria_Info model)
        {
            if (!bus_categoria.GuardarDB(model))
            {
                return View(model);
            }

            return RedirectToAction("Index");
        }
        public ActionResult Modificar(int IdCategoria = 0)
        {
            Categoria_Info model = bus_categoria.GetInfo(IdCategoria);
            if (model == null)
                return RedirectToAction("Index");
            return View(model);
        }

        [HttpPost]
        public ActionResult Modificar(Categoria_Info model)
        {
            if (!bus_categoria.ModificarDB(model))
            {
                return View(model);
            }
            return RedirectToAction("Index");

        }
        public ActionResult Anular(int IdCategoria = 0)
        {
            Categoria_Info model = bus_categoria.GetInfo(IdCategoria);
            if (model == null)
                return RedirectToAction("Index");
            return View(model);
        }

        [HttpPost]
        public ActionResult Anular(Categoria_Info model)
        {
            if (!bus_categoria.AnularDB(model))
            {
                return View(model);
            }
            return RedirectToAction("Index");

        }
        #endregion

        [ValidateInput(false)]
        public ActionResult GridViewPartialCategorias()
        {
            var model = bus_categoria.GetList(true);
            return PartialView("_GridViewPartialCategorias", model);
        }
    }
}