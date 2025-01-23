using AutoMapper;
using NETPCApp.Application.DTOs;
using NETPCApp.Domain.Models;

namespace NETPCApp.Application.Mapper
{
    /// <summary>
    /// Map necessary DTO's with business models
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, ContactDTO>().
                ForMember(x => x.Password, y => y.MapFrom(x => x.PasswordHash)).
                ReverseMap();
        }
    }
}
