using SCVData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXSCV.Models
{
    public class FichaTecnicaUsuarioViewModel
    {
        public List<SCV_Usuario> Usuarios { get; set; }
        public List<SCV_FichaTecnicaUsuario> FichasTecnicasUsuarios { get; set; }
        public List<SCV_Ciudad> Ciudades { get; set; }
        public List<SCV_TipoDocumento> TiposDocumentos { get; set; }

        public int FichaTecnicaUsuarioId { get; set; }
        public int NumColaborador { get; set; }
        public string Nombre { get; set; }
        public Nullable<System.DateTime> FechaIngreso { get; set; }
        public string sFechaIngreso { get; set; }
        public string Imss { get; set; }
        public string Licencia { get; set; }
        public string Ine { get; set; }
        public int CuidadId { get; set; }
        public string Departamento { get; set; }
        public string NumCelular { get; set; }
        public string Email { get; set; }
        public Nullable<long> UsuarioId { get; set; }
        public string Ciudad { get; set; }
        public string FotoUrl { get; set; }

        public static List<SCV_Usuario> GetUsuarios()
        {
            List<SCV_Usuario> uList = new List<SCV_Usuario>();
            uList = UsuarioDB.ObtieneUsuariosDB();
            return uList;
        }

        public static List<SCV_Usuario> GetUsuariosByEmpresas(List<SCV_Empresa> empresasList)
        {
            List<SCV_Usuario> usrList = new List<SCV_Usuario>();
            usrList = UsuarioDB.ObtieneUsuariosByEmpresasDB(empresasList);
            return usrList;
        }

        public static List<SCV_FichaTecnicaUsuario> GetFTUsuarios()
        {
            List<SCV_FichaTecnicaUsuario> uList = new List<SCV_FichaTecnicaUsuario>();
            uList = FichaTecnicaDB.ListaFTUsuariosDB();

            //foreach (SCV_FichaTecnicaUsuario ftu in uList)
            //{
            //    ftu.Email = @"<a href='mailto:" + ftu.Email + "?Subject=Sistema%20de%20Control%20de%20Vehiculos' target='_top'>" + ftu.Email + "</a>";
            //}

            return uList;
        }

        public static List<SCV_Ciudad> GetCiudades()
        {
            List<SCV_Ciudad> cList = new List<SCV_Ciudad>();
            cList = CiudadDB.ObtieneCiudadesDB();
            return cList;
        }

        public static List<SCV_TipoDocumento> GetTiposDocumentos()
        {
            List<SCV_TipoDocumento> tdList = new List<SCV_TipoDocumento>();
            tdList = TipoDocumentoDB.ObtieneTipoDocumentosDB();
            return tdList;
        }
    }
}