using SCVData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXSCV.Models
{
    public class FichaTecnicaVehiculoViewModel
    {
        public List<SCV_Vehiculo> Vehiculos { get; set; }
        public List<SCV_FichaTecnicaVehiculo> FichasTecnicasVehiculos { get; set; }
        public List<SCV_Proveedor> Proveedores { get; set; }
        public List<SCV_TipoDocumento> TiposDocumentos { get; set; }

        public int FichaTecnicaVehiculoId {get; set;}
        public DateTime? FechaCompra { get; set; }
        public string sFechaCompra { get; set; }
        public string Factura {get;set;}
        public decimal ValorFactura {get;set;}
        public int ProveedorId {get; set;}
        public string TipoAdquisicion {get; set;}
        public decimal? TasaInteres {get; set;}
        public decimal? PagoInicial {get; set;}
        public decimal? RentaMensual {get; set;}
        public decimal? ValorResidual {get; set;}
        public string Aseguradora {get; set;}
        public string Poliza {get; set;}
        public decimal? PrimaTotal {get; set;}
        public string Endoso {get; set;}
        public DateTime? Vigencia {get; set;}
        public string sVigencia { get; set; }
        public string TarjetaCirculacion { get; set; }
        public string RazonSocial { get; set; }

        public string Modelo { get; set; }
        public int Anio { get; set; }
        public string Serie { get; set; }
        public string Placa { get; set; }
        public string Ciudad { get; set; }
        public string Usuario { get; set; }



        public static List<SCV_Vehiculo> GetVehiculosByEmpresa(List<SCV_Empresa> empList)
        {
            List<SCV_Vehiculo> vehList = VehiculoDB.ObtieneVehiculosByEmpresasDB(empList);
            return vehList;
        }

        public static List<SCV_FichaTecnicaVehiculo> GetFTVehiculos()
        {
            List<SCV_FichaTecnicaVehiculo> ftVehiculosList = FichaTecnicaDB.ListaFTVehiculosDB();
            return ftVehiculosList;
        }

        public static List<SCV_Proveedor> GetProveedores()
        {
            List<SCV_Proveedor> pList = new List<SCV_Proveedor>();
            pList = ProveedorDB.ObtieneProveedorsDB();
            return pList;
        }

        public static List<SCV_TipoDocumento> GetTiposDocumentos()
        {
            List<SCV_TipoDocumento> tdList = new List<SCV_TipoDocumento>();
            tdList = TipoDocumentoDB.ObtieneTipoDocumentosDB();
            return tdList;
        }

        public static string GetRazonSocial(int proveedorId)
        {
            string razonSocial;
            razonSocial = ProveedorDB.ObtieneProveedorById(proveedorId);
            return razonSocial;
        }

    }
}