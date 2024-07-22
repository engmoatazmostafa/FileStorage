using FileStorage.Entities;
using System.Security.Claims;

namespace FileStorage.Services
{
    public interface IFileService
    {
        Task<string> UploadFileAsync(IFormFile file);
        Task<IEnumerable<FileMetaData>> GetUserFilesAsync();
        Task<bool> DeleteFileAsync(string fileId);

        Task<Stream> DownloadFileAsync(string filePath);
    }
    public class FileService : IFileService
    {
        private readonly IBlobStorageProvider _blobStorageProvider;
        private readonly IMetadataRepository _metadataRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FileService(IBlobStorageProvider blobStorageProvider, IMetadataRepository metadataRepository, IHttpContextAccessor httpContextAccessor)
        {
            _blobStorageProvider = blobStorageProvider;
            _metadataRepository = metadataRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        private string GetCurrentUserId()
        {
            return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            var userId = GetCurrentUserId();
            var fileId = Guid.NewGuid().ToString();
            var filePath = await _blobStorageProvider.UploadFileAsync(fileId, file);

            var metadata = new FileMetaData
            {
                FileId = fileId,
                FileName = file.FileName,
                ContentType = file.ContentType,
                Size = file.Length,
                FilePath = filePath,
                UserId = userId
            };

            await _metadataRepository.AddMetadataAsync(metadata);
            return fileId;
        }

        public async Task<IEnumerable<FileMetaData>> GetUserFilesAsync()
        {
            var userId = GetCurrentUserId();
            return await _metadataRepository.GetFilesByUserIdAsync(userId);
        }

        public async Task<bool> DeleteFileAsync(string fileId)
        {
            var userId = GetCurrentUserId();
            var metadata = await _metadataRepository.GetMetadataByIdAsync(fileId);

            if (metadata == null || metadata.UserId != userId)
            {
                return false;
            }

            await _blobStorageProvider.DeleteFileAsync(fileId);
            await _metadataRepository.DeleteMetadataAsync(fileId);
            return true;
        }
        public async Task<Stream> DownloadFileAsync(string filePath)
        {
            var fileStream = await _blobStorageProvider.GetFileAsync(filePath);
            return fileStream;
        }

    }
}
