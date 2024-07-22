using FileStorage.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileStorage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly IMetadataRepository _metadataRepository;
        private  readonly IUserService _userService;
        public FileController(IFileService fileService, IMetadataRepository metadataRepository, IUserService userService)
        {
            _fileService = fileService;
            _metadataRepository = metadataRepository;
            _userService = userService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            var result = await _fileService.UploadFileAsync(file);
            return Ok(new { FileId = result });
        }

        [HttpGet("myfiles")]
        public async Task<IActionResult> GetMyFiles()
        {
            var files = await _fileService.GetUserFilesAsync();
            return Ok(files);
        }

        [HttpDelete("delete/{fileId}")]
        public async Task<IActionResult> DeleteFile(string fileId)
        {
            var result = await _fileService.DeleteFileAsync(fileId);
            if (!result)
            {
                return BadRequest("File not found or not owned by the user.");
            }
            return Ok("File deleted successfully.");
        }

        [HttpPut("replace/{fileId}")]
        public async Task<IActionResult> ReplaceFile(string fileId, IFormFile file)
        {
            var deleteResult = await _fileService.DeleteFileAsync(fileId);
            if (!deleteResult)
            {
                return BadRequest("File not found or not owned by the user.");
            }

            var uploadResult = await _fileService.UploadFileAsync(file);
            return Ok(new { FileId = uploadResult });
        }

        [HttpGet("download/{fileId}")]
        public async Task<IActionResult> DownloadFile(string fileId)
        {
            var metadata = await _metadataRepository.GetMetadataByIdAsync(fileId);
            if (metadata == null || metadata.UserId != _userService.GetCurrentUserId())
            {
                return BadRequest("File not found or not owned by the user.");
            }

            var fileStream = await _fileService.DownloadFileAsync(metadata.FilePath);
            return File(fileStream, metadata.ContentType, metadata.FileName);
        }

    }
}
