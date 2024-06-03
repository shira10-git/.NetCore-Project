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
        private ICategoryService categoryService;
        private IMapper mapper;
        private readonly ILogger<CategoryController> logger;
        public CategoryController(ICategoryService categoryService, IMapper mapper, ILogger<CategoryController> logger)
        {
            this.categoryService = categoryService;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        
        public async Task<ActionResult<List<Category>>> Get()
        {
            var category = await categoryService.Get();
            //var categoryDto = mapper.Map<List<Category>, List<CategoryDTO>>(category);
            if (category.Count()>0)
                return Ok(category);
            return NoContent();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<List<Category>>> Get(int id)
        {
            try
            {
            var category = await categoryService.Get(id);
                if (category != null)
                    return Ok(category);
                return NoContent();
            }
            catch(Exception e)
            {
                logger.LogError($"get categoryById error {e}");
            }
            return null;
        }

    }
}
