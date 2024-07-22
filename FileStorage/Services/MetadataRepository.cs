using FileStorage.DAL;
using FileStorage.Entities;
using Microsoft.EntityFrameworkCore;

namespace FileStorage.Services
{
    public interface IMetadataRepository
    {
        Task AddMetadataAsync(FileMetaData metadata);
        Task<IEnumerable<FileMetaData>> GetFilesByUserIdAsync(string userId);
        Task<FileMetaData> GetMetadataByIdAsync(string fileId);
        Task DeleteMetadataAsync(string fileId);
    }

    public class MetadataRepository : IMetadataRepository
    {
        private readonly ApplicationDbContext _context;

        public MetadataRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddMetadataAsync(FileMetaData metadata)
        {
            _context.Files.Add(metadata);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FileMetaData>> GetFilesByUserIdAsync(string userId)
        {
            return await _context.Files.Where(f => f.UserId == userId).ToListAsync();
        }

        public async Task<FileMetaData> GetMetadataByIdAsync(string fileId)
        {
            return await _context.Files.SingleOrDefaultAsync(f => f.FileId == fileId);
        }

        public async Task DeleteMetadataAsync(string fileId)
        {
            var metadata = await _context.Files.SingleOrDefaultAsync(f => f.FileId == fileId);
            if (metadata != null)
            {
                _context.Files.Remove(metadata);
                await _context.SaveChangesAsync();
            }
        }
    }

}
