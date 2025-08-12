using System.ComponentModel.DataAnnotations;

namespace TiendaOnline.Models.Dto
{
    public class LoginRequestDto
    {
        [Required(ErrorMessage ="Es necesario ingresar el nembre del usuario")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Es necesario ingresar un password")]
        public string Password { get; set; }
    }
}
