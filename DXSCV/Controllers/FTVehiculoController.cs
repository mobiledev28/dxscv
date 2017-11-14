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
    public class FTVehiculoController : Controller
    {
        //
        // GET: /FichaTecnica/

        

        [SessionAuthorize]
        public ActionResult Index()
        {
            SessionUserViewModel suvm = new SessionUserViewModel();
            if (Session["_UserLogged"] != null)
            {
                suvm = (SessionUserViewModel)Session["_UserLogged"];
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

            FichaTecnicaVehiculoViewModel ftvvm = new FichaTecnicaVehiculoViewModel
            {
                Vehiculos = FichaTecnicaVehiculoViewModel.GetVehiculosByEmpresa(empList),
                FichasTecnicasVehiculos = FichaTecnicaVehiculoViewModel.GetFTVehiculos(),
                Proveedores = FichaTecnicaVehiculoViewModel.GetProveedores(),
                TiposDocumentos = FichaTecnicaVehiculoViewModel.GetTiposDocumentos()
            };

            return View(ftvvm);
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

            FichaTecnicaVehiculoViewModel ftvvm = new FichaTecnicaVehiculoViewModel
            {
                Vehiculos = FichaTecnicaVehiculoViewModel.GetVehiculosByEmpresa(empList),
                FichasTecnicasVehiculos = FichaTecnicaVehiculoViewModel.GetFTVehiculos(),
                Proveedores = FichaTecnicaVehiculoViewModel.GetProveedores(),
                TiposDocumentos = FichaTecnicaVehiculoViewModel.GetTiposDocumentos()
            };
            // DXCOMMENT: Pass a data model for GridView in the PartialView method's second parameter
            return PartialView("GridViewPartialView", ftvvm);
        }




        [SessionAuthorize]
        public ActionResult CambiaVistaModoEdicion(GridViewEditingMode editMode)
        {
            GridViewEditHelper.EditMode = editMode;
            return PartialView("GridViewPartialView", FichaTecnicaDB.ListaFTVehiculosDB());
        }

        [SessionAuthorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult AgregaFTVehiculo(SCV_FichaTecnicaVehiculo FTVehiculo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isSave = FichaTecnicaDB.InsertaFTVehiculo(FTVehiculo);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            //Keep filtered vehicles data
            SessionUserViewModel suvm = new SessionUserViewModel();
            if (Session["_UserLogged"] != null)
            {
                suvm = (SessionUserViewModel)Session["_UserLogged"];
            }

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

            FichaTecnicaVehiculoViewModel ftvvm = new FichaTecnicaVehiculoViewModel
            {
                Vehiculos = FichaTecnicaVehiculoViewModel.GetVehiculosByEmpresa(empList),
                FichasTecnicasVehiculos = FichaTecnicaVehiculoViewModel.GetFTVehiculos(),
                Proveedores = FichaTecnicaVehiculoViewModel.GetProveedores()
            };
           
            return PartialView("GridViewPartialView", ftvvm);
        }

        [SessionAuthorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult ActualizaFTVehiculo(SCV_FichaTecnicaVehiculo FTVehiculo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isSave = FichaTecnicaDB.ActualizaFTVehiculo(FTVehiculo);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            //Keep filtered vehicles data
            SessionUserViewModel suvm = new SessionUserViewModel();
            if (Session["_UserLogged"] != null)
            {
                suvm = (SessionUserViewModel)Session["_UserLogged"];
            }

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

            FichaTecnicaVehiculoViewModel ftvvm = new FichaTecnicaVehiculoViewModel
            {
                Vehiculos = FichaTecnicaVehiculoViewModel.GetVehiculosByEmpresa(empList),
                FichasTecnicasVehiculos = FichaTecnicaVehiculoViewModel.GetFTVehiculos(),
                Proveedores = FichaTecnicaVehiculoViewModel.GetProveedores(),
                TiposDocumentos = FichaTecnicaVehiculoViewModel.GetTiposDocumentos()
            };

            return PartialView("GridViewPartialView", ftvvm);
        }

        [SessionAuthorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult EliminaFTVehiculo(int FichaTecnicaVehiculoId)
        {
            if (FichaTecnicaVehiculoId >= 0)
            {
                try
                {
                    bool isSave = FichaTecnicaDB.EliminaFTVehiculo(FichaTecnicaVehiculoId);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }

            //Keep filtered vehicles data
            SessionUserViewModel suvm = new SessionUserViewModel();
            if (Session["_UserLogged"] != null)
            {
                suvm = (SessionUserViewModel)Session["_UserLogged"];
            }

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

            FichaTecnicaVehiculoViewModel ftvvm = new FichaTecnicaVehiculoViewModel
            {
                Vehiculos = FichaTecnicaVehiculoViewModel.GetVehiculosByEmpresa(empList),
                FichasTecnicasVehiculos = FichaTecnicaVehiculoViewModel.GetFTVehiculos(),
                Proveedores = FichaTecnicaVehiculoViewModel.GetProveedores(),
                TiposDocumentos = FichaTecnicaVehiculoViewModel.GetTiposDocumentos()
            };

            return PartialView("GridViewPartialView", ftvvm);
        }

        [SessionAuthorize]
        [HttpGet]
        public JsonResult GetFiles(string id, string tipo)
        {
            try
            {
                long ftvehId = 0;
                long.TryParse(id, out ftvehId);

                //Obtener la lista de documentos relacionados a la revision seleccionada
                List<SCV_Documento> docList = new List<SCV_Documento>();

                switch (tipo){
                    case "vehiculo":
                        ////busca ficha tecnica vehiculo id primero despues busca los documentos
                        int vehId = 0;
                        int.TryParse(id, out vehId);
                        long newftvehId = FichaTecnicaDB.ObtieneFichaTecnicaVehiculo(vehId).FichaTecnicaVehiculoId;
                        docList = DocumentoDB.ObtieneDocumentosByFichaTecnicaVehiculoId(newftvehId);
                        break;
                    case "fichatecnica":
                        //busca los documentos
                        docList = DocumentoDB.ObtieneDocumentosByFichaTecnicaVehiculoId(ftvehId);
                        break;
                }

                
                

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
        [ValidateInput(false)]
        public PartialViewResult LoadDocumentsPartialView(string _ftvehiculoID)
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
                int ftvehId = 0;
                int.TryParse(id, out ftvehId);

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
                    FichaTecnicaVehiculoId = ftvehId,
                    FechaAlta = DateTime.Now,
                    UsuarioIdAlta = uvm.CuentaId,
                    TipoDocumentoId = tipodocu
                };
                DocumentoDB.InsertaDocumento(newDocument);

                //Obtener la lista de documentos relacionados al vehiculo seleccionado
                List<SCV_Documento> docList = new List<SCV_Documento>();
                docList = DocumentoDB.ObtieneDocumentosByFichaTecnicaVehiculoId(ftvehId);

                //Hacer otro metodo para consultar todos los documentos que se hayan cargado para cierto vehiculo
                var outJson = new
                {
                    success = "yes",
                    data = docList != null ? docList : null,
                    modulo = 7 //"Ficha Tecnica Vehiculo"
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
                long ftvehId = 0;
                long.TryParse(id, out ftvehId);

                long docuId = 0;
                long.TryParse(docId, out docuId);

                //Elimina el documento seleccionado
                DocumentoDB.EliminaDocumento(docuId);

                //Obtener la lista de documentos relacionados a la revision seleccionada
                List<SCV_Documento> docList = new List<SCV_Documento>();
                docList = DocumentoDB.ObtieneDocumentosByFichaTecnicaVehiculoId(ftvehId);

                //Hacer otro metodo para consultar todos los documentos que se hayan cargado para cierta revision
                var outJson = new
                {
                    success = "yes",
                    data = docList != null ? docList : null,
                    modulo = 7 //Ficha Tecnica Vehiculo
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

        public ActionResult FichaVehiculo()
        {
            return View();
        }

        public ActionResult FichaUsuario()
        {
            return View();
        }

    }
}
