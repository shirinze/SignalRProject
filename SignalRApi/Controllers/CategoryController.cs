using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BuinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;
using System.Diagnostics;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryservice;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryservice,IMapper mapper)
        {
            _categoryservice = categoryservice;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _mapper.Map<List<ResultCategoryDto>>(_categoryservice.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createcategorydto)
        {
            _categoryservice.TAdd(new Category()
            {
                CategoryName = createcategorydto.CategoryName,
                CategoryStatus = true
            });
                
           
            return Ok("basariliri bir sekilde eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var value = _categoryservice.TGetByID(id);
            _categoryservice.TDelete(value);
            return Ok("basarili bir sekilde silindi");
        }
        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id)
        {
            var value = _categoryservice.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updatecategorydto)
        {
            _categoryservice.TUpdate(new Category()
            {
                CategoryID = updatecategorydto.CategoryID,
                CategoryName = updatecategorydto.CategoryName,
                CategoryStatus = updatecategorydto.CategoryStatus
            });
            return Ok("basarili bir sekilde guncellendi");
        }
    }
}
