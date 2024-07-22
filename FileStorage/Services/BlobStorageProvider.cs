namespace FileStorage.Services
{
    public interface IBlobStorageProvider
    {
        Task<string> SaveFileAsync(Stream fileStream, string fileName);
        Task<Stream> GetFileAsync(string filePath);
        Task DeleteFileAsync(string filePath);
        //Task<IEnumerable<string>> ListFilesAsync();
        Task<string> UploadFileAsync(string fileId, IFormFile file);
    }

    public class LocalBlobStorageProvider : IBlobStorageProvider
    {
        private readonly string _storagePath;

        public LocalBlobStorageProvider(string storagePath)
        {
            _storagePath = storagePath;

            if (!Directory.Exists(_storagePath))
            {
                Directory.CreateDirectory(_storagePath);
            }
        }

        public async Task<string> SaveFileAsync(Stream fileStream, string fileName)
        {
            var filePath = Path.Combine(_storagePath, fileName);
            using (var fileStreamDestination = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                await fileStream.CopyToAsync(fileStreamDestination);
            }
            return filePath;
        }

        public async Task<Stream> GetFileAsync(string filePath)
        {
            var fullFilePath = Path.Combine(_storagePath, filePath);
            if (!File.Exists(fullFilePath))
            {
                throw new FileNotFoundException("File not found", filePath);
            }

            return new FileStream(fullFilePath, FileMode.Open, FileAccess.Read);
        }

        public async Task DeleteFileAsync(string filePath)
        {
            var fullFilePath = Path.Combine(_storagePath, filePath);
            if (File.Exists(fullFilePath))
            {
                File.Delete(fullFilePath);
            }
            await Task.CompletedTask;
        }

        //public async Task<IEnumerable<string>> ListFilesAsync()
        //{
        //    var files = Directory.EnumerateFiles(_storagePath).Select(Path.GetFileName);
        //    return await Task.FromResult(files);
        //}

        public async Task<string> UploadFileAsync(string fileId, IFormFile file)
        {
            var filePath = Path.Combine(_storagePath, fileId);
            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                await file.CopyToAsync(fileStream);
            }
            return filePath;

        }
    }
}
