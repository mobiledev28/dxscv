using SCVData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXSCV.Models
{
    public class TipoEventoViewModel
    {
        public List<SCV_TipoEvento> TiposEventos { get; set; }
        public List<SCV_Cuenta> Cuentas { get; set; }



        public static List<SCV_TipoEvento> GetTiposEventos()
        {
            List<SCV_TipoEvento> teList = TipoEventoDB.ObtieneTipoEventosDB();
            return teList;
        }

        public static List<SCV_Cuenta> GetCuentas()
        {
            List<SCV_Cuenta> cuentasList = AccountDB.ObtieneCuentasDB();
            return cuentasList;
        }
    }
}