using DTO;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
namespace Repositories
{
    public class UserRepository: IUserRepository
    {
        ShopDb325338135Context shopDbContext;
        public UserRepository(ShopDb325338135Context shopDbContext)
        {
            this.shopDbContext = shopDbContext;
        }

        public async Task<User> Login(LoginDTO userLogin)
        {
            User userDb= await shopDbContext.Users.FirstOrDefaultAsync(u => userLogin.UserName.Equals(u.UserName)&& userLogin.Password.Equals(u.Password));
            if(userDb==null)
            {
                return null;
            }
            return userDb;
        }
        public async Task<User> Register(User user)
        {
            var userDb = await shopDbContext.Users.FirstOrDefaultAsync(u=>user.UserName.Equals(u.UserName));
                
            if (userDb != null)
            {
                return null;  
            }

            await shopDbContext.Users.AddAsync(user);
            await shopDbContext.SaveChangesAsync();
            return user;
        }
        public async Task<User> Update(int id,User user)
        {
            var userDb=await shopDbContext.Users.FirstOrDefaultAsync(u => u.UserId==id);
            if (userDb == null)
                return null;
           
            userDb.UserName = user.UserName;
            userDb.Password = user.Password;
            userDb.FirstName = user.FirstName;
            userDb.LastName = user.LastName;
            userDb.Email = user.Email;

            await shopDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> Get(int id)
        {
            var user = await shopDbContext.Users.FindAsync(id);
            return user;
        }
 
    }
}
