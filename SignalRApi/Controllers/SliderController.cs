using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BuinessLayer.Abstract;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }
        [HttpGet]
        public IActionResult SliderList()
        {
            return Ok(_sliderService.TGetListAll());
        }
    }
}
