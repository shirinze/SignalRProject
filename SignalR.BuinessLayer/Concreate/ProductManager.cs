using SignalR.BuinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BuinessLayer.Concreate
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public void TAdd(Product entity)
        {
            _productDal.Add(entity);
        }

        public void TDelete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public Product TGetByID(int id)
        {
           return _productDal.GetByID(id);
        }

        public List<Product> TGetListAll()
        {
            return _productDal.GetListAll();
        }

        public List<Product> TGetProductsWithCategories()
        {
            return _productDal.GetProductsWithCategories();
        }
        public int TProductCount()
		{
            return _productDal.ProductCount();
		}

		public int TProductCountByCategoryNameDrink()
		{
            return _productDal.ProductCountByCategoryNameDrink();
		}

		public int TProductCountByCategoryNameHamburger()
		{
            return _productDal.ProductCountByCategoryNameHamburger();
		}

		public string TProductNameMaxPrice()
		{
            return _productDal.ProductNameMaxPrice();
		}

		public string TProductNameMinPrice()
		{
            return _productDal.ProductNameMinPrice();
		}

		public decimal TProductPriceAvg()
		{
            return _productDal.ProductPriceAvg();
		}

		public decimal TProductPriceByHmaburger()
		{
            return _productDal.ProductPriceByHmaburger();
		}

        public decimal TProductPriceBySteakBurger()
        {
            return _productDal.ProductPriceBySteakBurger();
        }

        public decimal TTotalPriceByDrinkCategory()
        {
            return _productDal.TotalPriceByDrinkCategory();
        }

        public decimal TTotalPriceBySaladCategory()
        {
            return _productDal.TotalPriceBySaladCategory();
        }

        public void TUpdate(Product entity)
        {
            _productDal.Update(entity);
        }
    }
}
