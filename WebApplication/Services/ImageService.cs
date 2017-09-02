using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;

namespace WebApplication.Services
{
    public class ImageService
    {
        public bool SaveImage(HttpServerUtilityBase server, byte[] file, Guid id, string fileName)
        {
            try
            {
                if (!string.IsNullOrEmpty(fileName) && file != null)
                {
                    var path = GetFolderPath(server, id);
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    //try access file if it's locked
                    for (int i = 0; i < 1000; i++)
                    {
                        try
                        {
                            File.WriteAllBytes(GetFilePath(server, id, fileName), file);
                            return true;
                        }
                        catch (Exception e)
                        {
                            Thread.Sleep(100);
                        }
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
            }
            return false;
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


    }
}