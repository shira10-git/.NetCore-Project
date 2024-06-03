using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService productService;
        private IMapper mapper;
        private readonly ILogger<ProductController> logger;

        public ProductController(IProductService productService,IMapper mapper, ILogger<ProductController> logger)
        {
            this.productService = productService;
            this.mapper = mapper;
            this.logger = logger;
        } 

        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>>Get([FromQuery] string? desc, [FromQuery] int? minPrice, [FromQuery] int? maxPrice,[FromQuery] int?[] categoryIds, int position = 1, int skip = 20)
        {

            var result= await productService.Get( desc, minPrice, maxPrice, categoryIds, position, skip);
            if (result != null)
            {
                var productsDto = mapper.Map<List<Product>, List<ProductDTO>>((List<Product>)result);
                if (productsDto.Count()>0)
                {
                    
                    //logger.LogError($"get product error!!!");
                    return Ok(productsDto);
                }
            }      
            return NoContent();
        }


    }
}
