using Planner.DTOs;

namespace Planner.Service.Auth
{
    public interface IAuthService
    {
        UserDto GetUser(string token);

        string Create(UserDto userDto);

        string Login(LoginUser loginUser);
    }
}
