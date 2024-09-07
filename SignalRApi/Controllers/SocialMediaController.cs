using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BuinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialmediaservice;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialmediaservice, IMapper mapper)
        {
            _socialmediaservice = socialmediaservice;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var value = _mapper.Map<List<ResultSocialMediaDto>>(_socialmediaservice.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createsocialmediadto)
        {
            _socialmediaservice.TAdd(new SocialMedia()
            {
                Title = createsocialmediadto.Title,
                Url = createsocialmediadto.Url,
                Icon = createsocialmediadto.Icon

            });
            return Ok("basarili bir sekilde eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _socialmediaservice.TGetByID(id);
            _socialmediaservice.TDelete(value);
            return Ok("basarili bir sekilde silindi");
        }
        [HttpGet("GetSocialMedia")]
        public IActionResult GetSocialMedia(int id)
        {
            var value = _socialmediaservice.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updatesocialmediadto)
        {
            _socialmediaservice.TUpdate(new SocialMedia()
            {
                SocialMediaID=updatesocialmediadto.SocialMediaID,
                Title = updatesocialmediadto.Title,
                Url = updatesocialmediadto.Url,
                Icon = updatesocialmediadto.Icon
            });
            return Ok("basarili bir sekilde guncellendi");
        }
    }
}
