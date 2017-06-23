using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApplication.Services
{
    public class ImageService
    {
        public bool SaveImage(HttpServerUtilityBase server, HttpPostedFileBase file, Guid id, string fileName)
        {
            if (file != null)
            {
                try
                {
                    string pic = System.IO.Path.GetFileName(file.FileName);
                    var folder = GetFolderPath(server, id);
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }
                    string path = GetFilePath(server, id, pic);
                    file.SaveAs(path);


                    using (MemoryStream ms = new MemoryStream())
                    {
                        file.InputStream.CopyTo(ms);
                        byte[] array = ms.GetBuffer();
                    }
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }

            }
            else
            {
                return File.Exists(GetFilePath(server, id, fileName));
            }
        }

        private static string GetFilePath(HttpServerUtilityBase server, Guid id, string pic)
        {
            return Path.Combine(server.MapPath("~/images/" + id.ToString()), pic);
        }

        private static string GetFolderPath(HttpServerUtilityBase server, Guid id)
        {
            return server.MapPath("~/images/" + id.ToString());
        }

        public byte[] GetImageBytes(HttpServerUtilityBase server, Guid id, string filename)
        {
            var path = GetFilePath(server, id, filename);
            if (File.Exists(path))
            {
                return File.ReadAllBytes(path);
            }
            else
            {
                return null;
            }
        }

        public void SaveImage(HttpServerUtilityBase server, byte[] file, Guid id, string fileName)
        {
            if (!string.IsNullOrEmpty(fileName) && file != null)
            {
                var path = GetFolderPath(server, id);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                File.WriteAllBytes(GetFilePath(server, id, fileName), file);
            }
        }
    }
}