using System;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using SCVData;
using DevExpress.Web;
using DXSCVWeb.Models;

namespace DXSCVWeb.Controllers
{
    public partial class EditingController : DemoController
    {
        private SCV_Cuenta cuenta = new SCV_Cuenta();
        public ActionResult EditModes()
        {
            return DemoView("EditModes", AccountDB.ObtieneCuentasDB());
        }
        [ValidateInput(false)]
        public ActionResult EditModesPartial()
        {
            return PartialView("EditModesPartial", AccountDB.ObtieneCuentasDB());
        }
        public ActionResult ChangeEditModePartial(GridViewEditingMode editMode)
        {
            GridViewEditingDemosHelper.EditMode = editMode;
            return PartialView("EditModesPartial", AccountDB.ObtieneCuentasDB());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult EditModesAddNewPartial(SCVCuentaViewModel cta)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    cuenta = new SCV_Cuenta();
                    cuenta.UserName = cta.UserName;
                    cuenta.Password = cta.Password;
                    cuenta.Activo = true;
                    bool isSave = AccountDB.InsertaCuenta(cuenta);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("EditModesPartial", AccountDB.ObtieneCuentasDB());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult EditModesUpdatePartial(SCVCuentaViewModel cta)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    cuenta = new SCV_Cuenta();
                    cuenta.UserName = cta.UserName;
                    cuenta.Password = cta.Password;
                    cuenta.Activo = true;
                    bool isSave = AccountDB.ActualizaCuenta(cuenta);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            return PartialView("EditModesPartial", AccountDB.ObtieneCuentasDB());
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
            return PartialView("EditModesPartial", AccountDB.ObtieneCuentasDB());
        }
    }
}
