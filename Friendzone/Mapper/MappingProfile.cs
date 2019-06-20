using AutoMapper;
using Entities;
using Friendzone.Core.DTO;
using Friendzone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Friendzone.Web.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.Email))
                .ForMember(dest => dest.UserName, opts => opts.MapFrom(src => src.UserName));
                
            CreateMap<UserDTO, User>()
                .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.Email))
                .ForMember(dest => dest.UserName, opts => opts.MapFrom(src => src.UserName));

            CreateMap<LoginModel, UserDTO>()
                .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opts => opts.MapFrom(src => src.Password));

            CreateMap<RegisterModel, UserDTO>()
                 .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.Email))
                 .ForMember(dest => dest.Password, opts => opts.MapFrom(src => src.Password))
                 .ForMember(dest => dest.UserName, opts => opts.MapFrom(src => src.Login))
                 .ForMember(dest => dest.Role, opts => opts.MapFrom(src => "user"));

            CreateMap<UserProfileEditModel, ProfileDTO>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.Email))
                .ForMember(dest => dest.UserName, opts => opts.MapFrom(src => src.UserName))
                .ForMember(dest => dest.PhoneNumber, opts => opts.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Birthday, opts => opts.MapFrom(src => src.Birthday))
                .ForMember(dest => dest.City, opts => opts.MapFrom(src => src.City));

            CreateMap<ProfileDTO, UserProfile>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Birthday, opts => opts.MapFrom(src => src.Birthday))
                .ForMember(dest => dest.Avatar, opts => opts.MapFrom(src => src.Avatar))
                .ForMember(dest => dest.City, opts => opts.MapFrom(src => src.City))
                .ForPath(dest => dest.User.Email, opts => opts.MapFrom(src => src.Email))
                .ForPath(dest => dest.User.PhoneNumber, opts => opts.MapFrom(src => src.PhoneNumber))
                .ForPath(dest => dest.User.UserName, opts => opts.MapFrom(src => src.UserName))
                ;

            CreateMap<UserProfile, ProfileDTO>()
                .ForMember(dest => dest.Birthday, opts => opts.MapFrom(src => src.Birthday))
                .ForMember(dest => dest.Avatar, opts => opts.MapFrom(src => src.Avatar))
                .ForMember(dest => dest.UserName, opts => opts.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.PhoneNumber, opts => opts.MapFrom(src => src.User.PhoneNumber))

        }
    }
}
