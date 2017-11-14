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
    public class NotificacionController : Controller
    {
        [SessionAuthorize]
        public ActionResult Index()
        {
            return View(GetInfoNotificacioViewModel());
        }

        [SessionAuthorize]
        [ValidateInput(false)]
        public ActionResult GridViewPartialView()
        {
            
            // DXCOMMENT: Pass a data model for GridView in the PartialView method's second parameter
            return PartialView("GridViewPartialView", GetInfoNotificacioViewModel());
        }


        public NotificacionViewModel GetInfoNotificacioViewModel()
        {
            SessionUserViewModel suvm = new SessionUserViewModel();
            if (Session["_UserLogged"] != null)
            {
                suvm = (SessionUserViewModel)Session["_UserLogged"];
            }

            List<SCV_Empresa> empList = EmpresaDB.ObtieneEmpresasDB();

            if (!suvm.IsHerrMty)
            {
                empList.Remove(empList.FirstOrDefault(e => e.EmpresaId == 1));
            }

            if (!suvm.IsMetalinspec)
            {
                empList.Remove(empList.FirstOrDefault(e => e.EmpresaId == 2));
            }

            if (!suvm.IsMetalinspecLab)
            {
                empList.Remove(empList.FirstOrDefault(e => e.EmpresaId == 3));
            }

            if (!suvm.IsMetroLab)
            {
                empList.Remove(empList.FirstOrDefault(e => e.EmpresaId == 4));
            }

            NotificacionViewModel nvm = new NotificacionViewModel
            {
                Estatus = NotificacionViewModel.GetNotificacionEstatus(),
                Cuentas = NotificacionViewModel.GetCuentas(empList),
                Notificaciones = NotificacionViewModel.GetNotificacionesByCuenta(suvm.CuentaId)
            };

            return nvm;
        }



        [SessionAuthorize]
        public ActionResult CambiaVistaModoEdicion(GridViewEditingMode editMode)
        {
            SessionUserViewModel suvm = new SessionUserViewModel();
            if (Session["_UserLogged"] != null)
            {
                suvm = (SessionUserViewModel)Session["_UserLogged"];
            }

            GridViewEditHelper.EditMode = editMode;
            return PartialView("GridViewPartialView", NotificacionDB.ObtieneNotificacionesByCuentaDB(suvm.CuentaId));
        }

        [SessionAuthorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult AgregaNotificacion(SCV_Notificacion Notificacion)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isSave = NotificacionDB.InsertaNotificacion(Notificacion);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            //nvm = new NotificacionViewModel
            //{
            //    Notificacions = NotificacionViewModel.GetNotificacions(),
            //    Cuentas = NotificacionViewModel.GetCuentas(),
            //    TiposDocumentos = NotificacionViewModel.GetTiposDocumentos()

            //};
            return PartialView("GridViewPartialView", GetInfoNotificacioViewModel());
        }

        [SessionAuthorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult ActualizaNotificacion(SCV_Notificacion Notificacion)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isSave = NotificacionDB.ActualizaNotificacion(Notificacion);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            //nvm = new NotificacionViewModel
            //{
            //    Notificacions = NotificacionViewModel.GetNotificacions(),
            //    Cuentas = NotificacionViewModel.GetCuentas(),
            //    TiposDocumentos = NotificacionViewModel.GetTiposDocumentos()

            //};
            return PartialView("GridViewPartialView", GetInfoNotificacioViewModel());
        }

        [SessionAuthorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult EliminaNotificacion(int NotificacionId)
        {
            if (NotificacionId >= 0)
            {
                try
                {
                    bool isSave = NotificacionDB.EliminaNotificacion(NotificacionId);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }

            //nvm = new NotificacionViewModel
            //{
            //    Notificacions = NotificacionViewModel.GetNotificacions(),
            //    Cuentas = NotificacionViewModel.GetCuentas(),
            //    TiposDocumentos = NotificacionViewModel.GetTiposDocumentos()

            //};

            return PartialView("GridViewPartialView", GetInfoNotificacioViewModel());
        }

    }
}
