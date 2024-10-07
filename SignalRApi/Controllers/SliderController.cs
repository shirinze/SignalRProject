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
            _sliderservice.TAdd(new Slider()
            {
                Title1 = createsliderdto.Title1,
                Description1 = createsliderdto.Description1,
                Title2 = createsliderdto.Title3,
                Description2 = createsliderdto.Description2,
                Title3 = createsliderdto.Title3,
                Description3 = createsliderdto.Description3
            });


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
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateSlider(UpdateSliderDto updatesliderdto)
        {
            _sliderservice.TUpdate(new Slider()
            {
                SliderID= updatesliderdto.SliderID,
                Title1 = updatesliderdto.Title1,
                Description1 = updatesliderdto.Description1,
                Title2 = updatesliderdto.Title3,
                Description2 = updatesliderdto.Description2,
                Title3 = updatesliderdto.Title3,
                Description3 = updatesliderdto.Description3
            });
            return Ok("basarili bir sekilde guncellendi");
        }
    }
}
