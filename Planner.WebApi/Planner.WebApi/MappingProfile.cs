using AutoMapper;

using Planner.Data.Models;
using Planner.DTOs;

namespace Planner.WebApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dst => dst.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName));

            CreateMap<UserDto, User>();

        }
    }
}
