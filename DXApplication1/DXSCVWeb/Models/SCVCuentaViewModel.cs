using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXSCVWeb.Models
{
    public class SCVCuentaViewModel
    {
        public int CuentaId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public bool Activo { get; set; }
        public string FechaAlta { get; set; }
    }
}