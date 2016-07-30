using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DXSCVWeb.Models;
using SCVData;
using DevExpress.Web;

namespace DXSCVWeb.Controllers
{
    public class HomeController : Controller
    {
        private SCV_Cuenta cuenta = new SCV_Cuenta();
        public ActionResult Index()
        {
            // DXCOMMENT: Pass a data model for GridView
            
            return View(AccountDB.ObtieneCuentasDB());
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartialView() 
        {
            // DXCOMMENT: Pass a data model for GridView in the PartialView method's second parameter
            return PartialView("GridViewPartialView", AccountDB.ObtieneCuentasDB());
        }


        
        public ActionResult ChangeEditModePartial(GridViewEditingMode editMode)
        {
            GridViewEditingDemosHelper.EditMode = editMode;
            return PartialView("GridViewPartialView", AccountDB.ObtieneCuentasDB());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult EditModesAddNewPartial(SCV_Cuenta cta)
        {
            //if (ModelState.IsValid)
            //{
            try
            {
                //cuenta = new SCV_Cuenta();
                //cuenta.UserName = cta.UserName;
                //cuenta.Password = cta.Password;
                //cuenta.Activo = cta.Activo;
                bool isSave = AccountDB.InsertaCuenta(cta);
            }
            catch (Exception e)
            {
                ViewData["EditError"] = e.Message;
            }
            //}
            //else
            //    ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("GridViewPartialView", AccountDB.ObtieneCuentasDB());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult EditModesUpdatePartial(SCV_Cuenta cta)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //cuenta = new SCV_Cuenta();
                    //cuenta.UserName = cta.UserName;
                    //cuenta.Password = cta.Password;
                    //cuenta.Activo = cta.Activo;
                    bool isSave = AccountDB.ActualizaCuenta(cta);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            return PartialView("GridViewPartialView", AccountDB.ObtieneCuentasDB());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult EditModesDeletePartial(int cuentaId)
        {
            if (cuentaId >= 0)
            {
                try
                {
                    bool isSave = AccountDB.EliminaCuenta(cuentaId);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("GridViewPartialView", AccountDB.ObtieneCuentasDB());
        }
    
    }
}