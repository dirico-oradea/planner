using AutoMapper;

using Planner.Data.MsSql;
using Planner.DTOs;

using System.Linq;

namespace Planner.Service.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;

        public AuthService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public UserDto GetUserName()
        {
            using var db = new MsSqlContext();

            var user = db.Users.FirstOrDefault();
            var mappedUser = _mapper.Map<UserDto>(user);

            return mappedUser;
        }
    }
}
