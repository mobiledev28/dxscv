using DevExpress.Web;
using DevExpress.Web.Mvc;
using DevExpress.XtraRichEdit;
using DXSCV.Common;
using DXSCV.Helpers;
using DXSCV.Models;
using SCVData;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace DXSCV.Controllers
{
    public class MantenimientoController : Controller
    {
        private SCV_Mantenimiento Mantenimiento = new SCV_Mantenimiento();

        MantenimientoViewModel vvm = new MantenimientoViewModel
        {
            Mantenimientos = new List<SCV_Mantenimiento>(),
            Usuarios = MantenimientoList.GetUsuarios(),
            Vehiculos = MantenimientoList.GetVehiculos(),
            Ciudades = MantenimientoList.GetCiudades(),
            Cuentas = MantenimientoList.GetCuentas(),
            Proveedores = MantenimientoList.GetProveedores(),
            Empresas = MantenimientoList.GetEmpresas(),
            TiposDocumentos = MantenimientoList.GetTiposDocumentos()
        };

        private void GetMantenimientos()
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

            vvm.Mantenimientos = MantenimientoList.GetMantenimientosByEmpresa(empList, empresaId);
        }

        [SessionAuthorize]
        public ActionResult Index()
        {
            this.GetMantenimientos();
            return View(vvm);
        }

        [SessionAuthorize]
        [ValidateInput(false)]
        public ActionResult GridViewPartialView()
        {
            // DXCOMMENT: Pass a data model for GridView in the PartialView method's second parameter
            this.GetMantenimientos();
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
        public ActionResult AgregaMantenimiento(SCV_Mantenimiento Mantenimiento)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isSave = MantenimientoDB.InsertaMantenimiento(Mantenimiento);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            //vvm = new MantenimientoViewModel
            //{
            //    Mantenimientos = MantenimientoList.GetMantenimientos(),
            //    Usuarios = MantenimientoList.GetUsuarios(),
            //    Vehiculos = MantenimientoList.GetVehiculos(),
            //    Ciudades = MantenimientoList.GetCiudades(),
            //    Cuentas = MantenimientoList.GetCuentas(),
            //    Proveedores = MantenimientoList.GetProveedores(),
            //    Empresas = MantenimientoList.GetEmpresas(),
            //    TiposDocumentos = MantenimientoList.GetTiposDocumentos()
            //};

            this.GetMantenimientos();

            return PartialView("GridViewPartialView", vvm);
        }

        [SessionAuthorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult ActualizaMantenimiento(SCV_Mantenimiento Mantenimiento)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isSave = MantenimientoDB.ActualizaMantenimiento(Mantenimiento);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            //vvm = new MantenimientoViewModel
            //{
            //    Mantenimientos = MantenimientoList.GetMantenimientos(),
            //    Usuarios = MantenimientoList.GetUsuarios(),
            //    Vehiculos = MantenimientoList.GetVehiculos(),
            //    Ciudades = MantenimientoList.GetCiudades(),
            //    Cuentas = MantenimientoList.GetCuentas(),
            //    Proveedores = MantenimientoList.GetProveedores(),
            //    Empresas = MantenimientoList.GetEmpresas(),
            //    TiposDocumentos = MantenimientoList.GetTiposDocumentos()
            //};
            this.GetMantenimientos();
            return PartialView("GridViewPartialView", vvm);
        }

        [SessionAuthorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult EliminaMantenimiento(int MantenimientoId)
        {
            if (MantenimientoId >= 0)
            {
                try
                {
                    bool isSave = AccountDB.EliminaCuenta(MantenimientoId);
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }

            //vvm = new MantenimientoViewModel
            //{
            //    Mantenimientos = MantenimientoList.GetMantenimientos(),
            //    Usuarios = MantenimientoList.GetUsuarios(),
            //    Vehiculos = MantenimientoList.GetVehiculos(),
            //    Ciudades = MantenimientoList.GetCiudades(),
            //    Cuentas = MantenimientoList.GetCuentas(),
            //    Proveedores = MantenimientoList.GetProveedores(),
            //    Empresas = MantenimientoList.GetEmpresas(),
            //    TiposDocumentos = MantenimientoList.GetTiposDocumentos()
            //};
            this.GetMantenimientos();
            return PartialView("GridViewPartialView", vvm);
        }

        #region "Upload Documents"

        [SessionAuthorize]
        [ValidateInput(false)]
        public PartialViewResult LoadDocumentsPartialView(string _MantenimientoID)
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
                long mttoId = 0;
                long.TryParse(id, out mttoId);

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
                    MantenimientoId = mttoId,
                    FechaAlta = DateTime.Now,
                    UsuarioIdAlta = uvm.CuentaId,
                    TipoDocumentoId = tipodocu
                };
                DocumentoDB.InsertaDocumento(newDocument);

                //Obtener la lista de documentos relacionados al Mantenimiento seleccionado
                List<SCV_Documento> docList = new List<SCV_Documento>();
                docList = DocumentoDB.ObtieneDocumentosByMantenimientoId(mttoId);

                //Hacer otro metodo para consultar todos los documentos que se hayan cargado para cierto Mantenimiento
                var outJson = new
                {
                    success = "yes",
                    data = docList != null ? docList : null,
                    modulo = 5 //"Mantenimiento"
                };

                return Json(outJson, JsonRequestBehavior.AllowGet);
            }

            catch (Exception ex)
            {
                var outJsonErr = new
                {
                    success = "no",
                    data = new List<SCV_Documento>(),
                    modulo = 5 //"Mantenimiento"
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
                long mttoId = 0;
                long.TryParse(id, out mttoId);

                //Obtener la lista de documentos relacionados a la revision seleccionada
                List<SCV_Documento> docList = new List<SCV_Documento>();
                docList = DocumentoDB.ObtieneDocumentosByMantenimientoId(mttoId);

                //Hacer otro metodo para consultar todos los documentos que se hayan cargado para cierta revision
                var outJson = new
                {
                    success = "yes",
                    data = docList != null ? docList : null,
                    modulo = 5 //"Mantenimiento"
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
                long mttoId = 0;
                long.TryParse(id, out mttoId);

                long docuId = 0;
                long.TryParse(docId, out docuId);

                //Elimina el documento seleccionado
                DocumentoDB.EliminaDocumento(docuId);

                //Obtener la lista de documentos relacionados a la revision seleccionada
                List<SCV_Documento> docList = new List<SCV_Documento>();
                docList = DocumentoDB.ObtieneDocumentosByMantenimientoId(mttoId);

                //Hacer otro metodo para consultar todos los documentos que se hayan cargado para cierta revision
                var outJson = new
                {
                    success = "yes",
                    data = docList != null ? docList : null,
                    modulo = 5 //Mantenimiento
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
                    modulo = 5 //Mantenimiento

                };
                return Json(outJsonErr, JsonRequestBehavior.AllowGet);
            }

        }

        [SessionAuthorize]
        [HttpGet]
        public JsonResult PrintPDF(string id)
        {
            try
            {
                RichEditDocumentServer server = new RichEditDocumentServer();
                var inputHtml = "<html><body>Hi Hello</body></html>";

                server.HtmlText = inputHtml;
                server.Options.Export.Html.EmbedImages = true;
                MemoryStream ms = new MemoryStream();
                server.ExportToPdf(ms);

                HttpContext.Response.Buffer = true;
                HttpContext.Response.Clear();
                HttpContext.Response.ContentType = "pdf document/pdf";
                HttpContext.Response.AddHeader("Accept-Header", ms.Length.ToString());
                HttpContext.Response.AddHeader("Content-Disposition", ("Attachment") + "; filename=resultDocument.pdf");
                HttpContext.Response.AddHeader("Content-Length", ms.Length.ToString());
                HttpContext.Response.BinaryWrite(ms.ToArray());
                HttpContext.Response.End();

                //Hacer otro metodo para consultar todos los documentos que se hayan cargado para cierto Mantenimiento
                var outJson = new
                {
                    success = "yes",
                    data = "yes",
                    modulo = 5 //"Mantenimiento"
                };

                return Json(outJson, JsonRequestBehavior.AllowGet);
            }

            catch (Exception ex)
            {
                var outJsonErr = new
                {
                    success = "no",
                    data = new List<SCV_Documento>(),
                    modulo = 5 //"Mantenimiento"
                };
                return Json(outJsonErr, JsonRequestBehavior.AllowGet);
            }

            
        }


        [SessionAuthorize]
        public ActionResult ExportPDF(string id)
        {
            try
            {
                //string mttoId = "1";
                long lmttoId = 0;
                long.TryParse(id, out lmttoId);

                //Buscar la información del matenimiento que desean exportar y/o imprimir.
                ObjectResult<SCV_SP_Obtiene_Orden_Mtto_Result> resultData = MantenimientoDB.GetInfoOrdenMtto(lmttoId);
                OrdenMttoViewModel omvm = new OrdenMttoViewModel();
                List<OrdenMttoViewModel> ordMttoList = new List<OrdenMttoViewModel>();

                foreach (SCV_SP_Obtiene_Orden_Mtto_Result res in resultData.ToList())
                {
                    omvm = new OrdenMttoViewModel
                    {
                        MttoId = res.MantenimientoId,
                        Empresa = res.Empresa,
                        Usuario = res.Usuario,
                        SucAsignada = res.SucAsignada,
                        Motivo = res.Motivo,
                        FechaIngreso = res.FechaIngresoaServicio != null ? string.Format("{0:d}",res.FechaIngresoaServicio) : "",
                        FechaPromesa = res.FechaPromesaEntrega != null ? string.Format("{0:d}",res.FechaPromesaEntrega) : "",
                        FechaTerminada = res.FechaRealEntrega != null ? string.Format("{0:d}",res.FechaRealEntrega) : "",
                        Proveedor = res.Proveedor,
                        DescMtto = res.DescripcionMtto,
                        Placa = res.Placa,
                        Serie = res.NoSerie,
                        Kms = 0,
                        Marca = res.Marca,
                        Linea = res.Linea,
                        Modelo = res.Modelo,
                        Factura = res.NumFactura,
                        SubTotal = "0",
                        IVA = "0",
                        Total = "0"
                    };
                    ordMttoList.Add(omvm);
                }

                RichEditDocumentServer server = new RichEditDocumentServer();
                StringBuilder sb = new StringBuilder();
                sb.Append("<html><body>");
                sb.Append("<table with='100%'>");
                
                //string urlImg = UrlHelper.GenerateContentUrl(@"C:\Users\Home\Documents\Visual Studio 2013\Projects\SCVSolution\DXSCV\Content\Images\", HttpContext);
                string urlImg = System.Configuration.ConfigurationManager.AppSettings["RptImgPath"]; //UrlHelper.GenerateContentUrl(@"C:\Users\Home\Documents\Visual Studio 2013\Projects\SCVSolution\DXSCV\Content\Images\", HttpContext);

                sb.Append("<tr>");
                //sb.Append("<td style='text-align:left;'><img style='width:175px;height:75px;' src='" + urlImg + @"\HM.png'/></td>");
                sb.Append("<td style='text-align:left;'><img style='width:200px;height:75px;' src='" + urlImg + @"\ML.png'/></td>");
                sb.Append("<td style='text-align:left;'><img style='width:200px;height:75px;' src='" + urlImg + @"\MTI.png'/></td>");
                sb.Append("<td style='text-align:left;'><img style='width:200px;height:75px;' src='" + urlImg + @"\MTL.png'/></td>");
                sb.Append("</tr>");

                //Blank row
                sb.Append("<tr>");
                sb.Append("<td colspan='3' align='center' style='height:25px;min-height:25px;'><span style='color:transparent;'>white-row</span></td>");
                sb.Append("</tr>");

                //Report Title
                sb.Append("<tr>");
                sb.Append("<td colspan='3' align='center'><h1 style='font-family:Arial;'>Orden de Mantenimiento</h1></td>");
                sb.Append("</tr>");

                //Blank row
                sb.Append("<tr>");
                sb.Append("<td colspan='3' align='center' style='height:25px;min-height:25px;'><span style='color:transparent;'>white-row</span></td>");
                sb.Append("</tr>");

                //Report Date
                DateTime dt = DateTime.Now;
                string sformatedDate = String.Format("{0:D}", dt);

                sb.Append("<tr>");
                sb.Append("<td colspan='3' align='right'><span style='font-family:Arial;font-size:12px;'>" + sformatedDate + "</span></td>");
                sb.Append("</tr>");

                //Blank row
                sb.Append("<tr>");
                sb.Append("<td colspan='3' align='center' style='height:25px;min-height:25px;'><span style='color:transparent;'>white-row</span></td>");
                sb.Append("</tr>");

                //Facturar A (Empresa)
                string empresa = ordMttoList.FirstOrDefault().Empresa;
                sb.Append("<tr>");
                sb.Append("<td colspan='3' align='left'><span style='font-family:Arial;font-size:12px;font-weight:Bold;'>Facturar a:</span><span style='font-family:Arial;font-size:12px;'>" + empresa + "</span></td>");
                //sb.Append("<td colspan='2' align='left'>" + empresa + "</td>");
                sb.Append("</tr>");

                //Blank row
                sb.Append("<tr>");
                sb.Append("<td colspan='3' align='center' style='height:25px;min-height:25px;'><span style='color:transparent;'>white-row</span></td>");
                sb.Append("</tr>");

                //MttoId / Sucursal Asignada (Ciudad) / Usuario
                //-string mttoId = string.Empty;
                string sucursal = ordMttoList.FirstOrDefault().SucAsignada;
                string usuario = ordMttoList.FirstOrDefault().Usuario;
                string styleBoldSpan = String.Empty; // "<span style='font-family:Arial;font-size:12px;font-weight:Bold'>{0}</span>";
                string styleSpan = string.Empty;

                sb.Append("<tr>");
                styleBoldSpan = "<span style='font-family:Arial;font-size:12px;font-weight:Bold'>{0}</span>";
                styleBoldSpan = string.Format(styleBoldSpan, "IdOR Mtto");
                sb.Append("<td align='left'>" + styleBoldSpan + "</td>");

                styleBoldSpan = "<span style='font-family:Arial;font-size:12px;font-weight:Bold'>{0}</span>";
                styleBoldSpan = string.Format(styleBoldSpan, "Sucursal Asignada");
                sb.Append("<td align='left'>" + styleBoldSpan + "</td>");

                styleBoldSpan = "<span style='font-family:Arial;font-size:12px;font-weight:Bold'>{0}</span>";
                styleBoldSpan = string.Format(styleBoldSpan, "Usuario");
                sb.Append("<td align='left'>" + styleBoldSpan  + "</td>");
                sb.Append("</tr>");

                sb.Append("<tr>");
                styleSpan = "<span style='font-family:Arial;font-size:12px;'>{0}</span>";
                styleSpan = string.Format(styleSpan, id);
                sb.Append("<td align='left'>" + styleSpan + "</td>");

                styleSpan = "<span style='font-family:Arial;font-size:12px;'>{0}</span>";
                styleSpan = string.Format(styleSpan, sucursal);
                sb.Append("<td align='left'>" + styleSpan + "</td>");

                styleSpan = "<span style='font-family:Arial;font-size:12px;'>{0}</span>";
                styleSpan = string.Format(styleSpan, usuario);
                sb.Append("<td align='left'>" + styleSpan + "</td>");
                sb.Append("</tr>");

                //Blank row
                sb.Append("<tr>");
                sb.Append("<td colspan='3' align='center' style='height:25px;min-height:25px;'><span style='color:transparent;'>white-row</span></td>");
                sb.Append("</tr>");

                //Proveedor
                string proveedor = ordMttoList.FirstOrDefault().Proveedor;
                sb.Append("<tr>");
                styleBoldSpan = "<span style='font-family:Arial;font-size:12px;font-weight:Bold'>{0}</span>";
                styleBoldSpan = string.Format(styleBoldSpan, "Proveedor");
                sb.Append("<td colspan='3' align='center'>" + styleBoldSpan + "</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                styleSpan = "<span style='font-family:Arial;font-size:12px;'>{0}</span>";
                styleSpan = string.Format(styleSpan, proveedor);
                sb.Append("<td colspan='3' align='center'>" + styleSpan + "</td>");
                sb.Append("</tr>");

                //Blank row
                sb.Append("<tr>");
                sb.Append("<td colspan='3' align='center' style='height:25px;min-height:25px;'><span style='color:transparent;'>white-row</span></td>");
                sb.Append("</tr>");


                //Descripcion de Mantenimiento
                string descMtto = ordMttoList.FirstOrDefault().DescMtto;
                sb.Append("<tr>");
                styleBoldSpan = "<span style='font-family:Arial;font-size:12px;font-weight:Bold'>{0}</span>";
                styleBoldSpan = string.Format(styleBoldSpan, "Descripción de Mantenimiento / Comentarios Adicionales");
                sb.Append("<td colspan='3' align='center'>" + styleBoldSpan + "</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                styleSpan = "<span style='font-family:Arial;font-size:12px;'>{0}</span>";
                styleSpan = string.Format(styleSpan, descMtto);
                sb.Append("<td colspan='3' align='center'>" + styleSpan + "</td>");
                sb.Append("</tr>");

                //Blank row
                sb.Append("<tr>");
                sb.Append("<td colspan='3' align='center' style='height:25px;min-height:25px;'><span style='color:transparent;'>white-row</span></td>");
                sb.Append("</tr>");

                //Datos del Vehiculo
                sb.Append("<tr>");
                sb.Append("<td colspan='3' align='center'></td>");
                sb.Append("<table width='100%'>");
                sb.Append("<tr>");
                styleBoldSpan = "<span style='font-family:Arial;font-size:12px;font-weight:Bold'>{0}</span>";
                styleBoldSpan = string.Format(styleBoldSpan, "Placa");
                sb.Append("<td>" + styleBoldSpan + "</td>");
                styleBoldSpan = "<span style='font-family:Arial;font-size:12px;font-weight:Bold'>{0}</span>";
                styleBoldSpan = string.Format(styleBoldSpan, "Serie");
                sb.Append("<td>" + styleBoldSpan + "</td>");
                styleBoldSpan = "<span style='font-family:Arial;font-size:12px;font-weight:Bold'>{0}</span>";
                styleBoldSpan = string.Format(styleBoldSpan, "KMS");
                sb.Append("<td>" + styleBoldSpan + "</td>");
                styleBoldSpan = "<span style='font-family:Arial;font-size:12px;font-weight:Bold'>{0}</span>";
                styleBoldSpan = string.Format(styleBoldSpan, "Marca");
                sb.Append("<td>" + styleBoldSpan + "</td>");
                styleBoldSpan = "<span style='font-family:Arial;font-size:12px;font-weight:Bold'>{0}</span>";
                styleBoldSpan = string.Format(styleBoldSpan, "Linea");
                sb.Append("<td>" + styleBoldSpan + "</td>");
                styleBoldSpan = "<span style='font-family:Arial;font-size:12px;font-weight:Bold'>{0}</span>";
                styleBoldSpan = string.Format(styleBoldSpan, "Modelo");
                sb.Append("<td>" + styleBoldSpan + "</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                styleSpan = "<span style='font-family:Arial;font-size:12px;'>{0}</span>";
                styleSpan = string.Format(styleSpan, ordMttoList.FirstOrDefault().Placa);
                sb.Append("<td>" + styleSpan + "</td>");
                styleSpan = "<span style='font-family:Arial;font-size:12px;'>{0}</span>";
                styleSpan = string.Format(styleSpan, ordMttoList.FirstOrDefault().Serie);
                sb.Append("<td>" + styleSpan + "</td>");
                styleSpan = "<span style='font-family:Arial;font-size:12px;'>{0}</span>";
                styleSpan = string.Format(styleSpan, ordMttoList.FirstOrDefault().Kms.ToString());
                sb.Append("<td>" + styleSpan + "</td>");
                styleSpan = "<span style='font-family:Arial;font-size:12px;'>{0}</span>";
                styleSpan = string.Format(styleSpan, ordMttoList.FirstOrDefault().Marca);
                sb.Append("<td>" + styleSpan + "</td>");
                styleSpan = "<span style='font-family:Arial;font-size:12px;'>{0}</span>";
                styleSpan = string.Format(styleSpan, ordMttoList.FirstOrDefault().Linea);
                sb.Append("<td>" + styleSpan + "</td>");
                styleSpan = "<span style='font-family:Arial;font-size:12px;'>{0}</span>";
                styleSpan = string.Format(styleSpan, ordMttoList.FirstOrDefault().Modelo);
                sb.Append("<td>" + styleSpan + "</td>");
                sb.Append("</table>");
                sb.Append("</td>");
                sb.Append("</tr>");

                //Blank row
                sb.Append("<tr>");
                sb.Append("<td colspan='3' align='center' style='height:25px;min-height:25px;'><span style='color:transparent;'>white-row</span></td>");
                sb.Append("</tr>");

                //Datos Factura
                sb.Append("<tr>");
                sb.Append("<td colspan='3' align='center'></td>");
                sb.Append("<table width='100%'>");
                sb.Append("<tr>");
                styleBoldSpan = "<span style='font-family:Arial;font-size:12px;font-weight:Bold'>{0}</span>";
                styleBoldSpan = string.Format(styleBoldSpan, "Factura");
                sb.Append("<td>" + styleBoldSpan + "</td>");
                sb.Append("<td></td>");
                styleBoldSpan = "<span style='font-family:Arial;font-size:12px;font-weight:Bold'>{0}</span>";
                styleBoldSpan = string.Format(styleBoldSpan, "Subtotal");
                sb.Append("<td>" + styleBoldSpan + "</td>");
                sb.Append("<td></td>");
                styleBoldSpan = "<span style='font-family:Arial;font-size:12px;font-weight:Bold'>{0}</span>";
                styleBoldSpan = string.Format(styleBoldSpan, "IVA");
                sb.Append("<td>" + styleBoldSpan + "</td>");
                sb.Append("<td></td>");
                styleBoldSpan = "<span style='font-family:Arial;font-size:12px;font-weight:Bold'>{0}</span>";
                styleBoldSpan = string.Format(styleBoldSpan, "Total");
                sb.Append("<td>" + styleBoldSpan + "</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                styleSpan = "<span style='font-family:Arial;font-size:12px;'>{0}</span>";
                styleSpan = string.Format(styleSpan, ordMttoList.FirstOrDefault().Factura);
                sb.Append("<td>" + styleSpan + "</td>");
                sb.Append("<td></td>");
                styleSpan = "<span style='font-family:Arial;font-size:12px;'>{0}</span>";
                styleSpan = string.Format(styleSpan, ordMttoList.FirstOrDefault().SubTotal);
                sb.Append("<td>" + styleSpan + "</td>");
                sb.Append("<td></td>");
                styleSpan = "<span style='font-family:Arial;font-size:12px;'>{0}</span>";
                styleSpan = string.Format(styleSpan, ordMttoList.FirstOrDefault().IVA);
                sb.Append("<td>" + styleSpan + "</td>");
                sb.Append("<td></td>");
                styleSpan = "<span style='font-family:Arial;font-size:12px;'>{0}</span>";
                styleSpan = string.Format(styleSpan, ordMttoList.FirstOrDefault().Total);
                sb.Append("<td>" + styleSpan + "</td>");
                sb.Append("</table>");
                sb.Append("</td>");
                sb.Append("</tr>");

                sb.Append("</table>");
                sb.Append("</body></html>");

                //var inputHtml = "<html><body>Hi Hello</body></html>";

                server.HtmlText = sb.ToString();
                server.Options.Export.Html.EmbedImages = true;
                MemoryStream ms = new MemoryStream();
                server.ExportToPdf(ms);
                //server.LoadDocument(ms, DocumentFormat.pdf)

                string sfileName = string.Format("OrdenMantenimiento_{0}", DateTime.Now.ToString("yyyyMMddHHmmss"));
                HttpContext.Response.Buffer = true;
                HttpContext.Response.ClearContent();
                HttpContext.Response.Clear();
                //HttpContext.Response.ContentType = "pdf document/pdf";
                HttpContext.Response.ContentType = "application/pdf";
                HttpContext.Response.AddHeader("Accept-Header", ms.Length.ToString());
                HttpContext.Response.AddHeader("Content-Disposition", "attachment; filename=" + sfileName + ".pdf");
                HttpContext.Response.AddHeader("Content-Length", ms.Length.ToString());
                ms.WriteTo(HttpContext.Response.OutputStream);
                HttpContext.Response.Flush();
                HttpContext.Response.BinaryWrite(ms.ToArray());

                //HttpContext.Response.End();

               
            }

            catch (Exception ex)
            {
                
            }

            return null;

        }

        public ActionResult OrdMtto()
        {
            return View(new OrdenMtto());
        }

        #endregion


        OrdenMtto report = new OrdenMtto();

        public ActionResult DocumentViewerPartial()
        {
            return PartialView("_DocumentViewerPartial", report);
        }

        public ActionResult DocumentViewerPartialExport()
        {
            return DocumentViewerExtension.ExportTo(report, Request);
        }
    }
}
