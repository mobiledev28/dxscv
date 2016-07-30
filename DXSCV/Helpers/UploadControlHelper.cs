using DevExpress.Web;
using DevExpress.Web.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
//using System.Web.UI.WebControls;

using System.Drawing;

namespace DXSCV.Helpers
{
    public class UploadControlHelper
    {
        const string AzureAccessKeySettingName = "UploadAzureAccessKey";
        const string AmazonAccessKeyIDSettingName = "UploadAmazonAccessKeyID";
        const string AmazonSecretAccessKeySettingName = "UploadAmazonSecretAccessKey";
        const string DropboxAccessTokenValueSettingName = "UploadDropboxAccessTokenValue";

        public const string UploadDirectory = "~/Content/Documents/";
        public const string DocumentsDirectory = "~/Content/Documents/";
        public const string TempDirectory = "~/Content/Documents/";
        public const string ThumbnailFormat = "Thumbnail{0}{1}";

        static string AzureAccessKey
        {
            get
            {
                return WebConfigurationManager.AppSettings[UploadControlHelper.AzureAccessKeySettingName];
            }
        }
        static string AmazonAccessKeyID
        {
            get
            {
                return WebConfigurationManager.AppSettings[UploadControlHelper.AmazonAccessKeyIDSettingName];
            }
        }
        static string AmazonSecretAccessKey
        {
            get
            {
                return WebConfigurationManager.AppSettings[UploadControlHelper.AmazonSecretAccessKeySettingName];
            }
        }
        static string DropboxAccessTokenValue
        {
            get
            {
                return WebConfigurationManager.AppSettings[UploadControlHelper.DropboxAccessTokenValueSettingName];
            }
        }

        public static readonly UploadControlValidationSettings UploadValidationSettings = new UploadControlValidationSettings
        {
            AllowedFileExtensions = new string[] { ".jpg", ".jpeg", ".gif", ".png", ".doc", ".docx", ".pdf", ".xls", ".xlsx", ".txt" },
            MaxFileSize = 4194304
        };
        //////public static UploadControlAzureSettings CreateUploadControlAzureSettings()
        //////{
        //////    UploadControlAzureSettings settings = null;
        //////    AzureConnectionInfo connInfo = GetAzureConnectionInfo();
        //////    if (connInfo != null)
        //////    {
        //////        settings = new UploadControlAzureSettings();
        //////        settings.StorageAccountName = connInfo.StorageAccountName;
        //////        settings.AccessKey = connInfo.AccessKey;
        //////        settings.ContainerName = connInfo.ContainerName;
        //////    }
        //////    return settings;
        //////}
        //////public static UploadControlAmazonSettings CreateUploadControlAmazonSettings()
        //////{
        //////    UploadControlAmazonSettings settings = null;
        //////    AmazonConnectionInfo connInfo = GetAmazonConnectionInfo();
        //////    if (connInfo != null)
        //////    {
        //////        settings = new UploadControlAmazonSettings();
        //////        settings.AccessKeyID = connInfo.AccessKeyID;
        //////        settings.SecretAccessKey = connInfo.SecretAccessKey;
        //////        settings.BucketName = connInfo.BucketName;
        //////        settings.Region = connInfo.Region;
        //////    }
        //////    return settings;
        //////}
        //////public static UploadControlDropboxSettings CreateUploadControlDropboxSettings()
        //////{
        //////    UploadControlDropboxSettings settings = null;
        //////    DropboxConnectionInfo connInfo = GetDropboxConnectionInfo();
        //////    if (connInfo != null)
        //////    {
        //////        settings = new UploadControlDropboxSettings();
        //////        settings.AccessTokenValue = connInfo.AccessTokenValue;
        //////    }
        //////    return settings;
        //////}

        public static void ucDragAndDrop_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
            if (e.UploadedFile.IsValid)
            {
                string fileName = Path.ChangeExtension(Path.GetRandomFileName(), ".jpg");
                string resultFilePath = UploadDirectory + fileName;
                using (Image original = Image.FromStream(e.UploadedFile.FileContent))
                using (Image thumbnail = ImageUtils.CreateThumbnailImage((Bitmap)original, ImageSizeMode.ActualSizeOrFit, new Size(350, 350)))
                {
                    ImageUtils.SaveToJpeg((Bitmap)thumbnail, HttpContext.Current.Request.MapPath(resultFilePath));
                }
                UploadingUtils.RemoveFileWithDelay(fileName, HttpContext.Current.Request.MapPath(resultFilePath), 5);
                IUrlResolutionService urlResolver = sender as IUrlResolutionService;
                if (urlResolver != null)
                    e.CallbackData = urlResolver.ResolveClientUrl(resultFilePath);
            }
        }

        public static void ucMultiSelection_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
            string resultFileName = Path.GetRandomFileName() + "_" + e.UploadedFile.FileName;
            string resultFileUrl = UploadDirectory + resultFileName;
            string resultFilePath = HttpContext.Current.Request.MapPath(resultFileUrl);
            e.UploadedFile.SaveAs(resultFilePath);

            UploadingUtils.RemoveFileWithDelay(resultFileName, resultFilePath, 5);

