using DevExpress.Web;
using DXSCV.Common;
using DXSCV.Helpers;
using DXSCV.Models;
using SCVData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DXSCV.Controllers
{
    public class TipoEventoController : Controller
    {
        TipoEventoViewModel tevm = new TipoEventoViewModel
        {
            TiposEventos = BitacoraEventosList.GetTiposEventos(),
            Cuentas = BitacoraEventosList.GetCuentas()
        };

        [SessionAuthorize]
        public ActionResult Index()
        {
            return View(tevm);
        }

        [SessionAuthorize]
        [ValidateInput(false)]
        public ActionResult GridViewPartialView()
        {
            // DXCOMMENT: Pass a data model for GridView in the PartialView method's second parameter
            return PartialView("GridViewPartialView", tevm);
        }




        [SessionAuthorize]
        public ActionResult CambiaVistaModoEdicion(GridViewEditingMode editMode)
        {
            GridViewEditHelper.EditMode = editMode;
            return PartialView("GridViewPartialView", TipoEventoDB.ObtieneTipoEventosDB());
        }

        [SessionAuthorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult AgregaTipoEvento(SCV_TipoEvento evento)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isSave = TipoEventoDB.InsertaTipoEvento(evento);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            tevm = new TipoEventoViewModel
            {
                TiposEventos = BitacoraEventosList.GetTiposEventos(),
                Cuentas = BitacoraEventosList.GetCuentas()

            };
            return PartialView("GridViewPartialView", tevm);
        }

        [SessionAuthorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult ActualizaTipoEvento(SCV_TipoEvento evento)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isSave = TipoEventoDB.ActualizaTipoEvento(evento);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            tevm = new TipoEventoViewModel
            {
                TiposEventos = BitacoraEventosList.GetTiposEventos(),
                Cuentas = BitacoraEventosList.GetCuentas()

            };
            return PartialView("GridViewPartialView", tevm);
        }

        [SessionAuthorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult EliminaTipoEvento(long TipoEventoId)
        {
            if (TipoEventoId >= 0)
            {
                try
                {
                    bool isSave = TipoEventoDB.EliminaTipoEvento(TipoEventoId);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }

            tevm = new TipoEventoViewModel
            {
                TiposEventos = BitacoraEventosList.GetTiposEventos(),
                Cuentas = BitacoraEventosList.GetCuentas()

            };
            
            return PartialView("GridViewPartialView", tevm);
        }

    }
}
