using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessAccessLayer.DTOs;
using DataAccessLayer.Entities;

namespace BusinessAccessLayer.Mappings
{
    public class AutoMapperUserProfile : Profile
    {
        public AutoMapperUserProfile()
        {
            CreateMap<UserDTO, User>()
                .ForMember(dest => dest.UserHashedPassword, opt => opt.MapFrom(src => src.UserPassword))
                .ReverseMap();

            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.UserPassword, opt => opt.MapFrom(src => src.UserHashedPassword))
                .ReverseMap();
        }
    }
}
