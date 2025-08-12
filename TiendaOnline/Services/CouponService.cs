using TiendaOnline.Contract;
using TiendaOnline.Models.Dto;
using TiendaOnline.Services.Contract;

namespace TiendaOnline.Services
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;
        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto> CreateCouponsAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.Utilities.ApiType.POST,
                Data = couponDto,
                Url = Utility.Utilities.CouponAPIBase + "/api/Cupon",
            });
        }
        public async Task<ResponseDto> DeleteCouponsAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.Utilities.ApiType.DELETE,
                Url = Utility.Utilities.CouponAPIBase + "/api/Cupon/" + id,
            });
        }
        public async Task<ResponseDto> GetAllCouponsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.Utilities.ApiType.GET,
                Url = Utility.Utilities.CouponAPIBase + "/api/Cupon",
            });
        }
        public async Task<ResponseDto> GetCouponByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.Utilities.ApiType.GET,
                Url = Utility.Utilities.CouponAPIBase + "/api/Cupon/" + id,
            });
        }
        public Task<ResponseDto> GetCouponAsync(string couponCode)
        {
            return _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.Utilities.ApiType.GET,
                Url = Utility.Utilities.CouponAPIBase + "/api/Cupon/GetByCode/" + couponCode,
            });
        }
        public async Task<ResponseDto> UpdateCouponsAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.Utilities.ApiType.PUT,
                Data = couponDto,
                Url = Utility.Utilities.CouponAPIBase + "/api/Cupon",
            });
        }
    }
}
