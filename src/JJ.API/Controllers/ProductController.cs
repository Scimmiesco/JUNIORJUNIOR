using JJ.APPLICATION.DTOs;
using JJ.APPLICATION.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JJ.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IServiceProduct productService) : ControllerBase
    {
        private readonly IServiceProduct _productService = productService;

        [HttpGet]
        public async Task<ActionResult<DataResponseDto<ProductDTO[]>>> GetAll()
        {
            try
            {
                var productsDto = await _productService.GetAllProductsAsync();
                return Ok(productsDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new DataResponseDto<ProductDTO[]>("Ocorreu um erro interno. Por favor, tente novamente mais tarde."));
            }
        }

        [HttpGet("Paginated")]
        public async Task<ActionResult<PaginatedResponseDto<ProductDTO>>> GetAllPaginated([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                if (pageNumber <= 0 || pageSize <= 0)
                    return BadRequest(new PaginatedResponseDto<ProductDTO>("Os parâmetros pageNumber e pageSize devem ser maiores que zero."));

                var result = await _productService.GetAllPaginatedProductsAsync(pageNumber, pageSize);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new PaginatedResponseDto<ProductDTO>("Ocorreu um erro interno. Por favor, tente novamente mais tarde."));
            }
        }

        [HttpGet("{id:int}", Name = "GetProductById")]
        public async Task<ActionResult<DataResponseDto<ProductDTO>>> GetByID(int id)
        {
            try
            {
                var productDto = await _productService.GetProductByIdAsync(id);

                if (productDto.Data == null)
                {
                    return NotFound(new DataResponseDto<ProductDTO>("Produto com o ID fornecido não foi encontrado."));
                }

                return Ok(productDto);
            }
            catch (ArgumentException arg)
            {
                return BadRequest(new DataResponseDto<ProductDTO>(arg.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new DataResponseDto<ProductDTO>("Ocorreu um erro interno. Por favor, tente novamente mais tarde."));
            }
        }

        [HttpPost]
        public async Task<ActionResult<DataResponseDto<ProductDTO>>> Create([FromBody] CreateUpdateProductDTO dto)
        {
            try
            {
                var createdProductDto = await _productService.CreateProductAsync(dto);

                return CreatedAtAction(nameof(GetByID), new { id = createdProductDto.Data.Id }, createdProductDto);
            }
            catch (ArgumentException arg)
            {
                return BadRequest(new DataResponseDto<ProductDTO>(arg.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new DataResponseDto<ProductDTO>("Ocorreu um erro interno. Por favor, tente novamente mais tarde."));
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _productService.DeleteProductAsync(id);
                return NoContent();
            }
            catch (ArgumentException arg)
            {
                return NotFound(new ResponseDto(arg.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDto("Ocorreu um erro interno. Por favor, tente novamente mais tarde."));
            }
        }
    }
}