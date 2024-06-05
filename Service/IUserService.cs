using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IUserService
    {
        Task<User> Login(LoginDTO user);
        Task<User> Register(User user);
        Task<User> Update(int id, User user);
        Task<User> Get(int id);
        int Check(object password);
        Task<UserDTO> ReturnPrev(int id, UserDTO user);
    }
}
