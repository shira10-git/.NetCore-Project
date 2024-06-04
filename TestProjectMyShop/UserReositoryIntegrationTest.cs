using DTO;
using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class UserIntegreationTesr : IClassFixture<DatabaseFixture>
    {
        private readonly ShopDb325338135Context _dbontext;
        private readonly UserRepository userRepository;

        public UserIntegreationTesr(DatabaseFixture databaseFixture)
        {
            _dbontext = databaseFixture.Context;
            userRepository = new UserRepository(_dbontext);

        }
        [Fact]
        public async Task GetUser_Valid_returnsUser()
        {
            var username = "aaa";
            var password = "a123s123";
            var login = new LoginDTO { Password = password,  UserName = username };
            var user = new User { Email = "aaa@gmail.com", Password = password, FirstName = "SHEVA", LastName = "KAPLAN", UserName = username };

            await _dbontext.Users.AddAsync(user);
            await _dbontext.SaveChangesAsync();

            //act
            var result = await userRepository.Login(login);

            //assert

            Assert.NotNull(result);
        }


    }
}
