﻿using AutoMapper;
using Entities;
using Registration_Login_Api.Dtos;

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