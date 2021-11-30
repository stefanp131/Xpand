using AutoMapper;
using Xpand.API.Models;
using Xpand.DATA.Entities;

namespace Xpand.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RegisterUserDto, AppUser>();
            CreateMap<PlanetDto, Planet>();

        }
    }
}