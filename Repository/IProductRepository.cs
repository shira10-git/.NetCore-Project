using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> Get( string? desc, int? minPrice, int? maxPrice, int?[] categoryIds, int position, int skip);

    }
}
