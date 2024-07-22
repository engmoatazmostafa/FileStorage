using System.ComponentModel.DataAnnotations;

namespace FileStorage.Entities
{
    public class FileMetaData
    {
        [Key]
        public string FileId { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public long Size { get; set; }

        public string FilePath { get; set; } = string.Empty;
        
        // Foreign key
        public string UserId { get; set; }

        // Navigation property
        public ApplicationUser ApplicationUser { get; set; }


    }
}
