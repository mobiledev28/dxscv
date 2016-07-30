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
            Vehiculos = VehiculosList.GetVehiculos(),
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
            if (!string.IsNullOrEmpty(Filterby))
            {
                int empresaId = 0;
                switch (Filterby)
                {
                    case "1":
                        empresaId = 1; //Herramental Monterrey
                        break;
                    case "2":
                        empresaId = 2; //Metalisnpec
                        break;
                    case "3":
                        empresaId = 3; //Metalisnpec Laboratorios
                        break;
                    case "4":
                        empresaId = 4; //MetroLab
                        break;
                }

                vvm = new VehiculoViewModel
                {
                    Ciudades = VehiculosList.GetCiudades(),
                    Empresas = VehiculosList.GetEmpresas(),
                    Usuarios = VehiculosList.GetUsuarios(),
                    Vehiculos = VehiculosList.GetVehiculosByEmpresa(empresaId),
                    Cuentas = VehiculosList.GetCuentas(),
                    TiposDocumentos = VehiculosList.GetTiposDocumentos()
                };
            }
            

            return View(vvm);
        }

        [SessionAuthorize]
        [ValidateInput(false)]
        public ActionResult GridViewPartialView()
        {
            // DXCOMMENT: Pass a data model for GridView in the PartialView method's second parameter
            return PartialView("GridViewPartialView", vvm);
        }

        [SessionAuthorize]
        public ActionResult CambiaVistaModoEdicion(GridViewEditingMode editMode)
        {
            GridViewEditHelper.EditMode = editMode;
            return PartialView("GridViewPartialView", vvm);
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
