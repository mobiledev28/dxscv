using SCVData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXSCV.Models
{
    public class EmpresaViewModel
    {

        public int EmpresaId { get; set; }
        public string Nombre { get; set; }
        public List<SCV_Empresa> Empresas { get; set; }
        public List<SCV_Cuenta> Cuentas { get; set; }



        public static List<SCV_Empresa> GetEmpresas()
        {
            List<SCV_Empresa> empList = EmpresaDB.ObtieneEmpresasDB();
            return empList;
        }

        public static List<SCV_Cuenta> GetCuentas()
        {
            List<SCV_Cuenta> cuentasList = AccountDB.ObtieneCuentasDB();
            return cuentasList;
        }
    }
}