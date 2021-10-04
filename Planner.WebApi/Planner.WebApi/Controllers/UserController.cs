
using Microsoft.AspNetCore.Mvc;

using Planner.DTOs;
using Planner.Service.Auth;

namespace Planner.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IAuthService _authService;

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

    
    }
}
