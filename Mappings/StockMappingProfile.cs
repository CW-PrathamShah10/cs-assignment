using AutoMapper;
using cswebapi.Entities;
using cswebapi.DTOs;

namespace cswebapi.Mappings
{
    public class StockMappingProfile : Profile
    {
        public StockMappingProfile()
        {
            CreateMap<Stock, StockDTO>()
                .ForMember(dest => dest.CarName, opt => opt.MapFrom(src => $"{src.MakeYear} {src.Make} {src.Model}"))
                .ForMember(dest => dest.FormattedPrice, opt => opt.MapFrom(src => $"Rs. {src.Price / 100000.0:F1} Lakh"))
                .ForMember(dest => dest.IsValueForMoney, opt => opt.MapFrom(src => src.Kilometers < 10000 && src.Price < 200000));
        }
    }
}
