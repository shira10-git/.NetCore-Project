//using DTO;
//using Entities;
//using Microsoft.EntityFrameworkCore;
//using Repositories;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using TestProject;

//namespace UserRepositoryUnitTest
//{
//    public class UserReositoryIntegrationTest:IClassFixture<DatabaseFixture>
//    {
//        private readonly ShopDb325338135Context _dbContext;
//        private readonly UserRepository _userRepository;

//        public UserReositoryIntegrationTest(DatabaseFixture databaseFixture)
//        {
//            _dbContext = databaseFixture.Context;
//            _userRepository = new UserRepository(_dbContext);
//        }

//        [Fact]
//        public async Task Get_User_ValidLogin()
//        {
//            User u = new User();
//            u.UserName = "aaa";
//            u.Password = "1234";


//            LoginDTO loginDto = new LoginDTO();
//            loginDto.Password = "1234";
//            loginDto.UserName = "aaa";

//            await _dbContext.Users.AddAsync(u);
//            await _dbContext.SaveChangesAsync();

//            var result = await _userRepository.Login(loginDto = new LoginDTO()); 

//            Assert.NotNull(result);
//        }

//    }
//}
