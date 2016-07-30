using SCVData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXSCV.Models
{
    public class MantenimientoViewModel
    {

        public List<SCV_Mantenimiento> Mantenimientos { get; set; }
        public List<UsuarioViewModel> Usuarios { get; set; }
        public List<SCV_Vehiculo> Vehiculos { get; set; }
        public List<SCV_Ciudad> Ciudades { get; set; }

        public List<SCV_Cuenta> Cuentas { get; set; }

        public List<SCV_Proveedor> Proveedores { get; set; }

        public List<SCV_Empresa> Empresas { get; set; }

        public List<SCV_TipoDocumento> TiposDocumentos { get; set; }


    }

    public static class MantenimientoList
    {
        public static List<SCV_Mantenimiento> GetMantenimientos()
        {
            List<SCV_Mantenimiento> mttoList = new List<SCV_Mantenimiento>();
            mttoList = MantenimientoDB.ObtieneMantenimientosDB();
            return mttoList;

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
        public static List<SCV_Ciudad> GetCiudades()
        {
            List<SCV_Ciudad> ciuList = new List<SCV_Ciudad>();
            ciuList = CiudadDB.ObtieneCiudadesDB();
            return ciuList;
        }
        public static List<SCV_Cuenta> GetCuentas()
        {
            List<SCV_Cuenta> cuentasList = AccountDB.ObtieneCuentasDB();
            return cuentasList;
        }
        public static List<SCV_Proveedor> GetProveedores()
        {
            List<SCV_Proveedor> pList = new List<SCV_Proveedor>();
            pList = ProveedorDB.ObtieneProveedorsDB();
            return pList;
        }
        public static List<SCV_Empresa> GetEmpresas()
        {
            List<SCV_Empresa> eList = new List<SCV_Empresa>();
            eList = EmpresaDB.ObtieneEmpresasDB();
            return eList;
        }

        public static List<SCV_TipoDocumento> GetTiposDocumentos()
        {
            List<SCV_TipoDocumento> tdList = new List<SCV_TipoDocumento>();
            tdList = TipoDocumentoDB.ObtieneTipoDocumentosDB();
            return tdList;
        }
    }
}