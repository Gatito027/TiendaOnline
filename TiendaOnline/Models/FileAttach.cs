namespace TiendaOnline.Models
{
    public class FileAttach
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string URL { get; set; }
        public string Titulo { get; set; }
        public int Orden {  get; set; }
    }
}
