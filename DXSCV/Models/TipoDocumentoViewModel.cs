using SCVData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXSCV.Models
{
    public class TipoDocumentoViewModel
    {
        public List<SCV_TipoDocumento> TiposDocumentos { get; set; }
        public List<SCV_Cuenta> Cuentas { get; set; }



        public static List<SCV_TipoDocumento> GetTiposDocumentos()
        {
            List<SCV_TipoDocumento> tdList = TipoDocumentoDB.ObtieneTipoDocumentosDB();
            return tdList;
        }

        public static List<SCV_Cuenta> GetCuentas()
        {
            List<SCV_Cuenta> cuentasList = AccountDB.ObtieneCuentasDB();
            return cuentasList;
        }
    }

}