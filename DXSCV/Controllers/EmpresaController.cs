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
    public class EmpresaController : Controller
    {
        EmpresaViewModel tdvm = new EmpresaViewModel
        {
            Empresas = EmpresaViewModel.GetEmpresas(),
            Cuentas = EmpresaViewModel.GetCuentas()
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
            return PartialView("GridViewPartialView", EmpresaDB.ObtieneEmpresasDB());
        }

        [SessionAuthorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult AgregaEmpresa(SCV_Empresa Empresa)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isSave = EmpresaDB.InsertaEmpresa(Empresa);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            tdvm = new EmpresaViewModel
            {
                Empresas = EmpresaViewModel.GetEmpresas(),
                Cuentas = EmpresaViewModel.GetCuentas()

            };
            return PartialView("GridViewPartialView", tdvm);
        }

        [SessionAuthorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult ActualizaEmpresa(SCV_Empresa Empresa)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isSave = EmpresaDB.ActualizaEmpresa(Empresa);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            tdvm = new EmpresaViewModel
            {
                Empresas = EmpresaViewModel.GetEmpresas(),
                Cuentas = EmpresaViewModel.GetCuentas()

            };
            return PartialView("GridViewPartialView", tdvm);
        }

        [SessionAuthorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult EliminaEmpresa(int EmpresaId)
        {
            if (EmpresaId >= 0)
            {
                try
                {
                    bool isSave = EmpresaDB.EliminaEmpresa(EmpresaId);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }

            tdvm = new EmpresaViewModel
            {
                Empresas = EmpresaViewModel.GetEmpresas(),
                Cuentas = EmpresaViewModel.GetCuentas()

            };

            return PartialView("GridViewPartialView", tdvm);
        }

    }
}
