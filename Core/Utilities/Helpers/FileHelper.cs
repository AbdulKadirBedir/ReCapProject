using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        
            public static string Add(IFormFile file)
            {
                string path = Environment.CurrentDirectory + @"\wwwroot\images\";
                var sourcepath = Path.GetTempFileName();
                if (file.Length > 0)
                {
                    using (var stream = new FileStream(sourcepath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                var path1 = newPath(file);
                var result = path + path1;
                File.Move(sourcepath, result);
                return "/images/" + path1;
            }


            public static void Delete(string path)
            {
                string path2 = Environment.CurrentDirectory + @"\wwwroot";
                File.Delete(path2 + path);
            }

            public static string Update(string sourcePath, IFormFile file)
            {
                var result = Add(file);
                if (sourcePath.Length > 0)
                {
                    Delete(sourcePath);
                }


                return result;
            }


            public static string newPath(IFormFile file)
            {
                FileInfo ff = new FileInfo(file.FileName);
                string fileExtension = ff.Extension;

                
                var newPath = Guid.NewGuid().ToString() + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Year + fileExtension;

                
                return newPath;
            }
        
    }
}