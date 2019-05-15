using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace DKITProject.Administration.Controllers
{
    public class FileUploader : Controller
    {

        IHostingEnvironment _env;
        
        public FileUploader(IHostingEnvironment env)
        {
            _env = env;
        }

        [HttpPost("api/addphoto")]
        public IActionResult FileUpload(IFormCollection data)
        {
            if(data == null)
            {
                return BadRequest("File not found!");
            }

            if(Request.Form.Files.Count == 0)
            {
                return BadRequest("File not found!");
            }

            Random rand = new Random();
            string path;

            var files = Request.Form.Files;
            string name = rand.Next(10000000).ToString();
            path = "/files/" + name + "." + files[0].ContentType.Substring(6);
            using (var fileStream = new FileStream(_env.WebRootPath + path, FileMode.Create))
            {
                files[0].CopyToAsync(fileStream);
            }
            path = "{\"path\":\"" + path + "\"}"; ;
            return Ok(path);
        }
    }
}
