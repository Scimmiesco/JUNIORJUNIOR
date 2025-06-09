using JJ.APPLICATION.DTOs;
using JJ.APPLICATION.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace JJ.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IServiceProduct productService) : ControllerBase
    {
        private readonly IServiceProduct _productService = productService;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var productsDto = await _productService.GetAllProductsAsync();

                return Ok(productsDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro interno. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpGet("Paginated")]
        public async Task<ActionResult<PaginatedResponseDto<ProductDTO>>> GetAllPaginated([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                if (pageNumber.Equals(0) || pageSize.Equals(0))
                    return BadRequest(new PaginatedResponseDto<ProductDTO>("Os parâmetros pageNumber e pageSize devem ser maiores que zero."));

                return await _productService.GetAllPaginatedProductsAsync(pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                return new PaginatedResponseDto<ProductDTO>("Ocorreu um erro interno. Por favor, tente novamente mais tarde");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<DataResponseDto<ProductDTO>>> GetByID(int id)
        {
            try
            {
                var productDto = await _productService.GetProductByIdAsync(id);

                if (productDto == null)
                {
                    return NotFound();
                }

                return Ok(productDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro interno. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<DataResponseDto<ProductDTO>>> Create([FromBody] CreateUpdateProductDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Os dados do produto não podem ser nulos.");
            }

            try
            {
                var createdProductDto = await _productService.CreateProductAsync(dto);

                return Ok(createdProductDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro interno. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deletedProduct = await _productService.DeleteProductAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro interno. Por favor, tente novamente mais tarde.");
            }
        }
    }
}