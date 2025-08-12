using Microsoft.AspNetCore.Mvc;
using TiendaOnline.Contract;
using TiendaOnline.Filters;
using TiendaOnline.Models;
using TiendaOnline.Services.Contract;


namespace TiendaOnline.Controllers
{
    [ApiController]
    [Route("api/archivos")]
    public class FilesCloudController : Controller
    {
        private readonly IDataCloudAzure cloudAzure;
        private readonly string container = "archivosadjuntos";
        public FilesCloudController(IDataCloudAzure _cloudAzure)
        {
            this.cloudAzure = _cloudAzure;
        }

        [CustomExeceptionFilterAttribute]
        [HttpPost("{Id:int}")]
        public async Task<ActionResult> Post(int Id, [FromForm] IEnumerable<IFormFile> archivos)
        {
            //verificar si existen archvios adjuntos
            if (archivos == null || !archivos.Any())
            {
                return BadRequest("No existen archivos cargados");
            }
            // Reemplaza la línea problemática:
            // var result = null; // Simulating the upload result for demonstration purposes

            // Solución: Especifica el tipo explícitamente y asígnale una lista vacía del tipo esperado.
            // Suponiendo que el resultado esperado es una lista de objetos con propiedades URL y Titulo.
            // Si tienes una clase específica para el resultado, reemplaza 'dynamic' por el tipo correcto.
            var result = new List<dynamic>(); // Simulación de resultado de carga para propósitos de demostración
            var filesAtach = result.Select((result, indice) => new FileAttach
            {
                FechaCreacion = DateTime.UtcNow,
                URL = result.URL,
                Titulo = result.Titulo,
                Orden = indice + 1

            }).ToList();
            return Ok();
        }

    }
}
