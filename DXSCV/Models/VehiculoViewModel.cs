
using SCVData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXSCV.Models
{
    public class VehiculoViewModel
    {
        public List<UsuarioViewModel> Usuarios { get; set; }
        public List<SCV_Vehiculo> Vehiculos { get; set; }

        public List<SCV_Ciudad> Ciudades { get; set; }
        public List<EmpresaViewModel> Empresas { get; set; }

        public List<SCV_Cuenta> Cuentas { get; set; }

        public List<SCV_TipoDocumento> TiposDocumentos { get; set; }

        public SessionUserViewModel UsuarioActivo { get; set; }
    }

    public static class VehiculosList
    {
        public static List<SCV_Vehiculo> GetVehiculos()
        {
            List<SCV_Vehiculo> vehList = new List<SCV_Vehiculo>();
            vehList = VehiculoDB.ObtieneVehiculosDB();
            return vehList;

        }

        public static List<SCV_Vehiculo> GetVehiculosByEmpresas(List<SCV_Empresa> empresasList, int empresaId)
        {
            List<SCV_Vehiculo> vehList = new List<SCV_Vehiculo>();
            vehList = VehiculoDB.ObtieneVehiculosByEmpresasDB(empresasList, empresaId);
            return vehList;
        }

        public static List<SCV_Vehiculo> GetVehiculosByEmpresas(List<SCV_Empresa> empresasList)
        {
            List<SCV_Vehiculo> vehList = new List<SCV_Vehiculo>();
            vehList = VehiculoDB.ObtieneVehiculosByEmpresasDB(empresasList);
            return vehList;
        }

        public static List<SCV_Vehiculo> GetVehiculosByEmpresasAndFiltros(List<SCV_Empresa> empresasList, int vehiculoId, string serie, string placa)
        {
            List<SCV_Vehiculo> vehList = new List<SCV_Vehiculo>();
            vehList = VehiculoDB.ObtieneVehiculosByEmpresasAndFiltrosDB(empresasList, vehiculoId, serie, placa);
            return vehList;
        }


        public static List<SCV_Vehiculo> GetVehiculosByEmpresa(int empresaId)
        {
            List<SCV_Vehiculo> vehList = new List<SCV_Vehiculo>();
            vehList = VehiculoDB.ObtieneVehiculosByEmpresaDB(empresaId);
            return vehList;

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

        public static List<SCV_Ciudad> GetCiudades()
        {
            List<SCV_Ciudad> ciduadesList = CiudadDB.ObtieneCiudadesDB();
            return ciduadesList;
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

        public static List<SCV_Cuenta> GetCuentasByEmpresa(int EmpresaId)
        {
            List<SCV_Cuenta> cuentasList = AccountDB.ObtieneCuentasByEmpresaDB(EmpresaId);
            return cuentasList;
        }

        public static List<SCV_TipoDocumento> GetTiposDocumentos()
        {
            List<SCV_TipoDocumento> tdList = new List<SCV_TipoDocumento>();
            tdList = TipoDocumentoDB.ObtieneTipoDocumentosDB();
            return tdList;
        }
    }
}