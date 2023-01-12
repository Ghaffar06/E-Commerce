using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ECommerce
{
    public static class Utilities
    {
        
        public static async Task<string> SaveFileAsync(IFormFile uploadFile)
        {
            if (uploadFile == null || uploadFile.Length == 0)
                return null;

            var fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(uploadFile.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\data", fileName);
            using (var fileSrteam = new FileStream(filePath, FileMode.Create))
            {
                await uploadFile.CopyToAsync(fileSrteam);
            }
            return filePath;
        }

        public static string SaveFile(IFormFile uploadFile)
        {
            if (uploadFile == null || uploadFile.Length == 0)
                return null;

            var fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(uploadFile.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\data", fileName);
            using (var fileSrteam = new FileStream(filePath, FileMode.Create))
            {
                uploadFile.CopyToAsync(fileSrteam);
            }
            return filePath;
        }
    }
}
