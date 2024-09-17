using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concreate;
using SignalR.DataAccessLayer.Repositories;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(SignalRContext context) : base(context)
        {
        }

        public List<Product> GetProductsWithCategories()
        {
            var context = new SignalRContext();
            var value = context.Products.Include(x => x.Category).ToList();
            return value;
        }

		public int ProductCount()
		{
            using var context = new SignalRContext();
            return context.Products.Count();
		}

		public int ProductCountByCategoryNameDrink()
		{
            using var context = new SignalRContext();
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Içecek").Select(z => z.CategoryID).FirstOrDefault())).Count();
		}

		public int ProductCountByCategoryNameHamburger()
		{
            using var context = new SignalRContext();
            return context.Products.Where(x=>x.CategoryID==(context.Categories.Where(y=>y.CategoryName=="Hamburger").Select(z=>z.CategoryID).FirstOrDefault())).Count();
		}

		public string ProductNameMaxPrice()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x => x.Price == (context.Products.Max(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
		}

		public string ProductNameMinPrice()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x => x.Price == (context.Products.Min(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
		}

		public decimal ProductPriceAvg()
		{
            using var context = new SignalRContext();
            return context.Products.Average(x => x.Price);
		}
	}
}
