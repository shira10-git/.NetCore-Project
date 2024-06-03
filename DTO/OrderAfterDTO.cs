using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderAfterDTO
    {
        public int UserId { get; set; }
        public virtual ICollection<AfterOrderItemDTO> OrderItems { get; set; } = new List<AfterOrderItemDTO>();
    }
}
