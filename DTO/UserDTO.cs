using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO
    {
        public string? UserName { get; set; } 

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Password { get; set; } 

        [EmailAddress(ErrorMessage = "invalid email")]
        public string? Email { get; set; }
    }
}
