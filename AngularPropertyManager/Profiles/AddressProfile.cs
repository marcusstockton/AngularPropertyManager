using AngularPropertyManager.Models;
using AngularPropertyManager.Models.DTOs.Address;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularPropertyManager.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressCreateDto>().ReverseMap();
        }
    }
}
