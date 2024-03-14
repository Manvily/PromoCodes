using AutoMapper;
using PromoCodes.Models;
using PromoCodes.ViewModels;

namespace PromoCodes.Mapper;

internal class MappingViewModels : Profile
{
    public MappingViewModels()
    {
        CreateMap<PromoCode, PromoCodeViewModel>()
            .ForMember(x => x.ViewCountLeft, opt => opt.MapFrom(src => src.AvailableViewCount - src.CurrentViewCount));
    }
}