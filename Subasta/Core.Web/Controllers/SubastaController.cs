using Core.Bus.General;
using Core.Erp.Web.Helps;
using Core.Info.General;
using DevExpress.Web;
using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Core.Web.Controllers
{
    public class SubastaController : Controller
    {
        Subasta_Bus bus_subasta = new Subasta_Bus();
        Producto_Bus bus_producto = new Producto_Bus();
        Oferta_Bus bus_oferta = new Oferta_Bus();
        public ActionResult Index()
        {
            return View();
        }
        [ValidateInput(false)]
        public ActionResult GridViewPartial_subasta()
        {
            var model = bus_subasta.GetList(SessionFixed.IdUsuario);
            return PartialView("_GridViewPartial_subasta", model);
        }

        #region Acciones
        public ActionResult Nuevo()
        {
            Subasta_Info model = new Subasta_Info
            {
                su_FechaFin = DateTime.Now.Date.AddMonths(1)
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Nuevo(Subasta_Info model)
        {
            model.IdUsuario = SessionFixed.IdUsuario;
            if (bus_subasta.GuardarDB(model))
            {
                return RedirectToAction("Index");
            }
            SessionFixed.IdSubasta = "0";
            return View(model);
        }

        public ActionResult Modificar(decimal IdSubasta = 0)
        {
            Subasta_Info model = bus_subasta.GetInfo(IdSubasta);
            if (model == null)
                return RedirectToAction("Index");
            SessionFixed.IdSubasta = model.IdSubasta.ToString();
            return View(model);
        }

        [HttpPost]
        public ActionResult Modificar(Subasta_Info model)
        {
            if (bus_subasta.ModificarDB(model))
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Anular(decimal IdSubasta = 0)
        {
            Subasta_Info model = bus_subasta.GetInfo(IdSubasta);
            if (model == null)
                return RedirectToAction("Index");

            SessionFixed.IdSubasta = model.IdSubasta.ToString();
            return View(model);
        }

        [HttpPost]
        public ActionResult Anular(Subasta_Info model)
        {
            if (bus_subasta.AnularDB(model))
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        #endregion

        #region Categoria bajo demanda
        public ActionResult CmbProducto()
        {
            Subasta_Info model = new Subasta_Info();
            return PartialView("_CmbProducto", model);
        }
        public List<Producto_Info> GetListProducto(ListEditItemsRequestedByFilterConditionEventArgs args)
        {
            return bus_producto.GetList(args);
        }
        public Producto_Info GetInfoProducto(ListEditItemRequestedByValueEventArgs args)
        {
            return bus_producto.GetInfo(args);
        }
        #endregion

        #region Detalle
        public ActionResult GridViewPartial_subasta_det()
        {
            var model = bus_oferta.GetList(Convert.ToDecimal(SessionFixed.IdSubasta));
            return PartialView("_GridViewPartial_subasta_det", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditingAdd([ModelBinder(typeof(DevExpressEditorsBinder))] Oferta_Info info_det)
        {
            if (ModelState.IsValid)
            {
                info_det.IdProveedor = Convert.ToDecimal(SessionFixed.IdProveedor);
                info_det.IdSubasta = Convert.ToDecimal(SessionFixed.IdSubasta);
                info_det.of_Fecha = DateTime.Now.Date;
                info_det.of_FechaFin = DateTime.Now.Date.AddDays(info_det.of_Plazo);
                bus_oferta.GuardarDB(info_det);
            }
            var model = bus_oferta.GetList(Convert.ToDecimal(SessionFixed.IdSubasta));
            return PartialView("_GridViewPartial_subasta_det", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult EditingUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Oferta_Info info_det)
        {
            if (ModelState.IsValid)
            {
                info_det.IdProveedor = Convert.ToDecimal(SessionFixed.IdProveedor);
                info_det.IdSubasta = Convert.ToDecimal(SessionFixed.IdSubasta);
                info_det.of_Fecha = DateTime.Now.Date;
                info_det.of_FechaFin = DateTime.Now.Date.AddDays(info_det.of_Plazo);
                bus_oferta.ModificarDB(info_det);
            }
            var model = bus_oferta.GetList(Convert.ToDecimal(SessionFixed.IdSubasta));
            return PartialView("_GridViewPartial_subasta_det", model);
        }
        #endregion
    }
}