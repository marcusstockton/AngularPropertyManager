using AngularPropertyManager.Models;
using AngularPropertyManager.Models.DTOs.ApplicationUser;
using AutoMapper;

namespace AngularPropertyManager.Profiles
{
    public class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserDetailsDto>().ReverseMap();
        }
    }
}
