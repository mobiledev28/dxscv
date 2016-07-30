using SCVData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXSCV.Models
{
    public class CiudadViewModel
    {
        public int CiudadId { get; set; }
        public string Descripcion { get; set; }
        public List<SCV_Ciudad> Ciudades { get; set; }
        public List<SCV_Cuenta> Cuentas { get; set; }



        public static List<SCV_Ciudad> GetCiudades()
        {
            List<SCV_Ciudad> ciuList = CiudadDB.ObtieneCiudadesDB();
            return ciuList;
        }

        public static List<SCV_Cuenta> GetCuentas()
        {
            List<SCV_Cuenta> cuentasList = AccountDB.ObtieneCuentasDB();
            return cuentasList;
        }
    }
}