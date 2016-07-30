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
    public class EventoController : Controller
    {
        private SCV_BitacoraEvento evento = new SCV_BitacoraEvento();

        BitacoraEventoViewModel bevm = new BitacoraEventoViewModel
        {
            TiposEventos = BitacoraEventosList.GetTiposEventos(),
            Vehiculos = BitacoraEventosList.GetVehiculos(),
            Cuentas = BitacoraEventosList.GetCuentas(),
            Eventos = BitacoraEventosList.GetEventos(),
            TiposDocumentos = BitacoraEventosList.GetTiposDocumentos(),
            Proveedores = BitacoraEventosList.GetProveedores()
        };

        [SessionAuthorize]
        public ActionResult Index()
        {
            return View(bevm);
        }

        #region "ABC Eventos"
        
        [SessionAuthorize]
        [ValidateInput(false)]
        public ActionResult GridViewPartialView()
        {
            // DXCOMMENT: Pass a data model for GridView in the PartialView method's second parameter
            return PartialView("GridViewPartialView", bevm);
        }

        [SessionAuthorize]
        public ActionResult CambiaVistaModoEdicion(GridViewEditingMode editMode)
        {
            GridViewEditHelper.EditMode = editMode;
            return PartialView("GridViewPartialView", bevm);
        }

        [SessionAuthorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult Agregaevento(SCV_BitacoraEvento evento)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isSave = BitacoraEventoDB.InsertaEvento(evento);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            bevm = new BitacoraEventoViewModel
            {
                TiposEventos = BitacoraEventosList.GetTiposEventos(),
                Vehiculos = BitacoraEventosList.GetVehiculos(),
                Cuentas = BitacoraEventosList.GetCuentas(),
                Eventos = BitacoraEventosList.GetEventos(),
                TiposDocumentos = BitacoraEventosList.GetTiposDocumentos(),
                Proveedores = BitacoraEventosList.GetProveedores()

            };
            return PartialView("GridViewPartialView", bevm);
        }

        [SessionAuthorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult Actualizaevento(SCV_BitacoraEvento evento)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isSave = BitacoraEventoDB.ActualizaEvento(evento);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            bevm = new BitacoraEventoViewModel
            {
                TiposEventos = BitacoraEventosList.GetTiposEventos(),
                Vehiculos = BitacoraEventosList.GetVehiculos(),
                Cuentas = BitacoraEventosList.GetCuentas(),
                Eventos = BitacoraEventosList.GetEventos(),
                TiposDocumentos = BitacoraEventosList.GetTiposDocumentos(),
                Proveedores = BitacoraEventosList.GetProveedores()
            };
            return PartialView("GridViewPartialView", bevm);
        }

        [SessionAuthorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult Eliminaevento(long BitacoraEventoId)
        {
            if (BitacoraEventoId >= 0)
            {
                try
                {
                    bool isSave = BitacoraEventoDB.EliminaEvento(BitacoraEventoId);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }

            bevm = new BitacoraEventoViewModel
            {
                TiposEventos = BitacoraEventosList.GetTiposEventos(),
                Vehiculos = BitacoraEventosList.GetVehiculos(),
                Cuentas = BitacoraEventosList.GetCuentas(),
                Eventos = BitacoraEventosList.GetEventos(),
                TiposDocumentos = BitacoraEventosList.GetTiposDocumentos(),
                Proveedores = BitacoraEventosList.GetProveedores()
            };
            return PartialView("GridViewPartialView", bevm);
        }
        #endregion

        #region "Upload Documents"

        [SessionAuthorize]
        [ValidateInput(false)]
        public PartialViewResult LoadDocumentsPartialView(string _usuarioID)
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
                long evtId = 0;
                long.TryParse(id, out evtId);

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
                    BitacoraEventoId = evtId,
                    FechaAlta = DateTime.Now,
                    UsuarioIdAlta = uvm.CuentaId,
                    TipoDocumentoId = tipodocu
                };
                DocumentoDB.InsertaDocumento(newDocument);

                //Obtener la lista de documentos relacionados al vehiculo seleccionado
                List<SCV_Documento> docList = new List<SCV_Documento>();
                docList = DocumentoDB.ObtieneDocumentosByEventoId(evtId);

                //Hacer otro metodo para consultar todos los documentos que se hayan cargado para cierto vehiculo
                var outJson = new
                {
                    success = "yes",
                    data = docList != null ? docList : null,
                    modulo = 3 //"Evento"
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
                long usrId = 0;
                long.TryParse(id, out usrId);

                //Obtener la lista de documentos relacionados a la revision seleccionada
                List<SCV_Documento> docList = new List<SCV_Documento>();
                docList = DocumentoDB.ObtieneDocumentosByEventoId(usrId);

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
        [HttpGet]
        public JsonResult DeleteFile(string docId, string id)
        {
            try
            {
                long evtId = 0;
                long.TryParse(id, out evtId);

                long docuId = 0;
                long.TryParse(docId, out docuId);

                //Elimina el documento seleccionado
                DocumentoDB.EliminaDocumento(docuId);

                //Obtener la lista de documentos relacionados a la revision seleccionada
                List<SCV_Documento> docList = new List<SCV_Documento>();
                docList = DocumentoDB.ObtieneDocumentosByEventoId(evtId);

                //Hacer otro metodo para consultar todos los documentos que se hayan cargado para cierta revision
                var outJson = new
                {
                    success = "yes",
                    data = docList != null ? docList : null,
                    modulo = 3
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
