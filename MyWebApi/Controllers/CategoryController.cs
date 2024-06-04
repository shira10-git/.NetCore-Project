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
        public async Task<ActionResult<List<Category>>> GetAllCategories()
        {
            var categories = await _categoryService.Get();

            if (categories.Any())
            {
                return Ok(categories);
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            try
            {
                var category = await _categoryService.Get(id);

                if (category != null)
                {
                    return Ok(category);
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