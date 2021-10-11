
using Microsoft.AspNetCore.Mvc;

using Planner.DTOs;
using Planner.Service.Auth;

namespace Planner.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthService _authService;

        public UserController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        [Route("api/getUser")]
        public ActionResult<UserDto> getUserProfile([FromHeader] string token)
        {
            UserDto user = _authService.GetUser(token);
            return user != null ? user : Unauthorized();
        }

        [HttpPost]
        [Route("api/register")]
        public ActionResult<string> Register([FromBody] UserDto userDto)
        {
            return _authService.Create(userDto);
        }

        [HttpPost]
        [Route("api/login")]
        public ActionResult<string> Login([FromBody] LoginUser loginUser)
        {
            return _authService.Login(loginUser);
        }
    }
}
