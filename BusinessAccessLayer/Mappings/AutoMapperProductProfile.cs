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
    public class AutoMapperProductProfile : Profile
    {
        public AutoMapperProductProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
