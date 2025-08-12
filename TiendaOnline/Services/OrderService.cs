using TiendaOnline.Contract;
using TiendaOnline.Models.Dto;
using TiendaOnline.Services.Contract;

namespace TiendaOnline.Services
{
    public class OrderService : IOrderService
    {
        private readonly IBaseService _baseService;
        public OrderService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto> CreateOrder(CartDto cartDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.Utilities.ApiType.POST,
                Data = cartDto,
                Url = Utility.Utilities.OrderAPIBase + "/api/OrderApi/CreateOrder",
            });
        }
        public async Task<ResponseDto> CreateStripeSession(StripeRequestDto stripeRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.Utilities.ApiType.POST,
                Data = stripeRequestDto,
                Url = Utility.Utilities.OrderAPIBase + "/api/OrderApi/CreateStripeSession",
            });
        }
        public async Task<ResponseDto> GetAllOrder(string userId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.Utilities.ApiType.GET,
                Url = Utility.Utilities.OrderAPIBase + "/api/OrderApi/GetOrders"+userId,
            });
        }
        public async Task<ResponseDto> GetOrder(int orderId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.Utilities.ApiType.GET,
                Url = Utility.Utilities.OrderAPIBase + "/api/OrderApi/GetOrder?orderId=" + orderId,
            });
        }
        public async Task<ResponseDto> UpdateOrderStatus(int orderId, string newStatus)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.Utilities.ApiType.POST,
                Data = newStatus,
                Url = Utility.Utilities.OrderAPIBase + "/api/OrderApi/UpdateOrderStatus/" + orderId,
            });
        }
        public async Task<ResponseDto> ValidateStripeSession(int orderHeaderId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.Utilities.ApiType.POST,
                Data = orderHeaderId,
                Url = Utility.Utilities.OrderAPIBase + "/api/OrderApi/ValidateStripeSession",
            });
        }
    }
}
