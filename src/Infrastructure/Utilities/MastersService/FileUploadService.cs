using Omniture.Core.Interfaces.Services.Masters;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MastersService
{
    public class FileUploadService : IFileUpload
    {
        private readonly IHostingEnvironment _env;
        public FileUploadService(IHostingEnvironment env)
        {
            _env = env;
        }

        public async Task<string> Upload(IFormFile file)
        {
            var uniqueFolder = Guid.NewGuid().ToString();
            Directory.CreateDirectory($"{_env.ContentRootPath}\\Uploads\\{uniqueFolder}");
            var filePath = $"{_env.ContentRootPath}\\Uploads\\{uniqueFolder}\\{file.FileName}";
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return $"\\{uniqueFolder}\\{file.FileName}";
        }
    }
}
