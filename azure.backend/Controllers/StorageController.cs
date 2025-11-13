using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TerapiaApp.API.Services;

namespace TerapiaApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class StorageController : ControllerBase
    {
        private readonly IBlobStorageService _blobStorageService;

        public StorageController(IBlobStorageService blobStorageService)
        {
            _blobStorageService = blobStorageService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file, [FromForm] string taskId)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest(new { message = "No file uploaded" });
            }

            if (string.IsNullOrEmpty(taskId))
            {
                return BadRequest(new { message = "Task ID is required" });
            }

            try
            {
                var fileName = $"task_{taskId}_{DateTime.UtcNow:yyyyMMddHHmmss}_{Guid.NewGuid():N}{Path.GetExtension(file.FileName)}";
                
                using var stream = file.OpenReadStream();
                var fileUrl = await _blobStorageService.UploadFileAsync(stream, fileName, file.ContentType);
                
                return Ok(new { url = fileUrl });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Error uploading file: {ex.Message}" });
            }
        }
    }
}