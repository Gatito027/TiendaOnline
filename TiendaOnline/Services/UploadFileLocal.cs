using TiendaOnline.Models;
using TiendaOnline.Services.Contract;

namespace TiendaOnline.Services
{
    public class UploadFileLocal: IDataCloudAzure
    {
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UploadFileLocal(IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            _env = env ?? throw new ArgumentNullException(nameof(env));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }
        public Task Delete(string path, string container)
        {
            if (string.IsNullOrEmpty(path))
            {
                return Task.CompletedTask;
            }
            var fileName = Path.GetFileName(path);
            var directoryPath = Path.Combine(_env.WebRootPath, container, fileName);
            if (File.Exists(directoryPath))
            {
                File.Delete(directoryPath);
            }
            return Task.CompletedTask;
        }
        public async Task<CloudFileResult[]> UpLoadFiles(string container, IEnumerable<IFormFile> files)
        {
            var task = files.Select(async file =>
            {
                var fileOriginName = Path.GetFileName(file.Name);
                var extension = Path.GetExtension(file.Name);
                var nombreNewFile = $"{Guid.NewGuid()}(extension)";
                string folder = Path.Combine(_env.WebRootPath, container);
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                string pathFile = Path.Combine(folder, nombreNewFile);
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    var contenido = memoryStream.ToArray();
                    await File.WriteAllBytesAsync(pathFile, contenido);
                }
                var url = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
                var urlArchivo = Path.Combine(url, container, nombreNewFile).Replace("\\", "/");
                return new CloudFileResult
                {
                    URL = urlArchivo,
                    Titulo = fileOriginName
                };
            });
            var result = await Task.WhenAll(task);
            return result;
        }
    }
}
