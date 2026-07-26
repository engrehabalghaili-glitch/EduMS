using EduMS.Application.Interfaces.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Infrastructure.Services;

public class FileStorageService : IFileStorageService
{
    private readonly string _uploadDirectory;
    private readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png", ".pdf", ".docx" };
    private readonly long _maxFileSize = 10 * 1024 * 1024; // 10 MB

    public FileStorageService(IWebHostEnvironment env)
    {
        // For development, we store in the wwwroot/uploads or a local Uploads folder.
        // If env.WebRootPath is null, fallback to a local Uploads directory in ContentRoot.
        var basePath = string.IsNullOrWhiteSpace(env.WebRootPath) ? env.ContentRootPath : env.WebRootPath;
        _uploadDirectory = Path.Combine(basePath, "Uploads");

        if (!Directory.Exists(_uploadDirectory))
        {
            Directory.CreateDirectory(_uploadDirectory);
        }
    }

    public async Task<string> UploadFileAsync(Stream fileStream, string fileName, string contentType, CancellationToken cancellationToken = default)
    {
        if (fileStream == null || fileStream.Length == 0)
        {
            throw new ArgumentException("File stream cannot be null or empty.");
        }

        if (fileStream.Length > _maxFileSize)
        {
            throw new ArgumentException($"File size exceeds the maximum allowed limit of {_maxFileSize / (1024 * 1024)} MB.");
        }

        var extension = Path.GetExtension(fileName).ToLowerInvariant();
        if (!_allowedExtensions.Contains(extension))
        {
            throw new ArgumentException($"File extension {extension} is not allowed.");
        }

        var uniqueFileName = $"{Guid.NewGuid()}{extension}";
        var filePath = Path.Combine(_uploadDirectory, uniqueFileName);

        using (var outputStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            await fileStream.CopyToAsync(outputStream, cancellationToken);
        }

        return uniqueFileName;
    }

    public Task DeleteFileAsync(string fileId)
    {
        var filePath = Path.Combine(_uploadDirectory, fileId);
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
        
        return Task.CompletedTask;
    }

    public Task<Stream> GetFileAsync(string fileId)
    {
        var filePath = Path.Combine(_uploadDirectory, fileId);
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"File {fileId} was not found.");
        }

        Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        return Task.FromResult(stream);
    }
}
