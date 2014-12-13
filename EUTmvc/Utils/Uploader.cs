using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace EUTmvc.Utils
{
    public class Uploader
    {
        /// <summary>
        /// Kiểm tra xem có upload file hay không
        /// </summary>
        /// <param name="FieldName">Tên trường file trên form</param>
        /// <returns>True nếu có upload, ngược lại thì không upload</returns>
        public static bool HasFile(HttpPostedFileBase file)
        {
            //HttpPostedFile file = HttpContext.Current.Request.Files[FieldName];
            return (file != null && file.ContentLength > 0);
        }

        /// <summary>
        /// Lưu file upload
        /// </summary>
        /// <param name="FieldName">Tên trường file trên form</param>
        /// <param name="file"></param>
        /// <param name="folder">Thư mục lưu file upload</param>
        /// <param name="fileName">Tên file mới, nếu không truyền thì giữ nguyên tên của file upload</param>
        /// <returns>Tên file đã lưu</returns>
        public static String Save(HttpPostedFileBase file, String folder, String fileName = null)
        {
            fileName = fileName ?? Path.GetFileName(file.FileName);
            if (fileName != null)
            {
                var path = Path.Combine(HttpContext.Current.Server.MapPath(folder), fileName);
                file.SaveAs(path);
            }
            return fileName;
        }

        public static String SaveImg(HttpPostedFileBase file, String folder, String fileName = null)
        {
            WebImage img = new WebImage(file.InputStream);
            if (fileName == null)
            {
                fileName = Path.GetFileName(file.FileName);
            }
            else
            {
                fileName += "." + img.ImageFormat;
            }

            var path = Path.Combine(HttpContext.Current.Server.MapPath(folder), fileName);
            //img.Resize(100, 100);
            img.Save(path);
            return fileName;
        }

        public static string SaveWord(HttpPostedFileBase file, String folder, String fileName = null)
        {
            fileName = fileName ?? Path.GetFileName(file.FileName);
            string _path = HttpContext.Current.Server.MapPath(folder);
            var path = Path.Combine(_path, fileName);
            file.SaveAs(path);
            ConvertToHtml.Convert(_path, fileName);
            return _path;
        }

    }
}