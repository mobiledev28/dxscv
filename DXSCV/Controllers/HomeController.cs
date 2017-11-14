using DevExpress.Web.Mvc;
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
    public class HomeController : Controller
    {
        private SCV_Usuario scvusuario = new SCV_Usuario();

        
        

        public UsuarioViewModel GetInfoUsuarioViewModel()
        {
            SessionUserViewModel suvm = new SessionUserViewModel();
            if (Session["_UserLogged"] != null)
            {
                suvm = (SessionUserViewModel)Session["_UserLogged"];
            }

            int icuentaid = (int)suvm.CuentaId;

            UsuarioViewModel uvm = new UsuarioViewModel
            {
                Sucursales = UsuariosList.GetEmpresas(),
                Usuarios = UsuariosList.GetUsuariosLicenciaProxVencer(),
                Cuentas = UsuariosList.GetCuentas(),
                TiposDocumentos = UsuariosList.GetTiposDocumentos(),
                Notificaciones = UsuariosList.GetNotificacionesActivasByCuenta(suvm.CuentaId),
                Estatus = UsuariosList.GetNotificacionEstatus(),
                Appointments = UsuariosList.GetAppointments(icuentaid),
                Resources = UsuariosList.GetResources()

            };

            uvm.ShowLinkHerrMty = suvm.IsHerrMty;
            uvm.ShowLinkMetalinspec = suvm.IsMetalinspec;
            uvm.ShowLinkMetalinspecLab = suvm.IsMetalinspecLab;
            uvm.ShowLinkMetroLab = suvm.IsMetroLab;

            return uvm;
        }

        [SessionAuthorize]
        public ActionResult Index()
        {
            return View(GetInfoUsuarioViewModel());
        }

        [SessionAuthorize]
        public ActionResult GridViewPartialView() 
        {

            // DXCOMMENT: Pass a data model for GridView in the PartialView method's second parameter
            return PartialView("GridViewPartialView");
        }

        //public ActionResult ChartEventosPartialView()
        //{

        //    return PartialView("ChartEventosPartialView");
        //}

        public ActionResult SchedulerPartial()
        {
            return PartialView("SchedulerPartial", GetInfoUsuarioViewModel());
        }

        public ActionResult EditAppointment()
        {
            //Get CuentaId
            SessionUserViewModel suvm = new SessionUserViewModel();
            if (Session["_UserLogged"] != null)
            {
                suvm = (SessionUserViewModel)Session["_UserLogged"];
            }
            UpdateAppointment(suvm.CuentaId);
            return PartialView("SchedulerPartial", GetInfoUsuarioViewModel());
        }

        static void UpdateAppointment(long cuentaId)
        {
            
            SCV_DBAppointments[] insertedAppointments = SchedulerExtension.GetAppointmentsToInsert<SCV_DBAppointments>("scheduler", SchedulerDataHelper.GetAppointments((int)cuentaId),
                SchedulerDataHelper.GetResources(), SchedulerStorageProvider.DefaultAppointmentStorage, SchedulerStorageProvider.DefaultResourceStorage);
            foreach (var appt in insertedAppointments)
            {
                appt.CuentaId = (int)cuentaId;
                DXSCV.Helpers.SchedulerDataHelper.AppointmentDataAccessor.InsertAppointment(appt);
            }

            SCV_DBAppointments[] updatedAppointments = SchedulerExtension.GetAppointmentsToUpdate<SCV_DBAppointments>("scheduler", SchedulerDataHelper.GetAppointments((int)cuentaId),
                SchedulerDataHelper.GetResources(), SchedulerStorageProvider.DefaultAppointmentStorage, SchedulerStorageProvider.DefaultResourceStorage);
            foreach (var appt in updatedAppointments)
            {
                appt.CuentaId = (int)cuentaId;
                DXSCV.Helpers.SchedulerDataHelper.AppointmentDataAccessor.UpdateAppointment(appt);
            }

            SCV_DBAppointments[] removedAppointments = SchedulerExtension.GetAppointmentsToRemove<SCV_DBAppointments>("scheduler", SchedulerDataHelper.GetAppointments((int)cuentaId),
                SchedulerDataHelper.GetResources(), SchedulerStorageProvider.DefaultAppointmentStorage, SchedulerStorageProvider.DefaultResourceStorage);
            foreach (var appt in removedAppointments)
            {
                DXSCV.Helpers.SchedulerDataHelper.AppointmentDataAccessor.RemoveAppointment(appt);
            }
        }
    
    }
}

public enum HeaderViewRenderMode { Full, Title }