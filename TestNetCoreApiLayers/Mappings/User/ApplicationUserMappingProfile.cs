using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestNetCore.Core.Dto;

namespace TestNetCore.Api.Mappings.User
{
    public class ApplicationUserMappingProfile : Profile
    {
        public ApplicationUserMappingProfile()
        {
            CreateMap<CreateUserDto, Core.Model.ApplicationUser>()
                    .ForMember(dest => dest.User, opt => opt.MapFrom(src => src))
                    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Nickname))
                    .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Phones.FirstOrDefault()))
                    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                    .ReverseMap();

            CreateMap<ApplicationUserDto, Core.Model.ApplicationUser>()
                 .ForMember(dest => dest.User, opt => opt.MapFrom(src => src))
                 .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Username))
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                 .ForMember(x => x.User, opt => opt.Ignore())                 
                //.ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Nickname))
                //.ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Phones.FirstOrDefault()))
                //.ForMember(dest => dest.NormalizedEmail, opt => opt.MapFrom(src => src.Email))
                //.ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password))
                //.ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                 .ReverseMap();

            CreateMap<LoginUserDto, Core.Model.ApplicationUser>()
                 .ForMember(dest => dest.User, opt => opt.MapFrom(src => src))
                 .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Nickname))
                 //.ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password))
                 .ReverseMap();


            CreateMap<Core.Model.User, ApplicationUserDto>()
               .ReverseMap();

            CreateMap<Core.Model.User, LoginUserDto>()
             .ReverseMap();

            CreateMap<Core.Model.User, CreateUserDto>()
            .ReverseMap();

        }
    }
}
