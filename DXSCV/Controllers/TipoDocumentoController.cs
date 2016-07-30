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
    public class TipoDocumentoController : Controller
    {
        TipoDocumentoViewModel tdvm = new TipoDocumentoViewModel
        {
            TiposDocumentos = TipoDocumentoViewModel.GetTiposDocumentos(),
            Cuentas = TipoDocumentoViewModel.GetCuentas()
        };

        [SessionAuthorize]
        public ActionResult Index()
        {
            return View(tdvm);
        }

        [SessionAuthorize]
        [ValidateInput(false)]
        public ActionResult GridViewPartialView()
        {
            // DXCOMMENT: Pass a data model for GridView in the PartialView method's second parameter
            return PartialView("GridViewPartialView", tdvm);
        }




        [SessionAuthorize]
        public ActionResult CambiaVistaModoEdicion(GridViewEditingMode editMode)
        {
            GridViewEditHelper.EditMode = editMode;
            return PartialView("GridViewPartialView", TipoDocumentoDB.ObtieneTipoDocumentosDB());
        }

        [SessionAuthorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult AgregaTipoDocumento(SCV_TipoDocumento tipodocumento)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isSave = TipoDocumentoDB.InsertaTipoDocumento(tipodocumento);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            tdvm = new TipoDocumentoViewModel
            {
                TiposDocumentos = TipoDocumentoViewModel.GetTiposDocumentos(),
                Cuentas = TipoDocumentoViewModel.GetCuentas()

            };
            return PartialView("GridViewPartialView", tdvm);
        }

        [SessionAuthorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult ActualizaTipoDocumento(SCV_TipoDocumento tipodocumento)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isSave = TipoDocumentoDB.ActualizaTipoDocumento(tipodocumento);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            tdvm = new TipoDocumentoViewModel
            {
                TiposDocumentos = TipoDocumentoViewModel.GetTiposDocumentos(),
                Cuentas = TipoDocumentoViewModel.GetCuentas()

            };
            return PartialView("GridViewPartialView", tdvm);
        }

        [SessionAuthorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult EliminaTipoDocumento(long TipoDocumentoId)
        {
            if (TipoDocumentoId >= 0)
            {
                try
                {
                    bool isSave = TipoDocumentoDB.EliminaTipoDocumento(TipoDocumentoId);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }

            tdvm = new TipoDocumentoViewModel
            {
                TiposDocumentos = TipoDocumentoViewModel.GetTiposDocumentos(),
                Cuentas = TipoDocumentoViewModel.GetCuentas()

            };

            return PartialView("GridViewPartialView", tdvm);
        }

    }
}
