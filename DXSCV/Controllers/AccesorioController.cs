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
    public class AccesorioController : Controller
    {
        AccesorioViewModel tdvm = new AccesorioViewModel
        {
            Accesorios = AccesorioViewModel.GetAccesorios(),
            Cuentas = AccesorioViewModel.GetCuentas(),
            TiposDocumentos = AccesorioViewModel.GetTiposDocumentos()
        };

        [SessionAuthorize]
        public ActionResult Index()
        {
            return View(tdvm);
        }

        [SessionAuthorize]
        [ValidateInput(false)]
        public ActionResult GridViewPartialView()
        {
            // DXCOMMENT: Pass a data model for GridView in the PartialView method's second parameter
            return PartialView("GridViewPartialView", tdvm);
        }




        [SessionAuthorize]
        public ActionResult CambiaVistaModoEdicion(GridViewEditingMode editMode)
        {
            GridViewEditHelper.EditMode = editMode;
            return PartialView("GridViewPartialView", AccesorioDB.ObtieneAccesoriosDB());
        }

        [SessionAuthorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult AgregaAccesorio(SCV_Accesorio Accesorio)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isSave = AccesorioDB.InsertaAccesorio(Accesorio);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            tdvm = new AccesorioViewModel
            {
                Accesorios = AccesorioViewModel.GetAccesorios(),
                Cuentas = AccesorioViewModel.GetCuentas(),
                TiposDocumentos = AccesorioViewModel.GetTiposDocumentos()

            };
            return PartialView("GridViewPartialView", tdvm);
        }

        [SessionAuthorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult ActualizaAccesorio(SCV_Accesorio Accesorio)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isSave = AccesorioDB.ActualizaAccesorio(Accesorio);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            tdvm = new AccesorioViewModel
            {
                Accesorios = AccesorioViewModel.GetAccesorios(),
                Cuentas = AccesorioViewModel.GetCuentas(),
                TiposDocumentos = AccesorioViewModel.GetTiposDocumentos()

            };
            return PartialView("GridViewPartialView", tdvm);
        }

        [SessionAuthorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult EliminaAccesorio(int AccesorioId)
        {
            if (AccesorioId >= 0)
            {
                try
                {
                    bool isSave = AccesorioDB.EliminaAccesorio(AccesorioId);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }

            tdvm = new AccesorioViewModel
            {
                Accesorios = AccesorioViewModel.GetAccesorios(),
                Cuentas = AccesorioViewModel.GetCuentas(),
                TiposDocumentos = AccesorioViewModel.GetTiposDocumentos()

            };

            return PartialView("GridViewPartialView", tdvm);
        }

        #region "Upload Documents"

        [SessionAuthorize]
        [ValidateInput(false)]
        public PartialViewResult LoadDocumentsPartialView(string _accesorioID)
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
                long accId = 0;
                long.TryParse(id, out accId);

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
                    AccesorioId = accId,
                    FechaAlta = DateTime.Now,
                    UsuarioIdAlta = uvm.CuentaId,
                    TipoDocumentoId = tipodocu
                };
                DocumentoDB.InsertaDocumento(newDocument);

                //Obtener la lista de documentos relacionados al vehiculo seleccionado
                List<SCV_Documento> docList = new List<SCV_Documento>();
                docList = DocumentoDB.ObtieneDocumentosByAccesorioId(accId);

                //Hacer otro metodo para consultar todos los documentos que se hayan cargado para cierto vehiculo
                var outJson = new
                {
                    success = "yes",
                    data = docList != null ? docList : null,
                    modulo = 4 //"Accesorio"
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
                long accId = 0;
                long.TryParse(id, out accId);

                //Obtener la lista de documentos relacionados a la revision seleccionada
                List<SCV_Documento> docList = new List<SCV_Documento>();
                docList = DocumentoDB.ObtieneDocumentosByAccesorioId(accId);

                //Hacer otro metodo para consultar todos los documentos que se hayan cargado para cierta revision
                var outJson = new
                {
                    success = "yes",
                    data = docList != null ? docList : null,
                    modulo = 4 //Accesorio
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
        [HttpGet]
        public JsonResult DeleteFile(string docId, string id)
        {
            try
            {
                long accId = 0;
                long.TryParse(id, out accId);

                long docuId = 0;
                long.TryParse(docId, out docuId);

                //Elimina el documento seleccionado
                DocumentoDB.EliminaDocumento(docuId);

                //Obtener la lista de documentos relacionados a la revision seleccionada
                List<SCV_Documento> docList = new List<SCV_Documento>();
                docList = DocumentoDB.ObtieneDocumentosByAccesorioId(accId);

                //Hacer otro metodo para consultar todos los documentos que se hayan cargado para cierta revision
                var outJson = new
                {
                    success = "yes",
                    data = docList != null ? docList : null,
                    modulo = 4 //Accesorio
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
                    modulo = 4 //Accesorio
                };
                return Json(outJsonErr, JsonRequestBehavior.AllowGet);
            }

        }

        #endregion
    }
}
