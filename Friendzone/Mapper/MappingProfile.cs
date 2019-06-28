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
                //.ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                //.ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.Email))
                //.ForMember(dest => dest.UserName, opts => opts.MapFrom(src => src.UserName));

            CreateMap<UserDTO, User>();
                //.ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.Email))
                //.ForMember(dest => dest.UserName, opts => opts.MapFrom(src => src.UserName));

            CreateMap<LoginModel, UserDTO>();
                //.ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.Email))
                //.ForMember(dest => dest.Password, opts => opts.MapFrom(src => src.Password));

            CreateMap<RegisterModel, UserDTO>()
                 //.ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.Email))
                 //.ForMember(dest => dest.Password, opts => opts.MapFrom(src => src.Password))
                 .ForMember(dest => dest.UserName, opts => opts.MapFrom(src => src.Login))
                 .ForMember(dest => dest.Role, opts => opts.MapFrom(src => "user"));

            CreateMap<UserProfileEditModel, ProfileDTO>();
                //.ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                //.ForMember(dest => dest.Birthday, opts => opts.MapFrom(src => src.Birthday))
                //.ForMember(dest => dest.CityId, opts => opts.MapFrom(src => src.CityId));

            CreateMap<ProfileDTO, UserProfileViewModel>()
                //.ForMember(dest => dest.UserName, opts => opts.MapFrom(src => src.UserName))
                //.ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.Email))
                //.ForMember(dest => dest.AvatarUrl, opts => opts.MapFrom(src => src.AvaUrl))
                .ForMember(dest => dest.City, opts => opts.MapFrom(src => src.City.Name))
                .ForMember(dest => dest.Age, opts => opts.MapFrom(src => (DateTime.Today.Year - src.Birthday.Year)));

            CreateMap<ProfileDTO, UserProfilePreviewModel>()
                //.ForMember(dest => dest.UserId, opts => opts.MapFrom(src => src.UserId))
                //.ForMember(dest => dest.UserName, opts => opts.MapFrom(src => src.UserName))
                //.ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.Email))
                .ForMember(dest => dest.AvatarUrl, opts => opts.MapFrom(src => src.AvaUrl));

            CreateMap<ProfileDTO, UserProfile>()
                //.ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                //.ForMember(dest => dest.Birthday, opts => opts.MapFrom(src => src.Birthday))
                //.ForMember(dest => dest.City, opts => opts.MapFrom(src => src.City))
                .ForPath(dest => dest.User.Email, opts => opts.MapFrom(src => src.Email))
                .ForPath(dest => dest.User.PhoneNumber, opts => opts.MapFrom(src => src.PhoneNumber))
                .ForPath(dest => dest.User.UserName, opts => opts.MapFrom(src => src.UserName));

            CreateMap<UserProfile, ProfileDTO>()
                //.ForMember(dest => dest.UserId, opts => opts.MapFrom(src => src.UserId))
                //.ForMember(dest => dest.Birthday, opts => opts.MapFrom(src => src.Birthday))
                .ForMember(dest => dest.UserName, opts => opts.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.PhoneNumber, opts => opts.MapFrom(src => src.User.PhoneNumber))
                .ForMember(dest => dest.AvaUrl, opts => opts.MapFrom(src => src.Avatar.Url));

            CreateMap<EventEditViewModel, EventDTO>();
                //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                //.ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                //.ForMember(dest => dest.DateFrom, opt => opt.MapFrom(src => src.DateFrom))
                //.ForMember(dest => dest.DateTo, opt => opt.MapFrom(src => src.DateTo))
                //.ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.CityId))
                //.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                //.ForMember(dest => dest.OwnerUserId, opt => opt.MapFrom(src => src.OwnerUserId))
                //.ForMember(dest => dest.CategoriyIds, opt => opt.MapFrom(src => src.CategoryIds));

            CreateMap<EventDTO, Event>();
                //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                //.ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                //.ForMember(dest => dest.DateFrom, opt => opt.MapFrom(src => src.DateFrom))
                //.ForMember(dest => dest.DateTo, opt => opt.MapFrom(src => src.DateTo))
                //.ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.CityId))
                //.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                //.ForMember(dest => dest.OwnerUserId, opt => opt.MapFrom(src => src.OwnerUserId));

            CreateMap<Event, EventDTO>()
                //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                //.ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                //.ForMember(dest => dest.DateFrom, opt => opt.MapFrom(src => src.DateFrom))
                //.ForMember(dest => dest.DateTo, opt => opt.MapFrom(src => src.DateTo))
                //.ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.City.Id))
                //.ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                //.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.OwnerUserId, opt => opt.MapFrom(src => src.Owner.UserId));

            CreateMap<EventDTO, EventDetailsViewModel>()
                //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                //.ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.DateFrom, opt => opt.MapFrom(src => src.DateFrom.ToString("yyyy-MM-dd")))
                .ForMember(dest => dest.DateTo, opt => opt.MapFrom(src => src.DateTo.ToString("yyyy-MM-dd")))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City.Name))
                //.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.CategoryNames))
                //.ForMember(dest => dest.OwnerUserId, opt => opt.MapFrom(src => src.OwnerUserId))
                .ForMember(dest => dest.Visitors, opt => opt.Ignore());
                
        }
    }
}
