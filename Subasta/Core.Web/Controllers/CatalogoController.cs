using Core.Bus.General;
using Core.Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Core.Web.Controllers
{
    public class CatalogoController : Controller
    {
        #region Index

        Catalogo_Bus bus_catalogo = new Catalogo_Bus();

        public ActionResult Index(int IdCatalogoTipo = 0)
        {
            ViewBag.IdCatalogoTipo = IdCatalogoTipo;
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_catalogo_(int IdCatalogoTipo = 0)
        {
            var model = bus_catalogo.GetList(IdCatalogoTipo, true);
            ViewBag.IdCatalogoTipo = IdCatalogoTipo;
            return PartialView("_GridViewPartial_catalogo_", model);
        }
        private void cargar_combos()
        {
            CatalogoTipo_Bus bus_catalogotipo = new CatalogoTipo_Bus();
            var lst_tipos = bus_catalogotipo.GetList();
            ViewBag.lst_tipos = lst_tipos;
        }
        #endregion

        #region Acciones

        public ActionResult Nuevo(int IdCatalogoTipo = 0)
        {
            Catalogo_Info model = new Catalogo_Info
            {
                IdCatalogoTipo = IdCatalogoTipo
            };
            cargar_combos();
            return View(model);
        }

        [HttpPost]
        public ActionResult Nuevo(Catalogo_Info model)
        {
            if (!bus_catalogo.GuardarDB(model))
            {
                ViewBag.IdCatalogoTipo = model.IdCatalogoTipo;
                cargar_combos();
                return View(model);
            }

            return RedirectToAction("Index", new { IdCatalogoTipo = model.IdCatalogoTipo });
        }
        public ActionResult Modificar(int IdCatalogoTipo = 0, int IdCatalogo = 0)
        {
            Catalogo_Info model = bus_catalogo.GetInfo(IdCatalogoTipo, IdCatalogo);
            if (model == null)
                return RedirectToAction("Index", new { IdCatalogo_tipo = IdCatalogoTipo });
            ViewBag.IdCatalogoTipo = IdCatalogoTipo;
            cargar_combos();
            return View(model);
        }

        [HttpPost]
        public ActionResult Modificar(Catalogo_Info model)
        {
            if (!bus_catalogo.ModificarDB(model))
            {
                ViewBag.IdCatalogoTipo = model.IdCatalogoTipo;
                cargar_combos();
                return View(model);
            }
            return RedirectToAction("Index", new { IdCatalogoTipo = model.IdCatalogoTipo });

        }
        public ActionResult Anular(int IdCatalogoTipo = 0, int IdCatalogo = 0)
        {
            Catalogo_Info model = bus_catalogo.GetInfo(IdCatalogoTipo, IdCatalogo);
            if (model == null)
                return RedirectToAction("Index", new { IdCatalogo_tipo = IdCatalogoTipo });
            ViewBag.IdCatalogoTipo = IdCatalogoTipo;
            cargar_combos();
            return View(model);
        }

        [HttpPost]
        public ActionResult Anular(Catalogo_Info model)
        {
            if (!bus_catalogo.AnularDB(model))
            {
                ViewBag.IdCatalogoTipo = model.IdCatalogoTipo;
                cargar_combos();
                return View(model);
            }
            return RedirectToAction("Index", new { IdCatalogoTipo = model.IdCatalogoTipo });

        }
        #endregion

    }
}