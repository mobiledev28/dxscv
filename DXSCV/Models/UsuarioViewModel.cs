using SCVData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXSCV.Models
{
    public class UsuarioViewModel
    {
        public IEnumerable<EmpresaViewModel> Sucursales { get; set; }

        public string NombreCompleto { get; set; }
        public long UsuarioId { get; set; }
        public List<SCV_Usuario> Usuarios { get; set; }

        public List<SCV_Cuenta> Cuentas { get; set; }
        public List<SCV_TipoDocumento> TiposDocumentos { get; set; }
        public List<SCV_Notificacion> Notificaciones { get; set; }
        public List<SCV_NotificacionEstatus> Estatus { get; set; }
        public System.Collections.IEnumerable Appointments { get; set; }
        public System.Collections.IEnumerable Resources { get; set; }
       


        public bool ShowLinkHerrMty { get; set; }
        public bool ShowLinkMetalinspec { get; set; }
        public bool ShowLinkMetroLab { get; set; }
        public bool ShowLinkMetalinspecLab { get; set; }
    }

    public static class UsuariosList
    {
        public static System.Collections.IEnumerable GetResources()
        {
            TCADBHMTEntities db = new TCADBHMTEntities();
            List<SCV_DBResources> rssList = new List<SCV_DBResources>();
            rssList = db.SCV_DBResources.ToList();
            return rssList;
        }
        public static System.Collections.IEnumerable GetAppointments(int cuentaId)
        {
            TCADBHMTEntities db = new TCADBHMTEntities();
            List<SCV_DBAppointments> aptList = new List<SCV_DBAppointments>();
            aptList = db.SCV_DBAppointments.Where(a => a.CuentaId == cuentaId).ToList();
            return aptList;
        }

        public static List<SCV_Usuario> GetUsuarios()
        {
            List<SCV_Usuario> usrList = new List<SCV_Usuario>();
            usrList = UsuarioDB.ObtieneUsuariosDB();
            return usrList;
            
        }

        public static List<SCV_Usuario> GetUsuariosLicenciaProxVencer()
        {
            List<SCV_Usuario> usrList = new List<SCV_Usuario>();
            usrList = UsuarioDB.ObtieneUsuariosDB().Where(usr => usr.AnioVigenciaLicencia == DateTime.Now.Year && usr.MesVigenciaLicencia == DateTime.Now.Month).ToList();
            return usrList;

        }
        public static List<EmpresaViewModel> GetEmpresas()
        {
            List<EmpresaViewModel> empvmList = new List<EmpresaViewModel>();
            EmpresaViewModel svm;

            List<SCV_Empresa> empList = EmpresaDB.ObtieneEmpresasDB();
            foreach (SCV_Empresa emp in empList)
            {
                svm = new EmpresaViewModel
                {
                    Nombre = emp.Nombre,
                    EmpresaId = emp.EmpresaId
                };
                empvmList.Add(svm);
            }

            return empvmList;
        }

        public static List<SCV_Cuenta> GetCuentas()
        {
            List<SCV_Cuenta> cuentasList = AccountDB.ObtieneCuentasDB();
            return cuentasList;
        }

        public static List<SCV_TipoDocumento> GetTiposDocumentos()
        {
            List<SCV_TipoDocumento> tiposdocsList = TipoDocumentoDB.ObtieneTipoDocumentosDB();
            return tiposdocsList;
        }


        public static List<SCV_Notificacion> GetNotificacionesActivasByCuenta(long cuentaId)
        {
            List<SCV_Notificacion> notificacionList = NotificacionDB.ObtieneNotificacionesActivasByCuentaDB(cuentaId);
            return notificacionList;
        }

        public static List<SCV_NotificacionEstatus> GetNotificacionEstatus()
        {
            List<SCV_NotificacionEstatus> cuentasList = NotificacionDB.ObtieneNotificacionEstatusDB();
            return cuentasList;
        }
        

        
    }
}