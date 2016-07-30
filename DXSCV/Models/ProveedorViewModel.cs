using SCVData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXSCV.Models
{
    public class ProveedorViewModel
    {
        public List<SCV_Proveedor> Proveedores { get; set; }
        public List<SCV_Cuenta> Cuentas { get; set; }
        public List<SCV_TipoDocumento> TiposDocumentos { get; set; }


    }

    public static class ProveedorList {
        public static List<SCV_Cuenta> GetCuentas()
        {
            List<SCV_Cuenta> cuentasList = AccountDB.ObtieneCuentasDB();
            return cuentasList;
        } 

        public static List<SCV_Proveedor> GetProveedores()
        {
            List<SCV_Proveedor> provList = ProveedorDB.ObtieneProveedorsDB();
            return provList;
        }

        public static List<SCV_TipoDocumento> GetTiposDocumentos()
        {
            List<SCV_TipoDocumento> tdList = new List<SCV_TipoDocumento>();
            tdList = TipoDocumentoDB.ObtieneTipoDocumentosDB();
            return tdList;
        }
    }
}