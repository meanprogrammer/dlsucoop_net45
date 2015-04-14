using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebsiteTrial.Helper
{
    public class FileUploadHelper
    {
        public static DirectoryInfo EnsureFolderForUpload(string userId)
        {
            DirectoryInfo info = null;
             string fullPath = HttpContext.Current.Server.MapPath("Uploads");
             if (!Directory.Exists(userId))
             {
                 info=  Directory.CreateDirectory(string.Format(@"{0}\{1}", fullPath, userId));
             }
            return info;
        }

        public static string CreateFullFilename(string empNo, string fileName)
        {
            string extension = Path.GetExtension(fileName);
            string format = "{0}-payslip-{1}{2}";
            string completeFilename = string.Format(format, empNo, DateTime.Now.ToString("yyyyMMddHHmmssfff"), extension);
            return completeFilename;
        }

        public static string CreateFullPath(string empNo, string fileName, string path) {

            string completePath = string.Format(@"{0}\{1}", path, fileName);
            return completePath;
        }
    }
}