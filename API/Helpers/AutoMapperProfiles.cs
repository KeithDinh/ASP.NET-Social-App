using System;
using System.Linq;
using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // src.Photos.FirstOrDefault(x => x.IsMain).Url: go to user, get the Photos => go to Photo entity => get the first photo that IsMain = true, return the photo, then get the URL
            CreateMap<AppUser, MemberDto>()
                .ForMember(dest => dest.PhotoUrl, // what to display
                    opt => opt.MapFrom(           // where to map from
                        src => src.Photos.FirstOrDefault(x => x.IsMain).Url)
                )
                .ForMember(dest => dest.Age, // what to display
                    opt => opt.MapFrom(           // where to map from
                        src => src.DateOfBirth.CalculateAge())
                );
            CreateMap<Photo, PhotoDto>();
            CreateMap<MemberUpdateDto, AppUser>();
            CreateMap<RegisterDto, AppUser>();
            CreateMap<Message  , MessageDto>()
                .ForMember(dest => dest.SenderPhotoUrl, 
                            opt => opt.MapFrom(src => src.Sender.Photos.FirstOrDefault(x=>x.IsMain).Url))
                .ForMember(dest => dest.RecipientPhotoUrl, 
                            opt => opt.MapFrom(src => src.Recipient.Photos.FirstOrDefault(x=>x.IsMain).Url));
            
            // CreateMap<DateTime, DateTime>().ConvertUsing(d => DateTime.SpecifyKind(d, DateTimeKind.Utc));
        }
    }
}