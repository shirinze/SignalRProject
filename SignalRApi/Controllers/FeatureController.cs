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
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureservice;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureservice, IMapper mapper)
        {
            _featureservice = featureservice;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult FeatureList()
        {
            var value = _mapper.Map<List<ResultFeatureDto>>(_featureservice.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createfeaturedto)
        {
            _featureservice.TAdd(new Feature()
            {
                Title1 = createfeaturedto.Title1,
                Description1 = createfeaturedto.Description1,
                Title2 = createfeaturedto.Title3,
                Description2 = createfeaturedto.Description2,
                Title3 = createfeaturedto.Title3,
                Description3 = createfeaturedto.Description3
            });


            return Ok("basariliri bir sekilde eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var value = _featureservice.TGetByID(id);
            _featureservice.TDelete(value);
            return Ok("basarili bir sekilde silindi");
        }
        [HttpGet("GetFeature")]
        public IActionResult GetFeature(int id)
        {
            var value = _featureservice.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updatefeaturedto)
        {
            _featureservice.TUpdate(new Feature()
            {
                FeatureID=updatefeaturedto.FeatureID,
                Title1 = updatefeaturedto.Title1,
                Description1 = updatefeaturedto.Description1,
                Title2 = updatefeaturedto.Title3,
                Description2 = updatefeaturedto.Description2,
                Title3 = updatefeaturedto.Title3,
                Description3 = updatefeaturedto.Description3
            });
            return Ok("basarili bir sekilde guncellendi");
        }
    }
}
