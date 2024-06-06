using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
using Zxcvbn;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ICategoryService categoryService, IMapper mapper, ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDTO>>> GetAllCategories()
        {
            var categories = await _categoryService.Get();

            if (categories.Any())
            {
                var categoriesDto = _mapper.Map<List<Category>, List<CategoryDTO>>(categories);
                return Ok(categoriesDto);
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetCategoryById(int id)
        {
            try
            {
                var category = await _categoryService.Get(id);

                if (category != null)
                {
                    var returnCategory = _mapper.Map<Category, CategoryDTO>(category);
                    return Ok(returnCategory);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving category by ID: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}