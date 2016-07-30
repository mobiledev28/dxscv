using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXSCV.Models
{
    public class OrdenMttoViewModel
    {
        public string Empresa { get; set; }
        public long MttoId { get; set; }

        public string SucAsignada { get; set; }

        public string Usuario { get; set; }

        public string Motivo { get; set; }

        public string FechaIngreso { get; set; }
        public string FechaPromesa { get; set; }

        public string FechaTerminada { get; set; }

        public string Proveedor { get; set; }

        public string DescMtto { get; set; }

        public string Placa { get; set; }

        public string Serie { get; set; }

        public double Kms { get; set; }

        public string Marca { get; set; }

        public string Linea { get; set; }

        public int Modelo { get; set; }

        public string Factura { get; set; }

        public string SubTotal { get; set; }

        public string IVA { get; set; }

        public string Total { get; set; }


    }
}