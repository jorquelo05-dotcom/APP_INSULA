namespace TerapiaApp.API.Services
{
    public class BlobStorageService : IBlobStorageService
    {
        public async Task<string> UploadFileAsync(Stream fileStream, string fileName, string contentType)
        {
            // Simular subida para desarrollo
            await Task.Delay(500);
            return $"https://example.com/files/{fileName}";
        }

        public async Task<bool> DeleteFileAsync(string fileName)
        {
            // Simular eliminación para desarrollo
            await Task.Delay(300);
            return true;
        }
    }
}