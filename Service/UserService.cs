using Entities;
using Repositories;
using DTO;

namespace Services
{
    public class UserService: IUserService
    {
        private IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        async Task<User> IUserService.Update(int id, User user)
        {
            var checkStrength = Check(user.Password);
            if (checkStrength < 2)
                return null;
            User u=await userRepository.Update(id,user);
            return u;
        }
        async Task<User> IUserService.Login(LoginDTO userLogin)
        {
            User u = await userRepository.Login(userLogin);
            return u;
        }
        async Task<User> IUserService.Register(User user)
        {
            var checkStrength = Check(user.Password);
            if (checkStrength < 2)
                return null;
            User u = await userRepository.Register(user);
            return u;
        }

        public async Task<User> Get(int id)
        {
            return await userRepository.Get(id) ;
        }
        public int Check(object password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password.ToString());
            return result.Score;
        }
    }
}
