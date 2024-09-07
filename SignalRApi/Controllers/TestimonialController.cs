using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BuinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialservice;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialservice, IMapper mapper)
        {
            _testimonialservice = testimonialservice;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult TestimonialList()
        {
            var value = _mapper.Map<List<ResultTestimonialDto>>(_testimonialservice.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createtestimonialdto)
        {
            _testimonialservice.TAdd(new Testimonial()
            {
                Name = createtestimonialdto.Name,
                Title = createtestimonialdto.Title,
                Comment = createtestimonialdto.Comment,
                ImageUrl=createtestimonialdto.ImageUrl,
                Status=createtestimonialdto.Status

            });
            return Ok("basarili bir sekilde eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialservice.TGetByID(id);
            _testimonialservice.TDelete(value);
            return Ok("basarili bir sekilde silindi");
        }
        [HttpGet("GetTestimonial")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _testimonialservice.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updatetestimonialdto)
        {
            _testimonialservice.TUpdate(new Testimonial()
            {
                TestimonialID = updatetestimonialdto.TestimonialID,
                Title = updatetestimonialdto.Title,
                Name = updatetestimonialdto.Name,
                Comment = updatetestimonialdto.Comment,
                ImageUrl=updatetestimonialdto.ImageUrl,
                Status=updatetestimonialdto.Status
            });
            return Ok("basarili bir sekilde guncellendi");
        }
    }
}
