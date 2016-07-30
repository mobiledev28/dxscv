using SCVData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXSCV.Models
{
    public class RevisionViewModel
    {
        public List<SCV_Cuenta> Cuentas { get; set; }
        public List<SCV_Revision> Revisiones { get; set; }
        public List<UsuarioViewModel> Usuarios {get; set;}

        public List<SCV_Vehiculo> Vehiculos { get; set; }

        public List<SCV_TipoDocumento> TiposDocumentos { get; set; }


        
    }

    public static class RevisionesList{
        public static List<SCV_Cuenta> GetCuentas()
        {
            List<SCV_Cuenta> cuentasList = AccountDB.ObtieneCuentasDB();
            return cuentasList;
        }

        public static List<SCV_Revision> GetRevisiones()
        {
            List<SCV_Revision> revisionList = RevisionDB.ObtieneRevisionesDB();
            return revisionList;
        }

        public static List<UsuarioViewModel> GetUsuarios()
        {
            List<UsuarioViewModel> vehvmList = new List<UsuarioViewModel>();
            UsuarioViewModel vvm;

            List<SCV_Usuario> usrList = UsuarioDB.ObtieneUsuariosDB();
            foreach (SCV_Usuario usr in usrList)
            {
                vvm = new UsuarioViewModel
                {
                    NombreCompleto = usr.Nombre + " " + usr.ApPaterno,
                    UsuarioId = usr.UsuarioId
                };
                vehvmList.Add(vvm);
            }

            return vehvmList;
        }

        public static List<SCV_Vehiculo> GetVehiculos()
        {
            List<SCV_Vehiculo> vehList = new List<SCV_Vehiculo>();
            vehList = VehiculoDB.ObtieneVehiculosDB();
            return vehList;

        }

        public static List<SCV_TipoDocumento> GetTiposDocumentos()
        {
            List<SCV_TipoDocumento> tdList = new List<SCV_TipoDocumento>();
            tdList = TipoDocumentoDB.ObtieneTipoDocumentosDB();
            return tdList;
        }
    }
}