using Microsoft.AspNetCore.Identity;

namespace FileStorage.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string UserId { get; set; } = Guid.NewGuid().ToString();
        //public string Username { get; set; } = string.Empty;
        //public string PasswordHash { get; set; } = string.Empty;
        // Navigation property
        public ICollection<FileMetaData> Files { get; set; }
    }

}
