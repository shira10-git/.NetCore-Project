using DTO;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
namespace Repositories
{
    public class UserRepository: IUserRepository
    {
        ShopDb325338135Context _shopDbContext;
        public UserRepository(ShopDb325338135Context shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }

        public async Task<User> Login(LoginDTO userLogin)
        {
            User userDb= await _shopDbContext.Users.FirstOrDefaultAsync(u => userLogin.UserName.Equals(u.UserName)&& userLogin.Password.Equals(u.Password));
            if(userDb==null)
            {
                return null;
            }
            return userDb;
        }
        public async Task<User> Register(User user)
        {
            var userDb = await _shopDbContext.Users.FirstOrDefaultAsync(u=>user.UserName.Equals(u.UserName));
                
            if (userDb != null)
            {
                return null;  
            }

            await _shopDbContext.Users.AddAsync(user);
            await _shopDbContext.SaveChangesAsync();
            return user;
        }
        public async Task<User> Update(int id,User user)
        {
            var userDb=await _shopDbContext.Users.FirstOrDefaultAsync(u => u.UserId==id);
            if (userDb == null)
                return null;
           
            userDb.UserName = user.UserName;
            userDb.Password = user.Password;
            userDb.FirstName = user.FirstName;
            userDb.LastName = user.LastName;
            userDb.Email = user.Email;

            await _shopDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> Get(int id)
        {
            var user = await _shopDbContext.Users.FindAsync(id);
            return user;
        }
 
    }
}
