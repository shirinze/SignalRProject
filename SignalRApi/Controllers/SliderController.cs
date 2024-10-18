using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BuinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderservice;
        private readonly IMapper _mapper;

		public SliderController(ISliderService sliderservice, IMapper mapper)
		{
			_sliderservice = sliderservice;
			_mapper = mapper;
		}

		[HttpGet]
        public IActionResult SliderList()
        {
            var value = _mapper.Map<List<ResultSliderDto>>(_sliderservice.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateSlider( CreateSliderDto createsliderdto)
        {
            var value = _mapper.Map<Slider>(createsliderdto);
            _sliderservice.TAdd(value);
            return Ok("basariliri bir sekilde eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSlider(int id)
        {
            var value = _sliderservice.TGetByID(id);
            _sliderservice.TDelete(value);
            return Ok("basarili bir sekilde silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetSlider(int id)
        {
            var value = _sliderservice.TGetByID(id);
            return Ok(_mapper.Map<GetSliderDto>(value));
        }
        [HttpPut]
        public IActionResult UpdateSlider(UpdateSliderDto updatesliderdto)
        {
            var value = _mapper.Map<Slider>(updatesliderdto);
            _sliderservice.TUpdate(value);
            return Ok("basarili bir sekilde guncellendi");
        }
    }
}
