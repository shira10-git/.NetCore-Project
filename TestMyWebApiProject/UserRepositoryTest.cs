//using DTO;
//using Entities;
//using Microsoft.EntityFrameworkCore;
//using Moq;
//using Repositories;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;

//namespace TestMyWebApiProject
//{
//    public class UserRepositoryTest
//    {
//        [Fact]
//        public async Task TestLogin_ValidUser_ReturnsUserObject()
//        {
//            // Arrange
//            var mockDbContext = new Mock<ShopDb325338135Context>();
//            var testUser = new User { UserName = "testuser", Password = "testpassword" };
//            var testLoginDto = new LoginDTO { UserName = "testuser", Password = "testpassword" };

//            mockDbContext.Setup(m => m.Users.FirstOrDefaultAsync(It.IsAny<Expression<Func<User, bool>>>()))
//                         .ReturnsAsync(testUser);
//            var service = new UserRepository(mockDbContext.Object);

//            // Act
//            var result = await service.Login(testLoginDto);

//            // Assert
//            Assert.NotNull(result);
//            Assert.Equal(testUser, result);
//        }

//        [Fact]
//        public async Task TestLogin_InvalidUser_ReturnsNull()
//        {
//            // Arrange
//            var mockDbContext = new Mock<ShopDb325338135Context>();
//            User nullUser = List<User>;
//            var testLoginDto = new LoginDTO { UserName = "nonexistentuser", Password = "invalidpassword" };

//            mockDbContext.Setup(m => m.Users).ReturnsDbSet(testLoginDto);
//            var service = new UserRepository(mockDbContext.Object);

//            // Act
//            var result = await service.Login(testLoginDto);

//            // Assert
//            Assert.Null(result);
//        }
//    }
//}
