using AutoMapper;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class FeatureMapping:Profile
    {
        public FeatureMapping()
        {
            CreateMap<Feature, ResultSliderDto>().ReverseMap();
            CreateMap<Feature, CreateSliderDto>().ReverseMap();
            CreateMap<Feature, GetSliderDto>().ReverseMap();
            CreateMap<Feature, UpdateSliderDto>().ReverseMap();
        }
    }
}
