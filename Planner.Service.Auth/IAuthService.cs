using Planner.DTOs;

namespace Planner.Service.Auth
{
    public interface IAuthService
    {
        UserProfile GetUser(string token);

        string Create(UserDto userDto);

        string Login(LoginUser loginUser);

        string Logout(string token);

        UserProfile Update(UserProfile user, string token);
    }
}
