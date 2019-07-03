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
            CreateMap<User, UserDTO>();
                
            CreateMap<UserDTO, User>();
            
            CreateMap<LoginModel, UserDTO>();
                
            CreateMap<RegisterModel, UserDTO>()
                 .ForMember(dest => dest.UserName, opts => opts.MapFrom(src => src.Login))
                 .ForMember(dest => dest.Role, opts => opts.MapFrom(src => "user"));

            CreateMap<UserProfileEditModel, ProfileDTO>();
               
            CreateMap<ProfileDTO, UserProfileViewModel>()
                .ForMember(dest => dest.City, opts => opts.MapFrom(src => src.City.Name))
                .ForMember(dest => dest.Age, opts => opts.MapFrom(src => (DateTime.Today.Year - src.Birthday.Year)));

            CreateMap<ProfileDTO, UserProfilePreviewModel>()
                .ForMember(dest => dest.AvatarUrl, opts => opts.MapFrom(src => src.AvaUrl));

            CreateMap<ProfileDTO, UserProfile>()
                .ForPath(dest => dest.User.Email, opts => opts.MapFrom(src => src.Email))
                .ForPath(dest => dest.User.PhoneNumber, opts => opts.MapFrom(src => src.PhoneNumber))
                .ForPath(dest => dest.User.UserName, opts => opts.MapFrom(src => src.UserName));

            CreateMap<UserProfile, ProfileDTO>()
                .ForMember(dest => dest.UserName, opts => opts.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.PhoneNumber, opts => opts.MapFrom(src => src.User.PhoneNumber))
                .ForMember(dest => dest.AvaUrl, opts => opts.MapFrom(src => src.Avatar.Url));

            CreateMap<EventEditViewModel, EventDTO>();
                
            CreateMap<EventDTO, Event>();

            CreateMap<Event, EventDTO>()
                .ForMember(dest => dest.CategoryIds, opt => opt.MapFrom(src => src.EventCategory.Select(x => x.CategoryId)))
                .ForMember(dest => dest.CategoryNames, opt => opt.MapFrom(src => src.EventCategory.Select(x => x.Category.Name)))
                .ForMember(dest => dest.Visitors, opt => opt.MapFrom(src => src.Visitors.Select(x => x.UserProfileId)));

            CreateMap<EventDTO, EventDetailsViewModel>()
                .ForMember(dest => dest.DateFrom, opt => opt.MapFrom(src => src.DateFrom.ToString("yyyy-MM-dd")))
                .ForMember(dest => dest.DateTo, opt => opt.MapFrom(src => src.DateTo.ToString("yyyy-MM-dd")))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City.Name))
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.CategoryNames))
                .ForMember(dest => dest.Visitors, opt => opt.Ignore());
                
        }
    }
}
