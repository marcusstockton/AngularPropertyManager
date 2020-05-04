using AngularPropertyManager.Models;
using AngularPropertyManager.Models.DTOs.Property;
using AutoMapper;

namespace AngularPropertyManager.Profiles
{
    public class PropertyProfile : Profile
    {
        public PropertyProfile()
        {
            CreateMap<Property, PropertyCreateDto>().ReverseMap();
        }
    }
}
