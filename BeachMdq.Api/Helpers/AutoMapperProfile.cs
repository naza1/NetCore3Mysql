using AutoMapper;
using BeachMdq.Api.Dtos;
using Entities;

namespace BeachMdq.Api.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterDto, User>();
        }
    }
}
