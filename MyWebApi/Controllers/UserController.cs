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
        private IUserService _userService;
        private IMapper _mapper;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService,IMapper mapper, ILogger<UserController> logger)
        {
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
        }
        
        [HttpPost("login")]
        public async Task<ActionResult<UserWithIDDTO>> Login([FromBody] LoginDTO userLogin)
        {
            User u = await _userService.Login(userLogin);

            UserWithIDDTO userAfter = _mapper.Map<User, UserWithIDDTO>(u);
            if (userAfter != null)
            {
                _logger.LogInformation($"login attempted with UserName {userAfter.UserName}");
                return Ok(userAfter);
            }   
            return NoContent();
        }


        [HttpPost("register")]
        public async Task<ActionResult<UserWithIDDTO>> Register([FromBody] RegisterDTO userDto)
        {
            var user = _mapper.Map<RegisterDTO, User>(userDto);

            User u =await _userService.Register(user);
            if (u != null)
            {
                var userToReturn = _mapper.Map<User, UserWithIDDTO>(u);
                return CreatedAtAction(nameof(Get), new { id = userToReturn.UserId }, userToReturn);
            }
                
            return NoContent();
        }

        [HttpPost("check")]
        public ActionResult Check([FromBody] object password)
        {
            
            var result = _userService.Check(password);
            if (result >= 2)
                return Ok(result);
            return Accepted(result);
        }

        [HttpGet("{id}")]
        public async Task<UserDTO> Get(int id)
        {
            var user = await _userService.Get(id);
            var userToReturn = _mapper.Map<User, UserDTO>(user);
            return userToReturn;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDTO>> Update(int id, [FromBody] UserDTO user)
        {
            UserDTO prevUser=await _userService.ReturnPrev(id,user);

            User userAfter = _mapper.Map<UserDTO, User>(prevUser);

            User u =await _userService.Update(id, userAfter);
            if (u != null)
            {
                UserDTO uu = _mapper.Map<User, UserDTO>(u);
                return Ok(uu);
            }     
            return NoContent();
        } 
    }
}
