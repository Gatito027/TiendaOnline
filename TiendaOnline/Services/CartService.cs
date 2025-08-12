using TiendaOnline.Contract;
using TiendaOnline.Models.Dto;
using TiendaOnline.Services.Contract;

namespace TiendaOnline.Services
{
    public class CartService : ICartService
    {
        private readonly IBaseService _baseService;
        public CartService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto> ApplyCouponAsync(CartDto cartDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.Utilities.ApiType.POST,
                Data = cartDto,
                Url = Utility.Utilities.ShoppingCartAPIBase + "/api/CartApi/ApplyCoupon",
            });
        }
        public async Task<ResponseDto> EmailCart(CartDto cartDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.Utilities.ApiType.POST,
                Data = cartDto,
                Url = Utility.Utilities.ShoppingCartAPIBase + "/api/CartApi/EmailCartRequest",
            });
        }

        public async Task<ResponseDto> GetCartByUserIdAsync(string userId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.Utilities.ApiType.GET,
                Url = Utility.Utilities.ShoppingCartAPIBase + "/api/CartApi/GetCart/" + userId
            });
        }

        public async Task<ResponseDto> RemoveFromCartAsync(int cartDetailsId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.Utilities.ApiType.POST,
                Data = cartDetailsId,
                Url = Utility.Utilities.ShoppingCartAPIBase + "/api/CartApi/RemoveFromCart/"
            });
        }

        public async Task<ResponseDto> UpsertCartAsync(CartDto cartDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.Utilities.ApiType.POST,
                Data = cartDto,
                Url = Utility.Utilities.ShoppingCartAPIBase + "/api/CartApi/UpsertCart",
            });
        }
    }
}
