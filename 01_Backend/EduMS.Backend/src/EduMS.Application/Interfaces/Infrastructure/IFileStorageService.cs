using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.Interfaces.Infrastructure;

public interface IFileStorageService
{
    Task<string> UploadFileAsync(Stream fileStream, string fileName, string contentType, CancellationToken cancellationToken = default);
    Task DeleteFileAsync(string fileId);
    Task<Stream> GetFileAsync(string fileId);
}
