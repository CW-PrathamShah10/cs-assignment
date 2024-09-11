using AutoMapper;
using cswebapi.Entities;
using cswebapi.DTO;

namespace cswebapi.Mappings
{
    public class StockMappingProfile : Profile
    {
        public StockMappingProfile()
        {
            CreateMap<Stock, StockDTO>()
                .ForMember(dest => dest.CarName, opt => opt.MapFrom(src => $"{src.MakeYear} {src.Make} {src.Model}"))
                .ForMember(dest => dest.FormattedPrice, opt => opt.MapFrom(src => $"Rs. {src.Price / 100000.0:F1} Lakh"))
                .ForMember(dest => dest.IsValueForMoney, opt => opt.MapFrom(src => src.Kilometers < 10000 && src.Price < 200000))
                .ForMember(dest => dest.Make, opt => opt.MapFrom(src => src.Make))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
                .ForMember(dest => dest.MakeYear, opt => opt.MapFrom(src => src.MakeYear))
                .ForMember(dest => dest.Kilometers, opt => opt.MapFrom(src => src.Kilometers))
                .ForMember(dest => dest.Fuel, opt => opt.MapFrom(src => src.Fuel));
        }
    }
}
