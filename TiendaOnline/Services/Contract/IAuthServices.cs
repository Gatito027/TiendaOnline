using TiendaOnline.Models.Dto;

namespace TiendaOnline.Contract
{
    public interface IAuthServices
    {
        Task<ResponseDto> LoginAsync(LoginRequestDto loginRequestDto);
        Task<ResponseDto> RegisterAsync(RegistrationRequestDto registrationRequestDto);
        Task<ResponseDto> AssignRoleAsync(RegistrationRequestDto registrationRequestDto);
    }
}
