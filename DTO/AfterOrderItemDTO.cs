﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AfterOrderItemDTO
    {
        public int OrderItemId { get; set; }

        public int? ProductId { get; set; }

        public int? OrderId { get; set; }

        public int? Quentity { get; set; }
    }
}
