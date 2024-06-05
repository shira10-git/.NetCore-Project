using Microsoft.AspNetCore.Mvc;
using Entities;
using Services;
using AutoMapper;
using DTO;
using Azure.Identity;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService userService;
        private IMapper mapper;
        private readonly ILogger<UserController> logger;

        public UserController(IUserService userService,IMapper mapper, ILogger<UserController> logger)
        {
            this.userService = userService;
            this.mapper = mapper;
            this.logger = logger;
        }
        
        [HttpPost("login")]
        public async Task<ActionResult<UserWithIDDTO>> Login([FromBody] LoginDTO userLogin)
        {
            User u = await userService.Login(userLogin);

            UserWithIDDTO userAfter = mapper.Map<User, UserWithIDDTO>(u);
            if (userAfter != null)
            {
                logger.LogInformation($"login attempted with UserName {userAfter.UserName}");
                return Ok(userAfter);
            }   
            return NoContent();
        }


        [HttpPost("register")]
        public async Task<ActionResult<UserWithIDDTO>> Register([FromBody] RegisterDTO userDto)
        {
            var user = mapper.Map<RegisterDTO, User>(userDto);

            User u =await userService.Register(user);
            if (u != null)
            {
                var userToReturn = mapper.Map<User, UserWithIDDTO>(u);
                return CreatedAtAction(nameof(Get), new { id = userToReturn.UserId }, userToReturn);
            }
                
            return NoContent();
        }

        [HttpPost("check")]
        public ActionResult Check([FromBody] object password)
        {
            
            var result = userService.Check(password);
            if (result >= 2)
                return Ok(result);
            return Accepted(result);
        }

        [HttpGet("{id}")]
        public async Task<UserDTO> Get(int id)
        {
            var user = await userService.Get(id);
            var userToReturn = mapper.Map<User, UserDTO>(user);
            return userToReturn;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDTO>> Update(int id, [FromBody] UserDTO user)
        {
            UserDTO prevUser=await userService.returnPrev(id,user);

            User userAfter = mapper.Map<UserDTO, User>(prevUser);

            User u =await userService.Update(id, userAfter);
            if (u != null)
            {
                UserDTO uu = mapper.Map<User, UserDTO>(u);
                return Ok(uu);
            }     
            return NoContent();
        } 
    }
}
