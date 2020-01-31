using AutoMapper;
using Entities;
using Registration_Login_Api.Dtos;

namespace Registration_Login_Api.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterDto, User>();
        }
    }
}
