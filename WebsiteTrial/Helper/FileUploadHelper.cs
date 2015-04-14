using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebsiteTrial.Helper
{
    public class FileUploadHelper
    {
        public static void EnsureFolderForUpload(string userId)
        {
             string fullPath = HttpContext.Current.Server.MapPath("Uploads");
             if (!Directory.Exists(userId))
             {
                 Directory.CreateDirectory(string.Format(@"{0}\{1}", fullPath, userId));
             }
        }
    }
}