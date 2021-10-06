using Planner.DTOs;

namespace Planner.Service.Auth
{
    public interface IAuthService
    {
        UserDto GetUserName();

        string Create(UserDto userDto);

        
    }
}
