using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BuinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productservice;
        private readonly IMapper _mapper;

        public ProductController(IProductService productservice, IMapper mapper)
        {
            _productservice = productservice;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var value = _mapper.Map<List<ResultProductDto>>(_productservice.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createproductdto)
        {
            _productservice.TAdd(new Product()
            {
                ProductName = createproductdto.ProductName,
                Description = createproductdto.Description,
                Price = createproductdto.Price,
                ImageURL = createproductdto.ImageURL,
                ProductStatus = createproductdto.ProductStatus
               
            });


            return Ok("basariliri bir sekilde eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productservice.TGetByID(id);
            _productservice.TDelete(value);
            return Ok("basarili bir sekilde silindi");
        }
        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var value = _productservice.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateproductdto)
        {
            _productservice.TUpdate(new Product()
            {
                ProductID=updateproductdto.ProductID,
                ProductName = updateproductdto.ProductName,
                Description = updateproductdto.Description,
                Price = updateproductdto.Price,
                ImageURL = updateproductdto.ImageURL,
                ProductStatus = updateproductdto.ProductStatus
            });
            return Ok("basarili bir sekilde guncellendi");
        }
    }
}

