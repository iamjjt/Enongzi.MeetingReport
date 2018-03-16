using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Enongzi.MeetingReport.Controllers
{
    public class FileController : Controller
    {
        public async Task<IActionResult> Upload(IFormFile file)
        {
            //var filePath = Path.GetTempFileName();
            var filePath = Path.Combine("upload", DateTime.Now.ToString("MMddHHmmss") + Path.GetExtension(file.FileName));
            if (file.Length > 0)
            {
                
                using(var stream=new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return Json(new
                {
                    fileName = filePath
                });
            }
            return View();
        }
    }
}