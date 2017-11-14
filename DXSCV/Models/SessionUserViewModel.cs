using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXSCV.Models
{
    public class SessionUserViewModel
    {

        public string UserName { get; set; }
        public string Email { get; set; }
        public long CuentaId { get; set; }

        public long TipoUsuarioId { get; set; }

        public int EmpresaId { get; set; }

        public bool IsHerrMty { get; set; }
        public bool IsMetalinspec { get; set; }
        public bool IsMetroLab { get; set; }

        public bool IsMetalinspecLab { get; set; }

    }
}