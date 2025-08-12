
using TiendaOnline.Contract;
using TiendaOnline.Models.Dto;
using TiendaOnline.Services.Contract;

namespace TiendaOnline.Services
{
    public class ProductService : IProductService
    {
        private readonly IBaseService _baseService;
        public ProductService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto> CreateProductsAsync(ProductDto productDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.Utilities.ApiType.POST,
                Data = productDto,
                Url = Utility.Utilities.ProductAPIBase + "/api/Product",
                ContentType = Utility.Utilities.ContentType.MultipartFormData
            });
        }
        public async Task<ResponseDto> DeleteProductsAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.Utilities.ApiType.DELETE,
                Url = Utility.Utilities.ProductAPIBase + "/api/Product/" + id 
            });
        }
        public async Task<ResponseDto> GatAllProductAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.Utilities.ApiType.GET,
                Url = Utility.Utilities.ProductAPIBase + "/api/Product"
            });
        }
        public async Task<ResponseDto> GetProductByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.Utilities.ApiType.GET,
                Url = Utility.Utilities.ProductAPIBase + "/api/Product/" + id
            });
        }
        public async Task<ResponseDto> UpdateProductsAsync(ProductDto productDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.Utilities.ApiType.PUT,
                Data = productDto,
                Url = Utility.Utilities.ProductAPIBase + "/api/Product",
                ContentType = Utility.Utilities.ContentType.MultipartFormData
            });
        }
    }
}
