using DevExpress.Web;
using DevExpress.Web.Mvc;
using DXSCV.Common;
using DXSCV.Helpers;
using DXSCV.Models;
using SCVData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DXSCV.Controllers
{
    public class VehiculoController : Controller
    {
        private SCV_Vehiculo vehiculo = new SCV_Vehiculo();

        VehiculoViewModel vvm = new VehiculoViewModel
        {
            Ciudades = VehiculosList.GetCiudades(),
            Empresas = VehiculosList.GetEmpresas(),
            Usuarios = VehiculosList.GetUsuarios(),
            Vehiculos = new List<SCV_Vehiculo>(),
            Cuentas = VehiculosList.GetCuentas(),
            TiposDocumentos = VehiculosList.GetTiposDocumentos()
        };

        //public ActionResult Index()
        //{
        //    return View(vvm);
        //}

        [SessionAuthorize]
        public ActionResult Index(string Filterby)
        {
            SessionUserViewModel suvm = new SessionUserViewModel();
            if (Session["_UserLogged"] != null)
            {
                suvm = (SessionUserViewModel)Session["_UserLogged"];
            }

            int empresaId = 0;
            switch (Filterby)
            {
                case "1":
                    empresaId = 1; //Herramental Monterrey
                    suvm.EmpresaId = empresaId;
                    break;
                case "2":
                    empresaId = 2; //Metalisnpec
                    suvm.EmpresaId = empresaId;
                    break;
                case "3":
                    empresaId = 3; //Metalisnpec Laboratorios
                    suvm.EmpresaId = empresaId;
                    break;
                case "4":
                    empresaId = 4; //MetroLab
                    suvm.EmpresaId = empresaId;
                    break;
            }

            if (empresaId != 0)
            {
                Session["_UserLogged"] = suvm;
            }

            List<SCV_Empresa> empList = EmpresaDB.ObtieneEmpresasDB();

            if (!suvm.IsHerrMty) empList.Remove(empList.FirstOrDefault(e => e.EmpresaId == 1));
            if (!suvm.IsMetalinspec) empList.Remove(empList.FirstOrDefault(e => e.EmpresaId == 2));
            if (!suvm.IsMetalinspecLab) empList.Remove(empList.FirstOrDefault(e => e.EmpresaId == 3));
            if (!suvm.IsMetroLab) empList.Remove(empList.FirstOrDefault(e => e.EmpresaId == 4));
           
            vvm = new VehiculoViewModel
            {
                Ciudades = VehiculosList.GetCiudades(),
                Empresas = VehiculosList.GetEmpresas(),
                Usuarios = VehiculosList.GetUsuarios(),
                Vehiculos = VehiculosList.GetVehiculosByEmpresas(empList, empresaId),
                Cuentas = VehiculosList.GetCuentas(),
                TiposDocumentos = VehiculosList.GetTiposDocumentos(),
                UsuarioActivo = suvm
            };

            return View(vvm);
        }

        [SessionAuthorize]
        [ValidateInput(false)]
        public ActionResult GridViewPartialView()
        {
            SessionUserViewModel suvm = new SessionUserViewModel();
            if (Session["_UserLogged"] != null)
            {
                suvm = (SessionUserViewModel)Session["_UserLogged"];
            }

            int empresaId = 0;
            if (suvm.EmpresaId != 0) empresaId = suvm.EmpresaId;
          
            List<SCV_Empresa> empList = EmpresaDB.ObtieneEmpresasDB();

            if (!suvm.IsHerrMty) empList.Remove(empList.FirstOrDefault(e => e.EmpresaId == 1));
            if (!suvm.IsMetalinspec) empList.Remove(empList.FirstOrDefault(e => e.EmpresaId == 2));
            if (!suvm.IsMetalinspecLab) empList.Remove(empList.FirstOrDefault(e => e.EmpresaId == 3));
            if (!suvm.IsMetroLab) empList.Remove(empList.FirstOrDefault(e => e.EmpresaId == 4));

            vvm.Vehiculos = VehiculosList.GetVehiculosByEmpresas(empList, empresaId);
            // DXCOMMENT: Pass a data model for GridView in the PartialView method's second parameter
            return PartialView("GridViewPartialView", vvm);
        }

        [SessionAuthorize]
        public ActionResult CambiaVistaModoEdicion(GridViewEditingMode editMode)
        {
            GridViewEditHelper.EditMode = editMode;
            return PartialView("GridViewPartialView", vvm);
        }

        //Nueva pantalla vehiculos con filtros
        [SessionAuthorize]
        public ActionResult Vehiculos(string Filterby)
        {
            SessionUserViewModel suvm = new SessionUserViewModel();
            if (Session["_UserLogged"] != null)
            {
                suvm = (SessionUserViewModel)Session["_UserLogged"];
            }

            int empresaId = 0;
            switch (Filterby)
            {
                case "1":
                    empresaId = 1; //Herramental Monterrey
                    suvm.EmpresaId = empresaId;
                    break;
                case "2":
                    empresaId = 2; //Metalisnpec
                    suvm.EmpresaId = empresaId;
                    break;
                case "3":
                    empresaId = 3; //Metalisnpec Laboratorios
                    suvm.EmpresaId = empresaId;
                    break;
                case "4":
                    empresaId = 4; //MetroLab
                    suvm.EmpresaId = empresaId;
                    break;
            }

            if (empresaId != 0)
            {
                Session["_UserLogged"] = suvm;
            }

            //List<EmpresaViewModel> empresaList = new List<EmpresaViewModel>();
            List<SCV_Empresa> empList = EmpresaDB.ObtieneEmpresasDB();

            if (!suvm.IsHerrMty)
            {
                empList.Remove(empList.FirstOrDefault(e => e.EmpresaId == 1));
            }

            if (!suvm.IsMetalinspec)
            {
                empList.Remove(empList.FirstOrDefault(e => e.EmpresaId == 2));
            }

            if (!suvm.IsMetalinspecLab)
            {
                empList.Remove(empList.FirstOrDefault(e => e.EmpresaId == 3));
            }

            if (!suvm.IsMetroLab)
            {
                empList.Remove(empList.FirstOrDefault(e => e.EmpresaId == 4));
            }

            vvm = new VehiculoViewModel
            {
                Ciudades = VehiculosList.GetCiudades(),
                Empresas = VehiculosList.GetEmpresas(),
                Usuarios = VehiculosList.GetUsuarios(),
                Vehiculos = VehiculosList.GetVehiculosByEmpresas(empList, empresaId),
                Cuentas = VehiculosList.GetCuentas(),
                TiposDocumentos = VehiculosList.GetTiposDocumentos(),
                UsuarioActivo = suvm
            };

            return View(vvm);
        }

        [SessionAuthorize]
        [HttpGet]
        public JsonResult FichaTecnicaVehiculo(string id)
        {
            int iVehiculoId = 0;
            int.TryParse(id, out iVehiculoId);
            
            SCV_FichaTecnicaVehiculo ftVehiculo = new SCV_FichaTecnicaVehiculo();
            SCV_Vehiculo vehiculo = new SCV_Vehiculo();
            SCV_Ciudad ciudad = new SCV_Ciudad();
            FichaTecnicaVehiculoViewModel ftvvm = new FichaTecnicaVehiculoViewModel();

            if (!string.IsNullOrEmpty(id))
            {
                ftVehiculo = FichaTecnicaDB.ObtieneFichaTecnicaVehiculo(iVehiculoId);
                vehiculo = VehiculoDB.ObtieneVehiculosByVehiculoIdDB(iVehiculoId);
                

                if (vehiculo != null)
                {
                    ciudad = CiudadDB.ObtieneCiudadeByIdDB(vehiculo.CiudadId);
                    SCV_Usuario usr = UsuarioDB.ObtieneUsuariosByUsuarioIdDB(vehiculo.UsuarioIdAsignado);
                    ftvvm.Modelo = vehiculo.Modelo;
                    ftvvm.Anio = vehiculo.Anio;
                    ftvvm.Serie = vehiculo.NoSerie;
                    ftvvm.Placa = vehiculo.Placa;

                    if (usr != null){
                        ftvvm.Usuario = usr.Nombre + " " + usr.ApPaterno + " " + usr.ApMaterno;
                    }

                    if (ciudad != null)
                    {
                        ftvvm.Ciudad = ciudad.Descripcion;
                    }
                    
                }

                if (ftVehiculo != null)
                {
                    ftvvm.FechaCompra = ftVehiculo.FechaCompra;
                    ftvvm.sFechaCompra = string.Format("{0:d}",ftVehiculo.FechaCompra);
                    ftvvm.Factura = ftVehiculo.Factura;
                    ftvvm.RazonSocial = ProveedorDB.ObtieneProveedorById(ftVehiculo.ProveedorId);
                    ftvvm.ValorFactura = ftVehiculo.ValorFactura;
                    ftvvm.ValorResidual = ftVehiculo.ValorResidual;
                    ftvvm.TipoAdquisicion = ftVehiculo.TipoAdquisicion;
                    ftvvm.TasaInteres = ftVehiculo.TasaInteres;
                    ftvvm.PagoInicial = ftVehiculo.PagoInicial;
                    ftvvm.RentaMensual = ftVehiculo.RentaMensual;
                    ftvvm.ValorResidual = ftVehiculo.ValorResidual;
                    ftvvm.Aseguradora = ftVehiculo.Aseguradora;
                    ftvvm.Poliza = ftVehiculo.Poliza;
                    ftvvm.PrimaTotal = ftVehiculo.PrimaTotal;
                    ftvvm.Endoso = ftVehiculo.Endoso;
                    ftvvm.Vigencia = ftVehiculo.Vigencia;
                    ftvvm.sVigencia = string.Format("{0:d}", ftVehiculo.Vigencia);
                    ftvvm.TarjetaCirculacion = ftVehiculo.TarjetaCirculacion;
                }
             
            }

            var outJson = new
            {
                success = "yes",
                data = ftvvm != null ? ftvvm : null
            };

            return Json(outJson, JsonRequestBehavior.AllowGet);
        }

        [SessionAuthorize]
        [HttpGet]
        public JsonResult FichaTecnicaUsuario(string id)
        {
            long iUsuarioId = 0;
            long.TryParse(id, out iUsuarioId);

            SCV_FichaTecnicaUsuario ftUsuario = new SCV_FichaTecnicaUsuario();
            SCV_Usuario usuario = new SCV_Usuario();
            SCV_Ciudad ciudad = new SCV_Ciudad();
            SCV_Documento foto = new SCV_Documento();
            SCV_TipoDocumento tipodoc = new SCV_TipoDocumento();
            FichaTecnicaUsuarioViewModel ftuvm = new FichaTecnicaUsuarioViewModel();

            if (!string.IsNullOrEmpty(id))
            {
                ftUsuario = FichaTecnicaDB.ObtieneFichaTecnicaUsuario(iUsuarioId);

                if (ftUsuario != null)
                {
                    ftuvm.NumColaborador = ftUsuario.NumColaborador;
                    ftuvm.sFechaIngreso = string.Format("{0:d}", ftUsuario.FechaIngreso);
                    ftuvm.Imss = ftUsuario.Imss;
                    ftuvm.Licencia = ftUsuario.Licencia;
                    ftuvm.Ine = ftUsuario.Ine;
                    ftuvm.Departamento = ftUsuario.Departamento;
                    ftuvm.NumCelular = ftUsuario.NumCelular;
                    ftuvm.Email = ftUsuario.Email;

                    usuario = UsuarioDB.ObtieneUsuariosByUsuarioIdDB(iUsuarioId);
                    ciudad = CiudadDB.ObtieneCiudadeByIdDB(ftUsuario.CuidadId);
                    tipodoc = TipoDocumentoDB.ObtieneTipoDocumentosDB().Where(t => t.Descripcion == "Foto de Usuario").FirstOrDefault();
                    foto = DocumentoDB.ObtieneDocumentosByFichaTecnicaUsuarioId(ftUsuario.FichaTecnicaUsuarioId).Where(f => f.TipoDocumentoId == tipodoc.TipoDocumentoId).FirstOrDefault();

                    
                    if (foto != null)
                    {
                        string[] strURL = foto.URL.Split('\\');
                        if (strURL.Count() > 0)
                        {
                            ftuvm.FotoUrl = "/Content/usr-profile-pics/" + strURL[strURL.Length - 1].ToString();
                        }
                    }


                    if (ciudad != null)
                    {
                        ftuvm.Ciudad = ciudad.Descripcion;
                    }

                    if (usuario != null)
                    {
                        ftuvm.Nombre = usuario.Nombre + " " + usuario.ApPaterno + " " + usuario.ApMaterno;
                    }
                }

            }

            var outJson = new
            {
                success = "yes",
                data = ftuvm != null ? ftuvm : null
            };

            return Json(outJson, JsonRequestBehavior.AllowGet);
        }

        [SessionAuthorize]
        public ActionResult VehiculosFiltros(string vehiculoId, string serie, string placa)
        {
            SessionUserViewModel suvm = new SessionUserViewModel();
            if (Session["_UserLogged"] != null)
            {
                suvm = (SessionUserViewModel)Session["_UserLogged"];
            }

            int iVehiculoId = 0;
            int.TryParse(vehiculoId, out iVehiculoId);

            //List<EmpresaViewModel> empresaList = new List<EmpresaViewModel>();
            List<SCV_Empresa> empList = EmpresaDB.ObtieneEmpresasDB();

            if (!suvm.IsHerrMty)
            {
                empList.Remove(empList.FirstOrDefault(e => e.EmpresaId == 1));
            }

            if (!suvm.IsMetalinspec)
            {
                empList.Remove(empList.FirstOrDefault(e => e.EmpresaId == 2));
            }

            if (!suvm.IsMetalinspecLab)
            {
                empList.Remove(empList.FirstOrDefault(e => e.EmpresaId == 3));
            }

            if (!suvm.IsMetroLab)
            {
                empList.Remove(empList.FirstOrDefault(e => e.EmpresaId == 4));
            }

            vvm = new VehiculoViewModel
            {
                Ciudades = VehiculosList.GetCiudades(),
                Empresas = VehiculosList.GetEmpresas(),
                Usuarios = VehiculosList.GetUsuarios(),
                Vehiculos = VehiculosList.GetVehiculosByEmpresasAndFiltros(empList, iVehiculoId, serie, placa),
                Cuentas = VehiculosList.GetCuentas(),
                TiposDocumentos = VehiculosList.GetTiposDocumentos(),
                UsuarioActivo = suvm
            };

            

            return View("Vehiculos", vvm);// Json(outJson, JsonRequestBehavior.AllowGet);
        }

        
        

        [SessionAuthorize]
        [ValidateInput(false)]
        public ActionResult GridViewVehiculosFiltrados()
        {
            SessionUserViewModel suvm = new SessionUserViewModel();
            int empresaId = 0;
            if (Session["_UserLogged"] != null)
            {
                suvm = (SessionUserViewModel)Session["_UserLogged"];
                empresaId = suvm.EmpresaId;
                
            }

            //List<EmpresaViewModel> empresaList = new List<EmpresaViewModel>();
            List<SCV_Empresa> empList = EmpresaDB.ObtieneEmpresasDB();

            if (!suvm.IsHerrMty)
            {
                empList.Remove(empList.FirstOrDefault(e => e.EmpresaId == 1));
            }

            if (!suvm.IsMetalinspec)
            {
                empList.Remove(empList.FirstOrDefault(e => e.EmpresaId == 2));
            }

            if (!suvm.IsMetalinspecLab)
            {
                empList.Remove(empList.FirstOrDefault(e => e.EmpresaId == 3));
            }

            if (!suvm.IsMetroLab)
            {
                empList.Remove(empList.FirstOrDefault(e => e.EmpresaId == 4));
            }

            vvm = new VehiculoViewModel
            {
                Ciudades = VehiculosList.GetCiudades(),
                Empresas = VehiculosList.GetEmpresas(),
                Usuarios = VehiculosList.GetUsuarios(),
                Vehiculos = VehiculosList.GetVehiculosByEmpresas(empList, empresaId),
                Cuentas = VehiculosList.GetCuentas(),
                TiposDocumentos = VehiculosList.GetTiposDocumentos(),
                UsuarioActivo = suvm
            };

            // DXCOMMENT: Pass a data model for GridView in the PartialView method's second parameter
            return PartialView("GridViewVehiculosFiltrados", vvm);
        }

        [SessionAuthorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult AgregaVehiculo(SCV_Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isSave = VehiculoDB.InsertaVehiculo(vehiculo);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            vvm = new VehiculoViewModel
            {
                Empresas = VehiculosList.GetEmpresas(),
                Usuarios = VehiculosList.GetUsuarios(),
                Vehiculos = VehiculosList.GetVehiculos(),
                TiposDocumentos = VehiculosList.GetTiposDocumentos()
            };
            return PartialView("GridViewPartialView", vvm);
        }

        [SessionAuthorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult ActualizaVehiculo(SCV_Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isSave = VehiculoDB.ActualizaVehiculo(vehiculo);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            vvm = new VehiculoViewModel
            {
                Ciudades = VehiculosList.GetCiudades(),
                Empresas = VehiculosList.GetEmpresas(),
                Usuarios = VehiculosList.GetUsuarios(),
                Vehiculos = VehiculosList.GetVehiculos(),
                TiposDocumentos = VehiculosList.GetTiposDocumentos()
            };
            return PartialView("GridViewPartialView", vvm);
        }

        [SessionAuthorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult EliminaVehiculo(int vehiculoId)
        {
            if (vehiculoId >= 0)
            {
                try
                {
                    bool isSave = AccountDB.EliminaCuenta(vehiculoId);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }

            vvm = new VehiculoViewModel
            {
                Ciudades = VehiculosList.GetCiudades(),
                Empresas = VehiculosList.GetEmpresas(),
                Usuarios = VehiculosList.GetUsuarios(),
                Vehiculos = VehiculosList.GetVehiculos(),
                TiposDocumentos = VehiculosList.GetTiposDocumentos()
            };
            return PartialView("GridViewPartialView", vvm);
        }

        #region "Upload Documents"

        [SessionAuthorize]
        [ValidateInput(false)]
        public PartialViewResult LoadDocumentsPartialView(string _vehiculoID)
        {
            // DXCOMMENT: Pass a data model for GridView in the PartialView method's second parameter
            return PartialView("LoadDocumentsPartialView");
        }

        [SessionAuthorize]
        [ValidateInput(false)]
        public PartialViewResult FichaTecnicaVehiculoPartialView(string _vehiculoID)
        {
            // DXCOMMENT: Pass a data model for GridView in the PartialView method's second parameter
            return PartialView("FichaTecnicaVehiculoPartialView");
        }

        [SessionAuthorize]
        [ValidateInput(false)]
        public PartialViewResult DocumentosPartialView(string _vehiculoID)
        {
            // DXCOMMENT: Pass a data model for GridView in the PartialView method's second parameter
            return PartialView("DocumentosPartialView");
        }

        [SessionAuthorize]
        [ValidateInput(false)]
        public PartialViewResult FichaTecnicaUsuarioPartialView(string _usuarioIdAsignado)
        {
            // DXCOMMENT: Pass a data model for GridView in the PartialView method's second parameter
            return PartialView("FichaTecnicaUsuarioPartialView");
        }

        [SessionAuthorize]
        public ActionResult UploadControlCallbackAction()
        {
            //Save information of the file into the database

            UploadControlExtension.GetUploadedFiles("uc", UCHelper.ValidationSettings, UCHelper.uc_FileUploadComplete);
            return null;
        }

        [SessionAuthorize]
        [HttpGet]
        public JsonResult AddInfoFile(string id, string url, string tipodoc)
        {
            try
            {
                long vehId = 0;
                long.TryParse(id, out vehId);

                string[] strURL = url.Split('/');
                string sFileName = string.Empty;

                int tipodocu = 0;
                int.TryParse(tipodoc, out tipodocu);

                if (strURL.Count() > 0)
                {
                    sFileName = strURL[4].ToString();
                }

                SessionUserViewModel uvm = (SessionUserViewModel)Session["_UserLogged"];

                //Generar registro en la tabla de documentos
                SCV_Documento newDocument = new SCV_Documento
                {
                    URL = url,
                    FileName = sFileName,
                    VehiculoId = vehId,
                    FechaAlta = DateTime.Now,
                    UsuarioIdAlta = uvm.CuentaId,
                    TipoDocumentoId = tipodocu
                };
                DocumentoDB.InsertaDocumento(newDocument);

                //Obtener la lista de documentos relacionados al vehiculo seleccionado
                List<SCV_Documento> docList = new List<SCV_Documento>();
                docList = DocumentoDB.ObtieneDocumentosByVehiculoId(vehId);

                //Hacer otro metodo para consultar todos los documentos que se hayan cargado para cierto vehiculo
                var outJson = new
                {
                    success = "yes",
                    data = docList != null ? docList : null,
                    modulo = 1 //"Vehiculo"
                };

                return Json(outJson, JsonRequestBehavior.AllowGet);
            }

            catch (Exception ex)
            {
                var outJsonErr = new
                {
                    success = "no",
                    data = new List<SCV_Documento>()
                };
                return Json(outJsonErr, JsonRequestBehavior.AllowGet);
            }

        }

        [SessionAuthorize]
        [HttpGet]
        public JsonResult GetFiles(string id)
        {
            try
            {
                long vehId = 0;
                long.TryParse(id, out vehId);

                //Obtener la lista de documentos relacionados a la revision seleccionada
                List<SCV_Documento> docList = new List<SCV_Documento>();
                docList = DocumentoDB.ObtieneDocumentosByVehiculoId(vehId);

                //Hacer otro metodo para consultar todos los documentos que se hayan cargado para cierta revision
                var outJson = new
                {
                    success = "yes",
                    data = docList != null ? docList : null
                };

                return Json(outJson, JsonRequestBehavior.AllowGet);
            }

            catch (Exception ex)
            {
                var outJsonErr = new
                {
                    success = "no",
                    errmsg = ex.Message.ToString(),
                    data = new List<SCV_Documento>()
                };
                return Json(outJsonErr, JsonRequestBehavior.AllowGet);
            }

        }


        [SessionAuthorize]
        [HttpGet, FileDownload]
        public FilePathResult DownloadFile(int id)
        {
            List<SCV_Documento> docList = new List<SCV_Documento>();
            docList = DocumentoDB.ObtieneDocumentosByDocumentoId(id);

            if (docList.Count > 0)
            {
                string fullpath = docList.FirstOrDefault().URL;
                string filename = docList.FirstOrDefault().FileName;
                string[] extension = filename.Split('.');
                string ext = extension[1].ToString();
                string contentType = string.Empty;

                switch (ext)
                {
                    case "pdf":
                        contentType = "application/pdf";
                        break;
                    case "jpeg":
                        contentType = "image/jpeg";
                        break;
                    case "jpg":
                        contentType = "image/jpg";
                        break;
                    case "png":
                        contentType = "image/png";
                        break;
                    case "doc":
                        contentType = "application/msword";
                        break;
                    case "docx":
                        contentType = "application/msword";
                        break;
                    case "xls":
                        contentType = "application/vnd.ms-excel";
                        break;
                    case "xlsx":
                        contentType = "application/vnd.ms-excel";
                        break;
                    case "ppt":
                        contentType = "application/vnd.ms-powerpoint";
                        break;
                    case "pptx":
                        contentType = "application/vnd.ms-powerpoint";
                        break;
                    case "txt":
                        contentType = "text/plain";
                        break;
                }

                return File(fullpath, contentType, filename);
            }

            return null;
        }

        [SessionAuthorize]
        [HttpGet]
        public JsonResult DeleteFile(string docId, string id)
        {
            try
            {
                long vehId = 0;
                long.TryParse(id, out vehId);

                long docuId = 0;
                long.TryParse(docId, out docuId);

                //Elimina el documento seleccionado
                DocumentoDB.EliminaDocumento(docuId);

                //Obtener la lista de documentos relacionados a la revision seleccionada
                List<SCV_Documento> docList = new List<SCV_Documento>();
                docList = DocumentoDB.ObtieneDocumentosByVehiculoId(vehId);

                //Hacer otro metodo para consultar todos los documentos que se hayan cargado para cierta revision
                var outJson = new
                {
                    success = "yes",
                    data = docList != null ? docList : null,
                    modulo = 1 //Vehiculo
                };

                return Json(outJson, JsonRequestBehavior.AllowGet);
            }

            catch (Exception ex)
            {
                var outJsonErr = new
                {
                    success = "no",
                    errmsg = ex.Message.ToString(),
                    data = new List<SCV_Documento>()
                };
                return Json(outJsonErr, JsonRequestBehavior.AllowGet);
            }

        }

        #endregion

    }
}
