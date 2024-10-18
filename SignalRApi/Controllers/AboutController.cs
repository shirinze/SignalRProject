using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SignalR.BuinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutservice;
        private readonly IMapper _mapper;
        public AboutController(IAboutService aboutservice, IMapper mapper)
        {
            _aboutservice = aboutservice;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutservice.TGetListAll();
            return Ok(_mapper.Map<List<ResultAboutDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createaboutdto)
        {
            var value = _mapper.Map<About>(createaboutdto);
            _aboutservice.TAdd(value);
            return Ok("hakkimda kismi basarili bir sekilde eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutservice.TGetByID(id);
            _aboutservice.TDelete(value);
            return Ok("hakkimda kismi basari bir sekilde silindi");
        }
        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateaboutdto)
        {
            var value = _mapper.Map<About>(updateaboutdto);
            _aboutservice.TUpdate(value);
            return Ok("hakimda kismi guncellemdi");
        }
        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var value = _aboutservice.TGetByID(id);
            return Ok(_mapper.Map<GetAboutDto>(value));
        }
    }
}
