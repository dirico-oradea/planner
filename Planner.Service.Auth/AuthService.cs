using AutoMapper;

using Planner.Data.Domain;
using Planner.DTOs;

using System.Linq;

namespace Planner.Service.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public AuthService(
            IMapper mapper,
            DataContext context
        )
        {
            _mapper = mapper;
            _context = context;
        }

        public UserDto GetUserName()
        {
            var user = _context.Users.FirstOrDefault();
            if (user == null) {
                var userDto = new UserDto() {
                    FullName = "I am a test user in authService",
                    FirstName = "I am a",
                    LastName = "Test in authService"
                };
                return userDto;
            }
            var mappedUser = _mapper.Map<UserDto>(user);

            return mappedUser;
        }
    }
}
