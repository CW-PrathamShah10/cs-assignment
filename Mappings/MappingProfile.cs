using AutoMapper;
using cswebapi.DTO;
using cswebapi.Entities;

namespace cswebapi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StockSearchRequestDTO, Filters>()
                .ForMember(dest => dest.MinBudget, opt => opt.MapFrom(src => src.MinBudget ?? 0))
                .ForMember(dest => dest.MaxBudget, opt => opt.MapFrom(src => src.MaxBudget ?? int.MaxValue))
                .ForMember(dest => dest.FuelTypes, opt => opt.MapFrom(src => src.FuelTypes.Select(f => (FuelType)f).ToList()));
        }
    }
}
