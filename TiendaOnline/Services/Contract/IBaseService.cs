using TiendaOnline.Models.Dto;

namespace TiendaOnline.Services.Contract
{
    public interface IBaseService
    {
        Task<ResponseDto> SendAsync(RequestDto requestDto, bool withBearer = true);
        //Task<T> SendAsync<T>(RegistrationRequestDto registrationRequestDto, string v, string empty, HttpMethod post);
    }
}
