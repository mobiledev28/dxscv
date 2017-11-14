using DevExpress.Web;
using DevExpress.Web.Mvc;
using DXSCV.Common;
using DXSCV.Helpers;
using DXSCV.Models;
using SCVData;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace DXSCV.Controllers
{
    public class RevisionController : Controller
    {
        #region "Init"
        private SCV_Revision revision = new SCV_Revision();

        RevisionViewModel rvm = new RevisionViewModel
        {
            Revisiones = RevisionesList.GetRevisiones(),
            Cuentas = RevisionesList.GetCuentas(),
            Usuarios = RevisionesList.GetUsuarios(),
            Vehiculos = RevisionesList.GetVehiculos(),
            TiposDocumentos = RevisionesList.GetTiposDocumentos()
        };


        [SessionAuthorize]
        public ActionResult Index()
        {
            return View(rvm);
        }
        #endregion

        #region "Insert / Update / Delete"
        [SessionAuthorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult AgregaRevision(SCV_Revision revision)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isSave = RevisionDB.InsertaRevision(revision);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            rvm = new RevisionViewModel
            {
                Revisiones = RevisionesList.GetRevisiones(),
                Cuentas = RevisionesList.GetCuentas(),
                Usuarios = RevisionesList.GetUsuarios(),
                Vehiculos = RevisionesList.GetVehiculos()
            };
            return PartialView("GridViewPartialView", rvm);
        }

        [SessionAuthorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult ActualizaRevision(SCV_Revision revision)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isSave = RevisionDB.ActualizaRevision(revision);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            rvm = new RevisionViewModel
            {
                Revisiones = RevisionesList.GetRevisiones(),
                Cuentas = RevisionesList.GetCuentas(),
                Usuarios = RevisionesList.GetUsuarios(),
                Vehiculos = RevisionesList.GetVehiculos()
            };
            return PartialView("GridViewPartialView", rvm);
        }

        [SessionAuthorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult EliminaRevision(long RevisionId)
        {
            if (RevisionId >= 0)
            {
                try
                {
                    bool isSave = RevisionDB.EliminaRevision(RevisionId);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }

            rvm = new RevisionViewModel
            {
                Revisiones = RevisionesList.GetRevisiones(),
                Cuentas = RevisionesList.GetCuentas(),
                Usuarios = RevisionesList.GetUsuarios(),
                Vehiculos = RevisionesList.GetVehiculos()
            };
            return PartialView("GridViewPartialView", rvm);
        }


        #endregion

        #region "Grid"
        [SessionAuthorize]
        [ValidateInput(false)]
        public ActionResult GridViewPartialView()
        {
            // DXCOMMENT: Pass a data model for GridView in the PartialView method's second parameter
            return PartialView("GridViewPartialView", rvm);
        }
        #endregion

        #region "Upload Documents"

        [SessionAuthorize]
        [ValidateInput(false)]
        public PartialViewResult LoadDocumentsPartialView(string _revisionID)
        {
            // DXCOMMENT: Pass a data model for GridView in the PartialView method's second parameter
            return PartialView("LoadDocumentsPartialView");
        }

        [SessionAuthorize]
        public ActionResult CambiaVistaModoEdicion(GridViewEditingMode editMode)
        {
            GridViewEditHelper.EditMode = editMode;
            return PartialView("GridViewPartialView", rvm);
        }

        [SessionAuthorize]
        public ActionResult UploadControlCallbackAction(){
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
                long revId = 0;
                long.TryParse(id, out revId); 

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
                SCV_Documento newDocument = new SCV_Documento { 
                    URL = url,
                    FileName = sFileName,
                    RevisionId = revId,
                    FechaAlta = DateTime.Now,
                    UsuarioIdAlta = uvm.CuentaId,
                    TipoDocumentoId = tipodocu
                };
                DocumentoDB.InsertaDocumento(newDocument);

                //Obtener la lista de documentos relacionados a la revision seleccionada
                List<SCV_Documento> docList = new List<SCV_Documento>();
                docList = DocumentoDB.ObtieneDocumentosByRevisionId(revId);

                //Hacer otro metodo para consultar todos los documentos que se hayan cargado para cierta revision
                var outJson = new
                {
                    success = "yes",
                    data = docList != null ? docList : null,
                    modulo = 0
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
                long revId = 0;
                long.TryParse(id, out revId);

                //Obtener la lista de documentos relacionados a la revision seleccionada
                List<SCV_Documento> docList = new List<SCV_Documento>();
                docList = DocumentoDB.ObtieneDocumentosByRevisionId(revId);

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
                    data = new List<SCV_Documento>(),
                    modulo = 0
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
                string ext = extension[1].ToString().ToLower();
                string contentType = string.Empty;

                switch (ext) {
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
                long revId = 0;
                long.TryParse(id, out revId);

                long docuId = 0;
                long.TryParse(docId, out docuId);

                //Elimina el documento seleccionado
                DocumentoDB.EliminaDocumento(docuId);

                //Obtener la lista de documentos relacionados a la revision seleccionada
                List<SCV_Documento> docList = new List<SCV_Documento>();
                docList = DocumentoDB.ObtieneDocumentosByRevisionId(revId);

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
                    data = new List<SCV_Documento>(),
                    modulo = 0
                };
                return Json(outJsonErr, JsonRequestBehavior.AllowGet);
            }

        }

        #endregion


    }
    
}
