using Core.Bus.General;
using Core.Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Core.Web.Controllers
{
    public class UsuarioController : Controller
    {
        #region Variables
        Usuario_Bus bus_usuario = new Usuario_Bus();
        #endregion
        #region Index
        public ActionResult Index()
        {
            return View();
        }
        [ValidateInput(false)]
        public ActionResult GridViewPartial_usuario()
        {
            var model = bus_usuario.GetList();
            return PartialView("_GridViewPartial_usuario", model);
        }
        #endregion

        #region Acciones
        public ActionResult Nuevo()
        {
            Usuario_Info model = new Usuario_Info();
            return View(model);
        }
        [HttpPost]
        public ActionResult Nuevo(Usuario_Info model)
        {
            if (bus_usuario.ValidarUsuarioExiste(model.IdUsuario))
            {
                ViewBag.mensaje = "El usuario ya existe";
                return View(model);
            }
            if (bus_usuario.Guardar(model))
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Modificar(string IdUsuario = "")
        {
            Usuario_Info model = bus_usuario.GetInfo(IdUsuario);
            if (model == null)
                return RedirectToAction("Index");

            return View(model);
        }
        [HttpPost]
        public ActionResult Modificar(Usuario_Info model)
        {
            if (bus_usuario.Modificar(model))
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Anular(string IdUsuario = "")
        {
            Usuario_Info model = bus_usuario.GetInfo(IdUsuario);
            if (model == null)
                return RedirectToAction("Index");

            return View(model);
        }
        [HttpPost]
        public ActionResult Anular(Usuario_Info model)
        {
            if (bus_usuario.Anular(model))
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        #endregion
    }
}