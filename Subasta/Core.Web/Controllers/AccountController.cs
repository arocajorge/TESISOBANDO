using System;
using System.Web.Mvc;
using Core.Web.Models;
using Core.Bus.General;
using Core.Erp.Web.Helps;

namespace Core.Web.Controllers
{
    public class AccountController : Controller
    {
        Usuario_Bus bus_usuario = new Usuario_Bus();
        [AllowAnonymous]
        public ActionResult Login()
        {
            LoginModel model = new LoginModel();
            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model)
        {
            var info_usuario = bus_usuario.GetInfo(model.IdUsuario, model.Contrasena);
            if (info_usuario != null)
            {
                SessionFixed.IdUsuario = info_usuario.IdUsuario;
                SessionFixed.NombreUsuario = info_usuario.us_Descripcion;

                //SessionFixed.IdTransaccionSession = string.IsNullOrEmpty(SessionFixed.IdTransaccionSession) ? "1" : (Convert.ToDecimal(SessionFixed.IdTransaccionSession) + 1).ToString();
                //SessionFixed.IdTransaccionSessionActual = SessionFixed.IdTransaccionSession;
                return RedirectToAction("Index", "Inicio");
            }
            ViewBag.mensaje = "Credenciales incorrectas";
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Session.Contents.RemoveAll();
            return RedirectToAction("Login");
        }

        public ActionResult CambiarContrasena(string IdUsuario = "")
        {
            LoginModel model = new LoginModel { IdUsuario = IdUsuario };
            return View(model);
        }
        [HttpPost]
        public ActionResult CambiarContrasena(LoginModel model)
        {
            model.Contrasena = string.IsNullOrEmpty(model.Contrasena) ? "" : model.Contrasena.Trim();
            model.new_Contrasena = string.IsNullOrEmpty(model.new_Contrasena) ? "" : model.new_Contrasena.Trim();
            if (model.Contrasena == model.new_Contrasena)
            {
                ViewBag.mensaje = "La nueva contraseña no debe ser igual a la anterior";
                return View(model);
            }/*
            if (!bus_usuario.modificarDB(model.IdUsuario, model.Contrasena, model.new_Contrasena))
            {
                ViewBag.mensaje = "Credenciales incorrectas, por favor corrija";
                return View(model);
            }*/
            return RedirectToAction("Login");
        }
    }
}