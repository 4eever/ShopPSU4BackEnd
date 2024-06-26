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
    public class AutoMapperOrderItemProfile : Profile
    {
        public AutoMapperOrderItemProfile()
        {
            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
        }
    }
}
