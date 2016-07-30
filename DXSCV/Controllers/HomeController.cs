using DXSCV.Common;
using DXSCV.Models;
using SCVData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using DXSCV.Models;

namespace DXSCV.Controllers
{
    public class HomeController : Controller
    {
        private SCV_Usuario scvusuario = new SCV_Usuario();

        UsuarioViewModel uvm = new UsuarioViewModel
        {
            Sucursales = UsuariosList.GetEmpresas(),
            Usuarios = UsuariosList.GetUsuariosLicenciaProxVencer(),
            Cuentas = UsuariosList.GetCuentas(),
            TiposDocumentos = UsuariosList.GetTiposDocumentos()

        };

        [SessionAuthorize]
        public ActionResult Index()
        {
            return View(uvm);
        }

        [SessionAuthorize]
        public ActionResult GridViewPartialView() 
        {

            // DXCOMMENT: Pass a data model for GridView in the PartialView method's second parameter
            return PartialView("GridViewPartialView");
        }

        //public ActionResult ChartEventosPartialView()
        //{

        //    return PartialView("ChartEventosPartialView");
        //}
    
    }
}

public enum HeaderViewRenderMode { Full, Title }