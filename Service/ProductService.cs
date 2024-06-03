using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService:IProductService
    {
        private IProductRepository productRepository;
        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Get( string? desc, int? minPrice, int? maxPrice, int?[] categoryIds, int position, int skip)
        {
            return  await productRepository.Get(desc, minPrice, maxPrice, categoryIds, position, skip);  
        }

        

    }
}
