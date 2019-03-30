using Core.Bus.General;
using Core.Erp.Web.Helps;
using Core.Info.General;
using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Core.Web.Controllers
{
    public class ProductoController : Controller
    {
        #region Variables
        Producto_Bus bus_producto = new Producto_Bus();
        Categoria_Bus bus_categoria = new Categoria_Bus();
        Linea_Bus bus_linea = new Linea_Bus();
        Grupo_Bus bus_grupo = new Grupo_Bus();
        #endregion

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
            SessionFixed.IdCategoria = "0";
            SessionFixed.IdLinea = "0";            
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

            SessionFixed.IdCategoria = model.IdCategoria.ToString();
            SessionFixed.IdLinea = model.IdLinea.ToString();

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

            SessionFixed.IdCategoria = model.IdCategoria.ToString();
            SessionFixed.IdLinea = model.IdLinea.ToString();
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

        #region Categoria bajo demanda
        public ActionResult CmbCategoria()
        {
            Producto_Info model = new Producto_Info();
            return PartialView("_CmbCategoria", model);
        }
        public List<Categoria_Info> GetListCategoria(ListEditItemsRequestedByFilterConditionEventArgs args)
        {
            return bus_categoria.GetList(args);
        }
        public Categoria_Info GetInfoCategoria(ListEditItemRequestedByValueEventArgs args)
        {
            return bus_categoria.GetInfo(args);
        }
        #endregion
        
        #region Linea bajo demanda
        public ActionResult CmbLinea()
        {
            SessionFixed.IdCategoria = Request.Params["IdCategoria"] != null ? Request.Params["IdCategoria"].ToString() : SessionFixed.IdCategoria;
            Producto_Info model = new Producto_Info();
            return PartialView("_CmbLinea", model);
        }
        public List<Linea_Info> GetListLinea(ListEditItemsRequestedByFilterConditionEventArgs args)
        {            
            return bus_linea.GetList(args, Convert.ToInt32(SessionFixed.IdCategoria));
        }
        public Linea_Info GetInfoLinea(ListEditItemRequestedByValueEventArgs args)
        {
            return bus_linea.GetInfo(args,Convert.ToInt32(SessionFixed.IdCategoria));
        }
        #endregion

        #region Grupo bajo demanda
        public ActionResult CmbGrupo()
        {
            SessionFixed.IdLinea = Request.Params["IdLinea"] != null ? Request.Params["IdLinea"].ToString() : SessionFixed.IdLinea;
            Producto_Info model = new Producto_Info();
            return PartialView("_CmbGrupo", model);
        }
        public List<Grupo_Info> GetListGrupo(ListEditItemsRequestedByFilterConditionEventArgs args)
        {
            return bus_grupo.GetList(args, Convert.ToInt32(SessionFixed.IdLinea));
        }
        public Grupo_Info GetInfoGrupo(ListEditItemRequestedByValueEventArgs args)
        {
            return bus_grupo.GetInfo(args, Convert.ToInt32(SessionFixed.IdLinea));
        }
        #endregion

        #region Json
        public JsonResult SetSession(int IdCategoria = 0, int IdLinea = 0, string Tipo = "")
        {
            switch (Tipo)
            {
                case "C":
                    SessionFixed.IdCategoria = IdCategoria.ToString();
                    SessionFixed.IdLinea = "0";
                    break;
                case "L":
                    SessionFixed.IdLinea = IdLinea.ToString();
                    break;
                default:
                    break;
            }
            return Json("", JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}