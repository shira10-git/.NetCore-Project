using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderReturnDTO
    {
        public int OrderId { get; set; }

        public DateTime? OrderDate { get; set; }

        public int? OrderSum { get; set; }

        public int? UserId { get; set; }
    }
}
