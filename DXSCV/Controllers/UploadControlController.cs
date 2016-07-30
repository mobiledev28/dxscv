using DevExpress.Web;
using DevExpress.Web.Mvc;
using DXSCV.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DXSCV.Controllers
{
    public class UploadControlController : Controller
    {
        //public override string Name { get { return "UploadControl"; } }
        
        public ActionResult Index() {
            return MultiFileSelection();
        }

        public ActionResult UploadedFilesContainer(bool useExtendedPopup) {
            ViewData["UseExtendedPopup"] = useExtendedPopup;
            return PartialView("UploadedFilesContainer");
        }

        public ActionResult MultiFileSelection() {
            return View("MultiFileSelection");
        }
        public ActionResult MultiSelectionImageUpload(IEnumerable<UploadedFile> ucMultiSelection) {
            return null;
        }

        protected override void Execute(System.Web.Routing.RequestContext requestContext) {

            var binder = (DevExpressEditorsBinder)ModelBinders.Binders.DefaultBinder;
            binder.UploadControlBinderSettings.ValidationSettings.Assign(UploadControlHelper.UploadValidationSettings);
            var actionName = (string)requestContext.RouteData.Values["Action"];
            switch(actionName) {
                //case "DragAndDropImageUpload":
                //    binder.UploadControlBinderSettings.FileUploadCompleteHandler = UploadControlHelper.ucDragAndDrop_FileUploadComplete;
                //    break;
                case "MultiSelectionImageUpload": 
                    binder.UploadControlBinderSettings.FileUploadCompleteHandler = UploadControlHelper.ucMultiSelection_FileUploadComplete;
                    break;
                //case "AzureUpload":
                //    binder.UploadControlBinderSettings.UploadStorage = UploadControlUploadStorage.Azure;
                //    binder.UploadControlBinderSettings.AzureSettings.Assign(UploadControlDemosHelper.CreateUploadControlAzureSettings());
                //    binder.UploadControlBinderSettings.FileUploadCompleteHandler = UploadControlDemosHelper.ucAzureUploader_FileUploadComplete;
                //    break;
                //case "AmazonUpload":
                //    binder.UploadControlBinderSettings.UploadStorage = UploadControlUploadStorage.Amazon;
                //    binder.UploadControlBinderSettings.AmazonSettings.Assign(UploadControlDemosHelper.CreateUploadControlAmazonSettings());
                //    binder.UploadControlBinderSettings.FileUploadCompleteHandler = UploadControlDemosHelper.ucAmazonUploader_FileUploadComplete;
                //    break;
                //case "DropboxUpload":
                //    binder.UploadControlBinderSettings.UploadStorage = UploadControlUploadStorage.Dropbox;
                //    binder.UploadControlBinderSettings.DropboxSettings.Assign(UploadControlDemosHelper.CreateUploadControlDropboxSettings());
                //    binder.UploadControlBinderSettings.FileUploadCompleteHandler = UploadControlDemosHelper.ucDropboxUploader_FileUploadComplete;
                //    break;
            }
            base.Execute(requestContext);
        }

    }
}
