using SCVData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXSCV.Models
{
    public class NotificacionViewModel
    {
        public List<SCV_NotificacionEstatus> Estatus { get; set; }
        public List<SCV_Cuenta> Cuentas { get; set; }
        public List<SCV_Notificacion> Notificaciones { get; set; }

        public int NotificacionId { get; set; }
        public string Descripcion { get; set; }
        public System.DateTime FechaNotificacion { get; set; }
        public int NotificacionEstatusId { get; set; }
        public int CuentaId { get; set; }
        public string Correo { get; set; }
        public System.DateTime FechaAlta { get; set; }
        public Nullable<System.DateTime> FechaMod { get; set; }


        public static List<SCV_Cuenta> GetCuentas(List<SCV_Empresa> empresasList)
        {
            List<SCV_Cuenta> cuentasList = AccountDB.ObtieneCuentasByEmpresasDB(empresasList);
            return cuentasList;
        }

        public static List<SCV_NotificacionEstatus> GetNotificacionEstatus()
        {
            List<SCV_NotificacionEstatus> cuentasList = NotificacionDB.ObtieneNotificacionEstatusDB();
            return cuentasList;
        }

        public static List<SCV_Notificacion> GetNotificacionesByCuenta(long cuentaId)
        {
            List<SCV_Notificacion> notificacionList = NotificacionDB.ObtieneNotificacionesByCuentaDB(cuentaId);
            return notificacionList;
        }





    }
}