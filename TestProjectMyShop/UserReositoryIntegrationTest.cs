using DTO;
using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectMyShop
{
    public class UserIntegreationTesr : IClassFixture<DatabaseFixture>
    {
        private readonly ShopDb325338135Context _dbontext;
        private readonly UserRepository _userRepository;

        public UserIntegreationTesr(DatabaseFixture databaseFixture)
        {
            _dbontext = databaseFixture.Context;
            _userRepository = new UserRepository(_dbontext);
        }
        [Fact]
        public async Task GetUser_Valid_returnsUser()
        {
            var username = "shira";
            var password = "ss1122ss";
            var login = new LoginDTO { Password = password,  UserName = username };
            var user = new User { Email = "aaa@gmail.com", Password = password, FirstName = "Shira", LastName = "Stern", UserName = username };

            await _dbontext.Users.AddAsync(user);
            await _dbontext.SaveChangesAsync();

            //act
            var result = await _userRepository.Login(login);

            //assert

            Assert.NotNull(result);
        }
    }
}
