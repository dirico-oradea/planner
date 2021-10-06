
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
        [Route("")]
        public ActionResult<UserDto> GetuserName()
        {
            return _authService.GetUserName();
        }

        [HttpPost]
        [Route("api/register")]
        public ActionResult<string> Register([FromBody] UserDto userDto)
        {
            return _authService.Create(userDto);
        }
    }
}
