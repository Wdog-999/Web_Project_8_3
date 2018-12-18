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
        MapperConfiguration brief = new MapperConfiguration(cfg => {
            cfg.CreateMap<User, BriefUserDTO>();
            //.ForMember(dest => dest.PhotoUrl, opt =>
            // {
            //     opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsProfilePic).Url);
            // });
        });
        MapperConfiguration full = new MapperConfiguration(cfg => {
            cfg.CreateMap<User, FullUserDTO>();
            //.ForMember(dest => dest.PhotoUrl, opt =>
            //{
            //    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsProfilePic).Url);
            //});
        });
    }
}
