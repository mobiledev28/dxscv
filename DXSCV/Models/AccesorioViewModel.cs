using SCVData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXSCV.Models
{
    public class AccesorioViewModel
    {
        public List<SCV_Accesorio> Accesorios { get; set; }
        public List<SCV_Cuenta> Cuentas { get; set; }
        public List<SCV_TipoDocumento> TiposDocumentos { get; set; }



        public static List<SCV_Accesorio> GetAccesorios()
        {
            List<SCV_Accesorio> empList = AccesorioDB.ObtieneAccesoriosDB();
            return empList;
        }

        public static List<SCV_Cuenta> GetCuentas()
        {
            List<SCV_Cuenta> cuentasList = AccountDB.ObtieneCuentasDB();
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