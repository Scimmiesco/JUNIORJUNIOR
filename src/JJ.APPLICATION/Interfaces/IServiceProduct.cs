using JJ.APPLICATION.DTOs;

namespace JJ.APPLICATION.Interfaces
{
    public interface IServiceProduct
    {
        Task<DataResponseDto<ProductDTO?>> GetProductByIdAsync(int id);
        Task<DataResponseDto<IEnumerable<ProductDTO>>> GetAllProductsAsync();
        Task<PaginatedResponseDto<ProductDTO>> GetAllPaginatedProductsAsync(int pageNumber, int pageSize);
        Task<DataResponseDto<ProductDTO>> CreateProductAsync(CreateUpdateProductDTO productDTO);
        Task<ResponseDto> DeleteProductAsync(int id);
    }
}
