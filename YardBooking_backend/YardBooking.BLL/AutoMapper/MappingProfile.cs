using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.BLL.Dtos.team;
using YardBooking.BLL.Dtos.user;
using YardBooking.DAL.Data.Models;

namespace YardBooking.BLL.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapping for Team DTOs
            CreateMap<User, TeamReadDto>().ReverseMap();
            CreateMap<User, TeamUpdateDto>().ReverseMap();
            
            // Mapping for User DTOs
            CreateMap<User, UserReadDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
            CreateMap<User, UserCreateDto>().ReverseMap();
        }
    }
}
