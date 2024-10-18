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
            About about = new About
            {
                ImageUrl = createaboutdto.ImageUrl,
                Title = createaboutdto.Title,
                Description = createaboutdto.Description
            };
            _aboutservice.TAdd(about);
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
            //About about = new About
            //{
            //    AboutID = updateaboutdto.AboutID,
            //    ImageUrl = updateaboutdto.ImageUrl,
            //    Title = updateaboutdto.Title,
            //    Description = updateaboutdto.Description
            //};
            //_aboutservice.TUpdate(about);
            //return Ok("hakimda kismi guncellemdi");
        }
        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var value = _aboutservice.TGetByID(id);
            return Ok(value);
        }
    }
}
