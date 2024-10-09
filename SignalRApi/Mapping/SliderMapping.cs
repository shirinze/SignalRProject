using AutoMapper;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
	public class SliderMapping:Profile
	{
		public SliderMapping()
		{
			CreateMap<Slider, ResultSliderDto>().ReverseMap();
			CreateMap<Slider, CreateSliderDto>().ReverseMap();
			CreateMap<Slider, UpdateSliderDto>().ReverseMap();
		}
	}
}
