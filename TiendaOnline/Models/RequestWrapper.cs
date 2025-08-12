using System.ComponentModel.DataAnnotations;

namespace TiendaOnline.Models
{
    public class RequestWrapper<T>
    {
        [Required]
        public T Body { get; set; }
    }
}
