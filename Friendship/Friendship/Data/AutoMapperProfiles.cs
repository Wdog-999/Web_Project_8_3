using Friendship.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Friendship.Data
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, FullUserDTO>()
            .ForMember(dest => dest.PhotoUrl, opt =>
            {
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsProfilePic).Url);
            });
            CreateMap<User, BriefUserDTO>()
            .ForMember(dest => dest.PhotoUrl, opt =>
             {
                 opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsProfilePic).Url);
             });
            CreateMap<User, EditUserDTO>();
        }
    }
}
