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
    public class CiudadController : Controller
    {
        CiudadViewModel cvm = new CiudadViewModel
        {
            Ciudades = CiudadViewModel.GetCiudades(),
            Cuentas = CiudadViewModel.GetCuentas()
        };

        [SessionAuthorize]
        public ActionResult Index()
        {
            return View(cvm);
        }

        [SessionAuthorize]
        [ValidateInput(false)]
        public ActionResult GridViewPartialView()
        {
            // DXCOMMENT: Pass a data model for GridView in the PartialView method's second parameter
            return PartialView("GridViewPartialView", cvm);
        }




        [SessionAuthorize]
        public ActionResult CambiaVistaModoEdicion(GridViewEditingMode editMode)
        {
            GridViewEditHelper.EditMode = editMode;
            return PartialView("GridViewPartialView", CiudadDB.ObtieneCiudadesDB());
        }

        [SessionAuthorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult AgregaCiudad(SCV_Ciudad Ciudad)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isSave = CiudadDB.InsertaCiudad(Ciudad);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            cvm = new CiudadViewModel
            {
                Ciudades = CiudadViewModel.GetCiudades(),
                Cuentas = CiudadViewModel.GetCuentas()

            };
            return PartialView("GridViewPartialView", cvm);
        }

        [SessionAuthorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult ActualizaCiudad(SCV_Ciudad Ciudad)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isSave = CiudadDB.ActualizaCiudad(Ciudad);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            cvm = new CiudadViewModel
            {
                Ciudades = CiudadViewModel.GetCiudades(),
                Cuentas = CiudadViewModel.GetCuentas()

            };
            return PartialView("GridViewPartialView", cvm);
        }

        [SessionAuthorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult EliminaCiudad(int CiudadId)
        {
            if (CiudadId >= 0)
            {
                try
                {
                    bool isSave = CiudadDB.EliminaCiudad(CiudadId);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }

            cvm = new CiudadViewModel
            {
                Ciudades = CiudadViewModel.GetCiudades(),
                Cuentas = CiudadViewModel.GetCuentas()

            };

            return PartialView("GridViewPartialView", cvm);
        }

    }
}
