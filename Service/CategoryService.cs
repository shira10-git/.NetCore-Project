using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        public async Task<List<Category>> Get()
        {
            var category = await _categoryRepository.Get();
            return category;
        }

        public async Task<List<Category>> Get(int id)
        {
            var category = await _categoryRepository.Get(id);
            return category;
        }
    }
}
