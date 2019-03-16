using DevExpress.Web.Mvc;
using Core.Bus.General;
using Core.Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Core.Web.Controllers
{
    public class CatalogoTipoController : Controller
    {

        #region Index
       CatalogoTipo_Bus  bus_catalogotipo = new CatalogoTipo_Bus();
        public ActionResult Index()
        {
            return View();
        }
        [ValidateInput(false)]
        public ActionResult GridViewPartial_catalogo_tipo()
        {
            var  model = bus_catalogotipo.GetList();
            return PartialView("_GridViewPartial_catalogo_tipo", model);
        }


        #endregion

        #region Acciones
        public ActionResult Nuevo()
        {
            CatalogoTipo_Info model = new CatalogoTipo_Info();
            return View(model);
        }
        [HttpPost]
        public ActionResult Nuevo(CatalogoTipo_Info model)
        {
           
            if (!bus_catalogotipo.GuardarDB(model))
            {
                return View(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Modificar(int IdCatalogoTipo = 0)
        {
            CatalogoTipo_Info model = bus_catalogotipo.GetInfo(IdCatalogoTipo);
            if (model == null)
                return RedirectToAction("Index");
            return View(model);
        }

        [HttpPost]
        public ActionResult Modificar(CatalogoTipo_Info model)
        {
            if (!bus_catalogotipo.ModificarDB(model))
            {
                return View(model);
            }
            return RedirectToAction("Index");
        }

        #endregion

     
    }
}