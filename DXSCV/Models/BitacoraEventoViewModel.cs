using SCVData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXSCV.Models
{
    public class BitacoraEventoViewModel
    {
        public List<SCV_Vehiculo> Vehiculos { get; set; }
        public List<SCV_TipoEvento> TiposEventos { get; set; }
        public List<SCV_Cuenta> Cuentas { get; set; }
        public List<SCV_BitacoraEvento> Eventos { get; set; }
        public List<SCV_TipoDocumento> TiposDocumentos { get; set; }

        public List<SCV_Proveedor> Proveedores { get; set; }
        
    }

    public static class BitacoraEventosList
    {
        public static List<SCV_BitacoraEvento> GetEventos()
        {
            List<SCV_BitacoraEvento> beList = BitacoraEventoDB.ObtieneEventosDB();
            return beList;
        }

        public static List<SCV_Vehiculo> GetVehiculos()
        {
            List<SCV_Vehiculo> vehList = new List<SCV_Vehiculo>();
            vehList = VehiculoDB.ObtieneVehiculosDB();
            return vehList;

        }

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

    

        public static List<SCV_TipoDocumento> GetTiposDocumentos()
        {
            List<SCV_TipoDocumento> tdList = new List<SCV_TipoDocumento>();
            tdList = TipoDocumentoDB.ObtieneTipoDocumentosDB();
            return tdList;
        }

        public static List<SCV_Proveedor> GetProveedores()
        {
            List<SCV_Proveedor> pList = new List<SCV_Proveedor>();
            pList = ProveedorDB.ObtieneProveedorsDB();
            return pList;
        }
    }
}