            IUrlResolutionService urlResolver = sender as IUrlResolutionService;
            if (urlResolver != null)
            {
                string url = urlResolver.ResolveClientUrl(resultFileUrl);
                e.CallbackData = GetCallbackData(e.UploadedFile, url);
            }
        }
        //public static void ucAzureUploader_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        //{
        //    AzureConnectionInfo azureInfo = GetAzureConnectionInfo();
        //    RemoveFileFromAzureWithDelay(e.UploadedFile.FileNameInStorage, azureInfo, 5);

        //    string url = GetAzureImageUrl(e.UploadedFile.FileNameInStorage, azureInfo);
        //    e.CallbackData = GetCallbackData(e.UploadedFile, url);
        //}
        //public static void ucAmazonUploader_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        //{
        //    AmazonConnectionInfo amazonInfo = GetAmazonConnectionInfo();
        //    RemoveFileFromAmazonWithDelay(e.UploadedFile.FileNameInStorage, amazonInfo, 5);

        //    string url = GetAmazonImageUrl(e.UploadedFile.FileNameInStorage, amazonInfo);
        //    e.CallbackData = GetCallbackData(e.UploadedFile, url);
        //}
        //public static void ucDropboxUploader_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        //{
        //    DropboxConnectionInfo dropboxInfo = GetDropboxConnectionInfo();
        //    RemoveFileFromDropboxWithDelay(e.UploadedFile.FileName, dropboxInfo, 5);

        //    string url = GetDropboxImageUrl(e.UploadedFile.FileNameInStorage, dropboxInfo);
        //    e.CallbackData = GetCallbackData(e.UploadedFile, url);
        //}

        static string GetCallbackData(UploadedFile uploadedFile, string fileUrl)
        {
            string name = uploadedFile.FileName;
            long sizeInKilobytes = uploadedFile.ContentLength / 1024;
            string sizeText = sizeInKilobytes.ToString() + " KB";

            return name + "|" + fileUrl + "|" + sizeText;
        }

        //public static AzureConnectionInfo GetAzureConnectionInfo()
        //{
        //    if (string.IsNullOrEmpty(AzureAccessKey))
        //        return null;
        //    AzureConnectionInfo connInfo = new AzureConnectionInfo();
        //    connInfo.StorageAccountName = "aspdemo";
        //    connInfo.AccessKey = AzureAccessKey;
        //    connInfo.ContainerName = "uploadcontroldemo";
        //    return connInfo;
        //}
        //public static AmazonConnectionInfo GetAmazonConnectionInfo()
        //{
        //    if (string.IsNullOrEmpty(AmazonAccessKeyID) || string.IsNullOrEmpty(AmazonSecretAccessKey))
        //        return null;
        //    AmazonConnectionInfo connInfo = new AmazonConnectionInfo();
        //    connInfo.AccessKeyID = AmazonAccessKeyID;
        //    connInfo.SecretAccessKey = AmazonSecretAccessKey;
        //    connInfo.BucketName = "dxuploaddemo";
        //    connInfo.Region = "us-east-1";
        //    return connInfo;
        //}
        //public static DropboxConnectionInfo GetDropboxConnectionInfo()
        //{
        //    if (string.IsNullOrEmpty(DropboxAccessTokenValue))
        //        return null;
        //    DropboxConnectionInfo connInfo = new DropboxConnectionInfo();
        //    connInfo.AccessTokenValue = DropboxAccessTokenValue;
        //    return connInfo;
        //}
        //////static string GetAzureImageUrl(string fileName, AzureConnectionInfo connectionInfo)
        //////{
        //////    AzureFileSystemProvider provider = new AzureFileSystemProvider("");
        //////    provider.StorageAccountName = connectionInfo.StorageAccountName;
        //////    provider.AccessKey = connectionInfo.AccessKey;
        //////    provider.ContainerName = connectionInfo.ContainerName;
        //////    FileManagerFile file = new FileManagerFile(provider, fileName);
        //////    FileManagerFile[] files = new FileManagerFile[] { file };
        //////    return provider.GetDownloadUrl(files);
        //////}
        //////static string GetAmazonImageUrl(string fileName, AmazonConnectionInfo connectionInfo)
        //////{
        //////    AmazonFileSystemProvider provider = new AmazonFileSystemProvider("");
        //////    provider.AccessKeyID = connectionInfo.AccessKeyID;
        //////    provider.SecretAccessKey = connectionInfo.SecretAccessKey;
        //////    provider.BucketName = connectionInfo.BucketName;
        //////    provider.Region = connectionInfo.Region;
        //////    FileManagerFile file = new FileManagerFile(provider, fileName);
        //////    FileManagerFile[] files = new FileManagerFile[] { file };
        //////    return provider.GetDownloadUrl(files);
        //////}
        //////static string GetDropboxImageUrl(string fileName, DropboxConnectionInfo connectionInfo)
        //////{
        //////    DropboxFileSystemProvider provider = new DropboxFileSystemProvider("");
        //////    provider.AccessTokenValue = connectionInfo.AccessTokenValue;
        //////    FileManagerFile file = new FileManagerFile(provider, fileName);
        //////    FileManagerFile[] files = new FileManagerFile[] { file };
        //////    return provider.GetDownloadUrl(files);
        //////}
        //static void RemoveFileFromAzureWithDelay(string fileKeyName, AzureConnectionInfo azureInfo, int delay)
        //{
        //    UploadingUtils.RemoveFileFromAzureWithDelay(fileKeyName, azureInfo.StorageAccountName,
        //        azureInfo.AccessKey, azureInfo.ContainerName, delay);
        //}
        //static void RemoveFileFromAmazonWithDelay(string fileKeyName, AmazonConnectionInfo amazonInfo, int delay)
        //{
        //    UploadingUtils.RemoveFileFromAmazonWithDelay(fileKeyName, amazonInfo.AccessKeyID,
        //        amazonInfo.SecretAccessKey, amazonInfo.BucketName, amazonInfo.Region, delay);
        //}
        //static void RemoveFileFromDropboxWithDelay(string fileKeyName, DropboxConnectionInfo dropboxInfo, int delay)
        //{
        //    UploadingUtils.RemoveFileFromDropboxWithDelay(fileKeyName, dropboxInfo.AccessTokenValue, delay);
        //}
    }
}