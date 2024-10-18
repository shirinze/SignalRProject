using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BuinessLayer.Abstract;
using SignalR.DataAccessLayer.Concreate;
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
        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            return Ok(_productservice.TProductCount());
        }

        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {

            var context = new SignalRContext();
            var value = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategory
            {
                ProductID = y.ProductID,
                ProductName = y.ProductName,
                Description = y.Description,
                Price = y.Price,
                ImageURL = y.ImageURL,
                ProductStatus = y.ProductStatus,
                CategoryName = y.Category.CategoryName
                
            });
            return Ok(value.ToList());
        }
        [HttpGet("ProductCountByHamburger")]
        public IActionResult ProductCountByHamburger()
        {
            return Ok(_productservice.TProductCountByCategoryNameHamburger());
        }
        [HttpGet("ProductCountByDrink")]
        public IActionResult ProductCountByDrink()
        {
            return Ok(_productservice.TProductCountByCategoryNameDrink());
        }
        [HttpGet("ProductPriceAvg")]
        public IActionResult ProductPriceAvg()
        {
            return Ok(_productservice.TProductPriceAvg());
        }
        [HttpGet("ProductNameMinPrice")]
        public IActionResult ProductNameMinPrice()
        {
            return Ok(_productservice.TProductNameMinPrice());
        }
		[HttpGet("ProductNameMaxPrice")]
		public IActionResult ProductNameMaxPrice()
		{
			return Ok(_productservice.TProductNameMaxPrice());
		}
        [HttpGet("ProductHmaburgerPrice")]
        public IActionResult ProductHmaburgerPrice()
        {
            return Ok(_productservice.TProductPriceByHmaburger());
        }
		[HttpPost]
        public IActionResult CreateProduct(CreateProductDto createproductdto)
        {
            var value = _mapper.Map<Product>(createproductdto);
            _productservice.TAdd(value);
            return Ok("basariliri bir sekilde eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productservice.TGetByID(id);
            _productservice.TDelete(value);
            return Ok("basarili bir sekilde silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var value = _productservice.TGetByID(id);
            return Ok(_mapper.Map<GetProductDto>(value));
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateproductdto)
        {
            var value = _mapper.Map<Product>(updateproductdto);
            _productservice.TUpdate(value);
            return Ok("basarili bir sekilde guncellendi");
        }
        [HttpGet("ProductPriceBySteakBurger")]
        public IActionResult ProductPriceBySteakBurger()
        {
            var value = _productservice.TProductPriceBySteakBurger();
            return Ok(value);
        }
        [HttpGet("TotalPriceByDrinkCategory")]
        public IActionResult TotalPriceByDrinkCategory()
        {
            return Ok(_productservice.TTotalPriceByDrinkCategory());
        }

        [HttpGet("TotalPriceByDrinkSalad")]
        public IActionResult TotalPriceByDrinkSalad()
        {
            return Ok(_productservice.TTotalPriceBySaladCategory());
        }
    }
}

