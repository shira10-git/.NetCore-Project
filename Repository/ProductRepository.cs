using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository:IProductRepository
    {
        ShopDb325338135Context _shopDbContext;
        public ProductRepository(ShopDb325338135Context shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }
        public async Task<IEnumerable<Product>> Get( string? desc, int? minPrice,int? maxPrice, int?[] categoryIds, int position, int skip)
        {
            var query = _shopDbContext.Products.Include(p=>p.Category).Where(product =>
            (desc == null ? (true) : (product.Description.Contains(desc)))
            && ((minPrice == null) ? (true) : (product.Price >= minPrice))
            && ((maxPrice == null) ? (true) : (product.Price <= maxPrice))
            && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(product.CategoryId))))
                .OrderBy(product => product.Price);
            
            await Console.Out.WriteLineAsync(query.ToQueryString());
            List<Product> products = await query.ToListAsync();
            return products;
        }
    }
}
