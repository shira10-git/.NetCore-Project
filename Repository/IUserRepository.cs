using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IUserRepository
    {
        Task<User> Login(LoginDTO user);
        Task<User> Register(User user);
        Task<User> Update(int id,User user);
        Task<User> Get(int id);
    }
}
