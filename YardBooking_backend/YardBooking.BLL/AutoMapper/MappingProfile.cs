using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.BLL.Dtos.AccountDto;
using YardBooking.BLL.Dtos.Booking;
using YardBooking.BLL.Dtos.Offer;
using YardBooking.BLL.Dtos.Payment;
using YardBooking.BLL.Dtos.Schedule;
using YardBooking.BLL.Dtos.team;
using YardBooking.BLL.Dtos.TeamBooking;
using YardBooking.BLL.Dtos.TeamMember;
using YardBooking.BLL.Dtos.user;
using YardBooking.BLL.Dtos.Yard;
using YardBooking.DAL.Data.Models;

namespace YardBooking.BLL.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Auth & User mappings
            CreateMap<RegisterDto, ApplicationUser>();
            CreateMap<ApplicationUser, UserDto>();

            // Yard mappings
            CreateMap<Yard, YardDto>();
            

            // Team mappings
            CreateMap<Team, TeamDto>();
                //.ForMember(dest => dest.CaptainName, opt => opt.MapFrom(src => src.Captain.Name));
            CreateMap<CreateTeamDto, Team>();
            CreateMap<UpdateTeamDto, Team>();

            // TeamMember mappings
            CreateMap<TeamMember, TeamMemberDto>();
                //.ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name))
                //.ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Team.TeamName));

            // Schedule mappings
            CreateMap<Schedule, ScheduleDto>();
            CreateMap<CreateScheduleDto, Schedule>();
            CreateMap<UpdateScheduleDto, Schedule>();

            

            // Booking mappings
            CreateMap<Booking, BookingDto>();
            CreateMap<CreateBookingDto, Booking>();
            CreateMap<UpdateBookingDto, Booking>();

            // TeamBooking mappings
            CreateMap<TeamBooking, TeamBookingDto>()
                .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Team.TeamName));

            // Payment mappings
            CreateMap<Payment, PaymentDto>();
            CreateMap<CreatePaymentDto, Payment>();
            CreateMap<UpdatePaymentDto, Payment>();

            // Offer mappings
            CreateMap<Offer, OfferDto>();
            CreateMap<CreateOfferDto, Offer>();
            CreateMap<UpdateOfferDto, Offer>();

            // Booking mappings
            CreateMap<Booking, BookingDto>();
            CreateMap<CreateBookingDto, Booking>();
            CreateMap<UpdateBookingDto, Booking>();

            // Yard -> YardDto
            CreateMap<Yard, YardDto>()
                .ForMember(dest => dest.OwnerName, opt => opt.MapFrom(src =>
                    src.Owner != null && src.Owner.User != null ? src.Owner.User.Name : string.Empty));

            // YardCreateDto -> Yard
            CreateMap<YardCreateDto, Yard>();

            // YardUpdateDto -> Yard
            CreateMap<YardUpdateDto, Yard>();
        }
    }
}
