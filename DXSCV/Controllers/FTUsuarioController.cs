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
    public class FTUsuarioController : Controller
    {
        //
        // GET: /FTUsuario/

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

            FichaTecnicaUsuarioViewModel ftuvm = new FichaTecnicaUsuarioViewModel
            {
                Usuarios = FichaTecnicaUsuarioViewModel.GetUsuariosByEmpresas(empList),
                FichasTecnicasUsuarios = FichaTecnicaUsuarioViewModel.GetFTUsuarios(),
                Ciudades = FichaTecnicaUsuarioViewModel.GetCiudades(),
                TiposDocumentos = FichaTecnicaUsuarioViewModel.GetTiposDocumentos()
            };

            return View(ftuvm);
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

            FichaTecnicaUsuarioViewModel ftuvm = new FichaTecnicaUsuarioViewModel
            {
                Usuarios = FichaTecnicaUsuarioViewModel.GetUsuariosByEmpresas(empList),
                FichasTecnicasUsuarios = FichaTecnicaUsuarioViewModel.GetFTUsuarios(),
                Ciudades = FichaTecnicaUsuarioViewModel.GetCiudades(),
                TiposDocumentos = FichaTecnicaUsuarioViewModel.GetTiposDocumentos()
            };
            // DXCOMMENT: Pass a data model for GridView in the PartialView method's second parameter
            return PartialView("GridViewPartialView", ftuvm);
        }




        [SessionAuthorize]
        public ActionResult CambiaVistaModoEdicion(GridViewEditingMode editMode)
        {
            GridViewEditHelper.EditMode = editMode;
            return PartialView("GridViewPartialView", FichaTecnicaDB.ListaFTUsuariosDB());
        }

        [SessionAuthorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult AgregaFTUsuario(SCV_FichaTecnicaUsuario FTUsuario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isSave = FichaTecnicaDB.InsertaFTUsuario(FTUsuario);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";


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

            FichaTecnicaUsuarioViewModel ftuvm = new FichaTecnicaUsuarioViewModel
            {
                Usuarios = FichaTecnicaUsuarioViewModel.GetUsuariosByEmpresas(empList),
                FichasTecnicasUsuarios = FichaTecnicaUsuarioViewModel.GetFTUsuarios(),
                Ciudades = FichaTecnicaUsuarioViewModel.GetCiudades()
            };

            return PartialView("GridViewPartialView", ftuvm);
        }

        [SessionAuthorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult ActualizaFTUsuario(SCV_FichaTecnicaUsuario FTUsuario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isSave = FichaTecnicaDB.ActualizaFTUsuario(FTUsuario);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

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

            FichaTecnicaUsuarioViewModel ftuvm = new FichaTecnicaUsuarioViewModel
            {
                Usuarios = FichaTecnicaUsuarioViewModel.GetUsuariosByEmpresas(empList),
                FichasTecnicasUsuarios = FichaTecnicaUsuarioViewModel.GetFTUsuarios(),
                Ciudades = FichaTecnicaUsuarioViewModel.GetCiudades()
            };

            return PartialView("GridViewPartialView", ftuvm);
        }

        [SessionAuthorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult EliminaFTUsuario(int FichaTecnicaUsuarioId)
        {
            if (FichaTecnicaUsuarioId >= 0)
            {
                try
                {
                    bool isSave = FichaTecnicaDB.EliminaFTUsuario(FichaTecnicaUsuarioId);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }

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

            FichaTecnicaUsuarioViewModel ftuvm = new FichaTecnicaUsuarioViewModel
            {
                Usuarios = FichaTecnicaUsuarioViewModel.GetUsuariosByEmpresas(empList),
                FichasTecnicasUsuarios = FichaTecnicaUsuarioViewModel.GetFTUsuarios(),
                Ciudades = FichaTecnicaUsuarioViewModel.GetCiudades()
            };

            return PartialView("GridViewPartialView", ftuvm);
        }

        [SessionAuthorize]
        [HttpGet]
        public JsonResult GetFiles(string id)
        {
            try
            {
                long ftusrId = 0;
                long.TryParse(id, out ftusrId);

                //Obtener la lista de documentos relacionados a la revision seleccionada
                List<SCV_Documento> docList = new List<SCV_Documento>();
                docList = DocumentoDB.ObtieneDocumentosByFichaTecnicaUsuarioId(ftusrId);

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
        public PartialViewResult LoadDocumentsPartialView(string _FTUsuarioID)
        {
            // DXCOMMENT: Pass a data model for GridView in the PartialView method's second parameter
            return PartialView("LoadDocumentsPartialView");
        }


        [SessionAuthorize]
        public ActionResult UploadControlCallbackAction()
        {
            //Save information of the file into the database
            UploadControlExtension.GetUploadedFiles("uc", UCHelper.ValidationSettings, UCHelper.uc_UserPictureUploadComplete);

            //int tipodocu = 0;
            //int.TryParse(tipodoc, out tipodocu);
            ////Obtener el tipo de documento para saber si se cargo la "Foto de Usuario"
            //SCV_TipoDocumento td = new SCV_TipoDocumento();
            //td = TipoDocumentoDB.ObtieneTipoDocumentosDB().Where(t => t.TipoDocumentoId == tipodocu && t.Descripcion == "Foto de Usuario").FirstOrDefault();
            
            //Si el tipo de documento es "Foto de Usuario", entonces, guardaremos el archivo el archivo en una variable de sesion para 
            //validar donde se guardara el archivo fisicamente.
            //if (td != null)
            //{
            //    //Save information of the file into the database
            //    UploadControlExtension.GetUploadedFiles("uc", UCHelper.ValidationSettings, UCHelper.uc_UserPictureUploadComplete);
            //}
            //else
            //{
            //    //Save information of the file into the database
            //    UploadControlExtension.GetUploadedFiles("uc", UCHelper.ValidationSettings, UCHelper.uc_FileUploadComplete);
            //}

            return null;
        }

        [SessionAuthorize]
        [HttpGet]
        public JsonResult AddInfoFile(string id, string url, string tipodoc)
        {
            try
            {
                int ftusrId = 0;
                int.TryParse(id, out ftusrId);

                string[] strURL = url.Split('\\');
                string sFileName = string.Empty;

                int tipodocu = 0;
                int.TryParse(tipodoc, out tipodocu);

                if (strURL.Count() > 0)
                {
                    sFileName = strURL[strURL.Length - 1].ToString();
                }

                SessionUserViewModel uvm = (SessionUserViewModel)Session["_UserLogged"];

                //Generar registro en la tabla de documentos
                SCV_Documento newDocument = new SCV_Documento
                {
                    URL = url,
                    FileName = sFileName,
                    FichaTecnicaUsuarioId = ftusrId,
                    FechaAlta = DateTime.Now,
                    UsuarioIdAlta = uvm.CuentaId,
                    TipoDocumentoId = tipodocu
                };
                DocumentoDB.InsertaDocumento(newDocument);

                //Obtener la lista de documentos relacionados al vehiculo seleccionado
                List<SCV_Documento> docList = new List<SCV_Documento>();
                docList = DocumentoDB.ObtieneDocumentosByFichaTecnicaUsuarioId(ftusrId);

                
                


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
                long ftusrId = 0;
                long.TryParse(id, out ftusrId);

                long docuId = 0;
                long.TryParse(docId, out docuId);

                //Elimina el documento seleccionado
                DocumentoDB.EliminaDocumento(docuId);

                //Obtener la lista de documentos relacionados a la revision seleccionada
                List<SCV_Documento> docList = new List<SCV_Documento>();
                docList = DocumentoDB.ObtieneDocumentosByFichaTecnicaUsuarioId(ftusrId);

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

    }
}
