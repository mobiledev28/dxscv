using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXSCV.Models
{
    public class VehiculoVM
    {
        public long VehiculoId { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public string NoSerie { get; set; }
        public string Apodo { get; set; }
        public string Placa { get; set; }
        public string NoMotor { get; set; }
        public string Color { get; set; }
        public string Engomado { get; set; }
        public string EstatusAdq { get; set; }
        public int CiudadId { get; set; }
        public int EmpresaId { get; set; }
        public long UsuarioIdAsignado { get; set; }
        public Nullable<bool> EquipoGPS { get; set; }
        public string NombreGPS { get; set; }
        public string EstatusVehiculo { get; set; }
        public Nullable<int> Refrendo { get; set; }
        public System.DateTime FechaAlta { get; set; }
        public long UsuarioIdAlta { get; set; }
        public Nullable<System.DateTime> FechaMod { get; set; }
        public Nullable<long> UsuarioIdMod { get; set; }
        public Nullable<decimal> Kilometraje { get; set; }
    }
}