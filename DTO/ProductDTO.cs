using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public double? Price { get; set; }

        public string? Description { get; set; }

        public int? CategoryId { get; set; }

        public string? Image { get; set; }

        public virtual string? Category { get; set; }
    }
}
