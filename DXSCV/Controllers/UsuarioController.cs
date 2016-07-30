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
    public class UsuarioController : Controller
    {
        #region "Usuarios Catalogo"
        private SCV_Usuario scvusuario = new SCV_Usuario();

        UsuarioViewModel uvm = new UsuarioViewModel
        {
            Sucursales = UsuariosList.GetEmpresas(),
            Usuarios = UsuariosList.GetUsuarios(),
            Cuentas = UsuariosList.GetCuentas(),
            TiposDocumentos = UsuariosList.GetTiposDocumentos()

        };

        [SessionAuthorize]
        public ActionResult Index()
        {
            return View(uvm);
        }

        [SessionAuthorize]
        [ValidateInput(false)]
        public ActionResult GridViewPartialView()
        {
            // DXCOMMENT: Pass a data model for GridView in the PartialView method's second parameter
            return PartialView("GridViewPartialView", uvm);
        }

        [SessionAuthorize]
        public ActionResult CambiaVistaModoEdicion(GridViewEditingMode editMode)
        {
            GridViewEditHelper.EditMode = editMode;
            return PartialView("GridViewPartialView", uvm);
        }

        [SessionAuthorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult AgregaUsuario(SCV_Usuario usr)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isSave = UsuarioDB.InsertaUsuario(usr);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            uvm = new UsuarioViewModel
            {
                Sucursales = UsuariosList.GetEmpresas(),
                Usuarios = UsuariosList.GetUsuarios(),
                TiposDocumentos = UsuariosList.GetTiposDocumentos()

            };
            
            return PartialView("GridViewPartialView", uvm);
        }

        [SessionAuthorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult ActualizaUsuario(SCV_Usuario usr)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isSave = UsuarioDB.ActualizaUsuario(usr);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            uvm = new UsuarioViewModel
            {
                Sucursales = UsuariosList.GetEmpresas(),
                Usuarios = UsuariosList.GetUsuarios(),
                TiposDocumentos = UsuariosList.GetTiposDocumentos()
            };
            return PartialView("GridViewPartialView", uvm);
        }

        [SessionAuthorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult EliminaUsuario(int usuarioId)
        {
            if (usuarioId >= 0)
            {
                try
                {
                    bool isSave = UsuarioDB.EliminaUsuario(usuarioId);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }

            uvm = new UsuarioViewModel
            {
                Sucursales = UsuariosList.GetEmpresas(),
                Usuarios = UsuariosList.GetUsuarios(),
                TiposDocumentos = UsuariosList.GetTiposDocumentos()
            };
            return PartialView("GridViewPartialView", uvm);
        }
        #endregion

        #region "Upload Documents"


        [ValidateInput(false)]
        public PartialViewResult LoadDocumentsPartialView(string _usuarioID)
        {
            // DXCOMMENT: Pass a data model for GridView in the PartialView method's second parameter
            return PartialView("LoadDocumentsPartialView");
        }

        public ActionResult UploadControlCallbackAction()
        {
            //Save information of the file into the database

            UploadControlExtension.GetUploadedFiles("uc", UCHelper.ValidationSettings, UCHelper.uc_FileUploadComplete);
            return null;
        }

        [HttpGet]
        public JsonResult AddInfoFile(string id, string url, string tipodoc)
        {
            try
            {
                long usrId = 0;
                long.TryParse(id, out usrId);

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
                    UsuarioId  = usrId,
                    FechaAlta = DateTime.Now,
                    UsuarioIdAlta = uvm.CuentaId,
                    TipoDocumentoId = tipodocu
                };
                DocumentoDB.InsertaDocumento(newDocument);

                //Obtener la lista de documentos relacionados al vehiculo seleccionado
                List<SCV_Documento> docList = new List<SCV_Documento>();
                docList = DocumentoDB.ObtieneDocumentosByUsuarioId(usrId);

                //Hacer otro metodo para consultar todos los documentos que se hayan cargado para cierto vehiculo
                var outJson = new
                {
                    success = "yes",
                    data = docList != null ? docList : null,
                    modulo = 2 //"Usuario"
                };

                return Json(outJson, JsonRequestBehavior.AllowGet);
            }

            catch (Exception ex)
            {
                var outJsonErr = new
                {
                    success = "no",
                    data = new List<SCV_Documento>(),
                    modulo = 2, //Usuario
                    error = ex.Message.ToString()
                };
                return Json(outJsonErr, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpGet]
        public JsonResult GetFiles(string id)
        {
            try
            {
                long usrId = 0;
                long.TryParse(id, out usrId);

                //Obtener la lista de documentos relacionados a la revision seleccionada
                List<SCV_Documento> docList = new List<SCV_Documento>();
                docList = DocumentoDB.ObtieneDocumentosByUsuarioId(usrId);

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



       

        [HttpGet]
        public JsonResult DeleteFile(string docId, string id)
        {
            try
            {
                long usrId = 0;
                long.TryParse(id, out usrId);

                long docuId = 0;
                long.TryParse(docId, out docuId);

                //Elimina el documento seleccionado
                DocumentoDB.EliminaDocumento(docuId);

                //Obtener la lista de documentos relacionados a la revision seleccionada
                List<SCV_Documento> docList = new List<SCV_Documento>();
                docList = DocumentoDB.ObtieneDocumentosByUsuarioId(usrId);

                //Hacer otro metodo para consultar todos los documentos que se hayan cargado para cierta revision
                var outJson = new
                {
                    success = "yes",
                    data = docList != null ? docList : null,
                    modulo = 2
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
