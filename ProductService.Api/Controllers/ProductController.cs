using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.Contracts;
using ProductService.Application.Dtos;
using ProductService.Domain;

namespace ProductService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _repo.GetAll();
            var productDtos = _mapper.Map<List<ProductDto>>(products);

            return Ok(productDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await _repo.GetById(id);
            if (product == null)
            {
                return NotFound($"Product with ID '{id}' not found.");
            }

            var productDto = _mapper.Map<ProductDto>(product);
            return Ok(productDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);

            var addedProduct = await _repo.Add(product);
            var addedProductDto = _mapper.Map<ProductDto>(addedProduct);

            return CreatedAtAction(nameof(GetById), new { id = addedProductDto.Id }, addedProductDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, ProductDto productDto)
        {
            if (id != productDto.Id)
            {
                return BadRequest("Product ID mismatch.");
            }

            var product = _mapper.Map<Product>(productDto);
            var updatedProduct = await _repo.Update(product);

            if (updatedProduct == null)
            {
                return NotFound($"Product with ID '{id}' not found.");
            }

            var updatedProductDto = _mapper.Map<ProductDto>(updatedProduct);
            return Ok(updatedProductDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _repo.Delete(id);
            if (!deleted)
            {
                return NotFound($"Product with ID '{id}' not found.");
            }

            return NoContent();
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetByCategory(Guid categoryId)
        {
            var products = await _repo.GetByCategory(categoryId);
            var productDtos = _mapper.Map<List<ProductDto>>(products);

            return Ok(productDtos);
        }
    }
}
