using DTO;
using Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using Repositories;
using System.Linq.Expressions;

namespace TestProjectMyShop
{
    public class UserRepositoryUnitTest
    {
        [Fact]
        public async Task TestLogin_ValidUser_ReturnsUserObject()
        {
            // Arrange
            var mockDbContext = new Mock<ShopDb325338135Context>();
            var testUser = new User { UserName = "testuser", Password = "testpassword" };
            var testLoginDto = new LoginDTO { UserName = "testuser", Password = "testpassword" };

            mockDbContext.Setup(m => m.Users).ReturnsDbSet(new List<User> { testUser });
            var service = new UserRepository(mockDbContext.Object);

            // Act
            var result = await service.Login(testLoginDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(testUser.UserName, result.UserName);
            Assert.Equal(testUser.Password, result.Password);
        }

        [Fact]
        public async Task TestLogin_InvalidUser_ReturnsNull()
        {
            // Arrange
            var mockDbContext = new Mock<ShopDb325338135Context>();
            var testUser = new User { UserName = "testuser", Password = "testpassword" };
            var testLoginDto = new LoginDTO { UserName = "nonexistentuser", Password = "invalidpassword" };

            mockDbContext.Setup(m => m.Users).ReturnsDbSet(new List<User> { testUser });
            var service = new UserRepository(mockDbContext.Object);

            // Act
            var result = await service.Login(testLoginDto);

            // Assert
            Assert.Null(result);
        }


        [Fact]
        public async Task TestRegister_NewUser_Success()
        {
            // Arrange
            var mockDbContext = new Mock<ShopDb325338135Context>();

            var user = new User { UserName = "newuser", Password = "password123", FirstName = "aaa", LastName = "aaa" };
            var userReg = new User { UserName = "aaa", Password = "aaa", FirstName = "aaa", LastName = "aaa" };
            mockDbContext.Setup(m => m.Users).ReturnsDbSet(new List<User> { user });
            var service = new UserRepository(mockDbContext.Object);

            // Act
            var result = await service.Register(userReg);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userReg.UserName, result.UserName);
        }

        [Fact]
        public async Task TestRegister_NewUser_InSuccess()
        {
            // Arrange
            var mockDbContext = new Mock<ShopDb325338135Context>();
            var user = new User { UserName = "aaa", Password = "aaa", FirstName = "aaa", LastName = "aaa" };
            var userReg = new User { UserName = "aaa", Password = "aaa", FirstName = "aaa", LastName = "aaa" };
            mockDbContext.Setup(m => m.Users).ReturnsDbSet(new List<User> { user });
            var service = new UserRepository(mockDbContext.Object);

            // Act
            var result = await service.Register(userReg);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task TestUpdate_ExistingUser_Success()
        {
            // Arrange
            int userId = 1;
            var existingUser = new User { UserId = userId, UserName = "olduser", Password = "oldpassword" };
            var updatedUser = new User { UserId = userId, UserName = "newuser", Password = "newpassword" };

            var mockDbContext = new Mock<ShopDb325338135Context>();
            mockDbContext.Setup(m => m.Users).ReturnsDbSet(new List<User> { existingUser });

            var userRepository = new UserRepository(mockDbContext.Object);

            // Act
            var result = await userRepository.Update(userId, updatedUser);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(updatedUser.UserName, result.UserName);
            Assert.Equal(updatedUser.Password, result.Password);
        }
    }
}
