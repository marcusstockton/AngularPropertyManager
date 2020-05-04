using AngularPropertyManager.Models;
using AngularPropertyManager.Models.DTOs.Portfolio;
using AutoMapper;

namespace AngularPropertyManager.Profiles
{
    public class PortfolioProfile : Profile
    {
        public PortfolioProfile()
        {
            CreateMap<PortfolioCreateDto, Portfolio>().ReverseMap();
            CreateMap<PortfolioDetailsDto, Portfolio>().ReverseMap();
        }
    }
}
