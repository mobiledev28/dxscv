using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace DXSCV.Helpers
{
    public class UCHelper
    {
        public const string UploadDirectory = "C://SCVDocs//";

        public static readonly UploadControlValidationSettings ValidationSettings = new UploadControlValidationSettings
        {
            AllowedFileExtensions = new string[] { ".jpg", ".jpeg", ".gif", ".png", ".doc", ".docx", ".pdf", ".xls", ".xlsx", ".txt" },
            MaxFileSize = 4194304
        };

        public static void uc_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
            
            if (e.UploadedFile.IsValid)
            {
                //string resultFilePath = HttpContext.Current.Request.MapPath(UploadDirectory + e.UploadedFile.FileName);
                string resultFilePath = UploadDirectory + e.UploadedFile.FileName;
                IUrlResolutionService urlResolver = sender as IUrlResolutionService;
                if (urlResolver != null)
                {
                    e.UploadedFile.SaveAs(resultFilePath);
                    e.CallbackData = urlResolver.ResolveClientUrl(resultFilePath);
                }
            }
        }

        public static void uc_UserPictureUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
            string fisicalURL = ConfigurationManager.AppSettings["URLUserPictures"].ToString();
            if (e.UploadedFile.IsValid)
            {
                //string resultFilePath = HttpContext.Current.Request.MapPath(UploadDirectory + e.UploadedFile.FileName);
                string resultFilePath = fisicalURL + e.UploadedFile.FileName;
                IUrlResolutionService urlResolver = sender as IUrlResolutionService;
                if (urlResolver != null)
                {
                    e.UploadedFile.SaveAs(resultFilePath);
                    e.CallbackData = urlResolver.ResolveClientUrl(resultFilePath);
                }
            }
        }
    }
}