using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.IO;

namespace ApiDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly FileExtensionContentTypeProvider _provider;
        public FilesController(FileExtensionContentTypeProvider provider)
        {
               this._provider=provider;
        }

        //{} says that name is optional and not a fix name 
        [HttpGet("{fileId}")]
        public ActionResult GetFile(string fileId)
        {
            //string filePath = "file.rar"; if file is in root of project
            string filePath = @"C:\Users\SCHAHRAD\source\repos\ApiDotNet\ApiDotNet/wwwroot/file.rar";
            if (! System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var bytes = System.IO.File.ReadAllBytes(filePath);
            //text/plain is the format for rar files

            if (! _provider.
                TryGetContentType(filePath,out var contentType))
            {
                contentType = "application/octet-stream";
            }
            return File(bytes, contentType, Path.GetFileName(filePath));
        }
    }
}
