using TiendaOnline.Models.Dto;

namespace TiendaOnline.Contract
{
    public interface IProductService
    {
        Task<ResponseDto> GatAllProductAsync();
        Task<ResponseDto> GetProductByIdAsync(int id);
        Task<ResponseDto> CreateProductsAsync(ProductDto productDto);
        Task<ResponseDto> UpdateProductsAsync(ProductDto productDto);
        Task<ResponseDto> DeleteProductsAsync(int id);
    }
}
