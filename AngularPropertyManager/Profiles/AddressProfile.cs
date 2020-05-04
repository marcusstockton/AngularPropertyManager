using AngularPropertyManager.Models;
using AngularPropertyManager.Models.DTOs.Address;
using AutoMapper;

namespace AngularPropertyManager.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressCreateDto>().ReverseMap();
            CreateMap<Address, AddressDetailsDto>().ReverseMap();
        }
    }
}
