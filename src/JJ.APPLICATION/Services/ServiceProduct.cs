using AutoMapper;
using JJ.APPLICATION.DTOs;
using JJ.APPLICATION.Interfaces;
using JJ.DOMAIN.Entities;
using JJ.DOMAIN.Interfaces.Repositorys;

namespace JJ.APPLICATION.Services
{

    public class ProductService(IRepositoryProduct productRepository, IMapper mapper) : IServiceProduct
    {
        private readonly IRepositoryProduct _productRepository = productRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<DataResponseDto<ProductDTO>> CreateProductAsync(CreateUpdateProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);

            await _productRepository.AddAsync(product);
            await _productRepository.SaveChangesAsync();

            var productDTO = _mapper.Map<ProductDTO>(product);

            return new DataResponseDto<ProductDTO>(productDTO);
        }

        public async Task<ResponseDto> DeleteProductAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null) return new ResponseDto("Produto a ser excluído não encontrado!");

            _productRepository.Delete(product);
            await _productRepository.SaveChangesAsync();

            return new ResponseDto();
        }

        public async Task<DataResponseDto<IEnumerable<ProductDTO>>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();

            var dto = _mapper.Map<IEnumerable<ProductDTO>>(products);

            return new DataResponseDto<IEnumerable<ProductDTO>>(dto);
        }

        public async Task<PaginatedResponseDto<ProductDTO>> GetAllPaginatedProductsAsync(int pageNumber, int pageSize)
        {
            var (data, totalCount )= await _productRepository.GetAllPaginatedAsync(pageNumber, pageSize);

            var dto = _mapper.Map<List<ProductDTO>>(data);

            return new PaginatedResponseDto<ProductDTO>(dto, totalCount, pageNumber, pageSize);
        }

        public async Task<DataResponseDto<ProductDTO?>> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null) return new DataResponseDto<ProductDTO?>("Produto não encontrado em sistema.");

            var dto = _mapper.Map<ProductDTO>(product);

            return new DataResponseDto<ProductDTO?>(dto);
        }
    }
}
