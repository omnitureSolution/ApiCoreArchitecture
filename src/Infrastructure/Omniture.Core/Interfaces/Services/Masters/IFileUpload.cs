using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Omniture.Core.Interfaces.Services.Masters
{
    public interface IFileUpload
    {
        Task<string> Upload(IFormFile file);
    }
}
