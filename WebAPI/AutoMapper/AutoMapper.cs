using AutoMapper;
using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<User, UserDto>();
        }
    }
}
