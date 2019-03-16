using Core.Bus.General;
using Core.Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Core.Web.Controllers
{
    public class LineaController : Controller
    {
        #region Index

        Linea_Bus bus_linea = new Linea_Bus();

        public ActionResult Index(int IdCategoria = 0)
        {
            ViewBag.IdCategoria = IdCategoria;
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_Linea(int IdCategoria = 0)
        {
            var model = bus_linea.GetList(IdCategoria, true);
            ViewBag.IdCategoria = IdCategoria;
            return PartialView("_GridViewPartial_Linea", model);
        }
        private void cargar_combos()
        {
            Categoria_Bus bus_cat = new Categoria_Bus();
            var lst_cat = bus_cat.GetList(false);
            ViewBag.lst_cat = lst_cat;
        }
        #endregion

        #region Acciones

        public ActionResult Nuevo(int IdCategoria = 0)
        {
            Linea_Info model = new Linea_Info
            {
                IdCategoria = IdCategoria
            };
            cargar_combos();
            return View(model);
        }

        [HttpPost]
        public ActionResult Nuevo(Linea_Info model)
        {
            if (!bus_linea.GuardarDB(model))
            {
                ViewBag.IdCategoria = model.IdCategoria;
                cargar_combos();
                return View(model);
            }

            return RedirectToAction("Index", new { IdCategoria = model.IdCategoria });
        }
        public ActionResult Modificar(int IdCategoria = 0, int IdLinea = 0)
        {
            Linea_Info model = bus_linea.GetInfo(IdCategoria, IdLinea);
            if (model == null)
                return RedirectToAction("Index", new { IdCategoria = IdCategoria });
            ViewBag.IdCategoria = IdCategoria;
            cargar_combos();
            return View(model);
        }

        [HttpPost]
        public ActionResult Modificar(Linea_Info model)
        {
            if (!bus_linea.ModificarDB(model))
            {
                ViewBag.IdCategoria = model.IdCategoria;
                cargar_combos();
                return View(model);
            }
            return RedirectToAction("Index", new { IdCategoria = model.IdCategoria });

        }
        public ActionResult Anular(int IdCategoria = 0, int IdLinea = 0)
        {
            Linea_Info model = bus_linea.GetInfo(IdCategoria, IdLinea);
            if (model == null)
                return RedirectToAction("Index", new { IdCategoria = IdCategoria });
            ViewBag.IdCategoria = IdCategoria;
            cargar_combos();
            return View(model);
        }

        [HttpPost]
        public ActionResult Anular(Linea_Info model)
        {
            if (!bus_linea.AnularDB(model))
            {
                ViewBag.IdCategoria = model.IdCategoria;
                cargar_combos();
                return View(model);
            }
            return RedirectToAction("Index", new { IdCategoria = model.IdCategoria });

        }
        #endregion
    }
}