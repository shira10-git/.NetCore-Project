using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO
    {
        public string UserName { get; set; } = null!;

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string Password { get; set; } = null!;

        public string? Email { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
