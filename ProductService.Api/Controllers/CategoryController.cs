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
    public class CategoryController : ControllerBase
    {
        private readonly IGenericRepository<Category> _repo;
        private readonly IMapper _mapper;

        public CategoryController(IGenericRepository<Category> repo, IMapper mapper) 
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _repo.GetAll();
            var categoryDtos = _mapper.Map<List<CategoryDto>>(categories);

            return Ok(categoryDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var category = await _repo.GetById(id);
            if (category == null)
            {
                return NotFound($"Category with ID '{id}' not found.");
            }

            var categoryDto = _mapper.Map<CategoryDto>(category);
            return Ok(categoryDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);

            var addedCategory = await _repo.Add(category);
            var addedCategoryDto = _mapper.Map<CategoryDto>(addedCategory);

            return CreatedAtAction(nameof(GetById), new { id = addedCategoryDto.Id }, addedCategoryDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, CategoryDto categoryDto)
        {
            if (id != categoryDto.Id)
            {
                return BadRequest("Category ID mismatch.");
            }

            var category = _mapper.Map<Category>(categoryDto);
            var updatedCategory = await _repo.Update(category);

            if (updatedCategory == null)
            {
                return NotFound($"Category with ID '{id}' not found.");
            }

            var updatedCategoryDto = _mapper.Map<CategoryDto>(updatedCategory);
            return Ok(updatedCategoryDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _repo.Delete(id);
            if (!deleted)
            {
                return NotFound($"Category with ID '{id}' not found.");
            }

            return NoContent();
        }
    }
}
