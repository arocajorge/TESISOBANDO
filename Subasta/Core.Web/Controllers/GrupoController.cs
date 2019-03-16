using Core.Bus.General;
using Core.Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Core.Web.Controllers
{
    public class GrupoController : Controller
    {
        #region Index /Metodos

        Grupo_Bus bus_grupo = new Grupo_Bus();
        Linea_Bus bus_linea = new Linea_Bus();
        public ActionResult Index(int IdCategoria = 0, int IdLinea = 0)
        {
            ViewBag.IdLinea = IdLinea;
            ViewBag.IdCategoria = IdCategoria;
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_grupo(int IdCategoria = 0, int IdLinea = 0)
        {
            ViewBag.IdLinea = IdLinea;
            ViewBag.IdCategoria = IdCategoria;
            var model = bus_grupo.GetList(IdLinea, true);
            return PartialView("_GridViewPartial_grupo", model);
        }
        private void cargar_combos(int IdCategoria)
        {
            var lst_linea = bus_linea.GetList(IdCategoria, false);
            ViewBag.lst_linea = lst_linea;


        }
        #endregion
        #region Acciones

        public ActionResult Nuevo(int IdCategoria = 0, int IdLinea = 0)
        {
            Grupo_Info model = new Grupo_Info
            {
                IdCategoria = IdCategoria,
                IdLinea = IdLinea
            };
            cargar_combos(model.IdCategoria);
            return View(model);
        }

        [HttpPost]
        public ActionResult Nuevo(Grupo_Info model)
        {
            if (!bus_grupo.GuardarDB(model))
            {
                cargar_combos(model.IdCategoria);
                return View(model);
            }
            return RedirectToAction("Index", new {IdCategoria = model.IdCategoria, IdLinea = model.IdLinea });
        }
        public ActionResult Modificar(int IdCategoria = 0, int IdLinea = 0, int IdGrupo = 0)
        {
            Grupo_Info model = bus_grupo.GetInfo(IdLinea, IdGrupo);
            if (model == null)
            {
                return RedirectToAction("Index", new {IdCategoria = IdCategoria, IdLinea = IdLinea });
            }
            cargar_combos(model.IdCategoria);
            return View(model);
        }

        [HttpPost]
        public ActionResult Modificar(Grupo_Info model)
        {
            if (!bus_grupo.ModificarDB(model))
            {
                cargar_combos(model.IdCategoria);
                return View(model);
            }
            return RedirectToAction("Index", new {IdCategoria = model.IdCategoria, IdLinea = model.IdLinea });
        }
        public ActionResult Anular(int IdCategoria = 0, int IdLinea = 0, int IdGrupo = 0)
        {
            Grupo_Info model = bus_grupo.GetInfo(IdLinea, IdGrupo);
            if (model == null)
            {
                return RedirectToAction("Index", new {IdCategoria = model.IdCategoria,  IdLinea = IdLinea });
            }
            cargar_combos(model.IdCategoria);
            return View(model);
        }

        [HttpPost]
        public ActionResult Anular(Grupo_Info model)
        {
            if (!bus_grupo.AnularDB(model))
            {
                cargar_combos(model.IdCategoria);
                return View(model);
            }
            return RedirectToAction("Index", new { IdCategoria = model.IdCategoria, IdLinea = model.IdLinea });
        }
        #endregion
    }
}