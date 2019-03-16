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
        public ActionResult Index( int IdLinea = 0)
        {
            ViewBag.IdLinea = IdLinea;
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_grupo( int IdLinea = 0)
        {
            ViewBag.IdLinea = IdLinea;
            var model = bus_grupo.GetList(IdLinea, true);
            return PartialView("_GridViewPartial_grupo", model);
        }
        private void cargar_combos(int IdCategoria = 0)
        {
            var lst_linea = bus_linea.GetList(IdCategoria, false);
            ViewBag.lst_linea = lst_linea;


        }
        #endregion
        #region Acciones

        public ActionResult Nuevo( int IdLinea = 0)
        {
            Grupo_Info model = new Grupo_Info
            {
                IdLinea = IdLinea
            };
            ViewBag.IdLinea = IdLinea;
            cargar_combos();
            return View(model);
        }

        [HttpPost]
        public ActionResult Nuevo(Grupo_Info model)
        {
            if (!bus_grupo.GuardarDB(model))
            {
                 
                ViewBag.IdLinea = model.IdLinea;
                cargar_combos();
                return View(model);
            }
            return RedirectToAction("Index", new { IdLinea = model.IdLinea });
        }
        public ActionResult Modificar( int IdLinea = 0, int IdGrupo = 0)
        {
            Grupo_Info model = bus_grupo.GetInfo(IdLinea, IdGrupo);
            if (model == null)
            {
                ViewBag.IdLinea = IdLinea;
                return RedirectToAction("Index", new {  IdLinea = IdLinea });
            }
            cargar_combos( );
            return View(model);
        }

        [HttpPost]
        public ActionResult Modificar(Grupo_Info model)
        {
            if (!bus_grupo.ModificarDB(model))
            {
                 
                ViewBag.IdLinea = model.IdLinea;
                cargar_combos();
                return View(model);
            }
            return RedirectToAction("Index", new {  IdLinea = model.IdLinea });
        }
        public ActionResult Anular( int IdLinea = 0, int IdGrupo = 0)
        {
            Grupo_Info model = bus_grupo.GetInfo(IdLinea, IdGrupo);
            if (model == null)
            {
                ViewBag.IdLinea = IdLinea;
                return RedirectToAction("Index", new {  IdLinea = IdLinea });
            }
            cargar_combos( );
            return View(model);
        }

        [HttpPost]
        public ActionResult Anular(Grupo_Info model)
        {
            if (!bus_grupo.AnularDB(model))
            {
                 
                ViewBag.IdLinea = model.IdLinea;
                cargar_combos();
                return View(model);
            }
            return RedirectToAction("Index", new {  IdLinea = model.IdLinea });
        }
        #endregion
    }
}