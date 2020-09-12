using AngularPropertyManager.Models;
using AngularPropertyManager.Models.DTOs.Tenant;
using AutoMapper;

namespace AngularPropertyManager.Profiles
{
    public class TenantProfile : Profile
    {
        public TenantProfile()
        {
            CreateMap<Tenant, TenantDetailsDto>().ReverseMap();
            CreateMap<Tenant, TenantCreateDto>().ReverseMap();
        }
    }
}
