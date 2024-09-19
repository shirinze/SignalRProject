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
	public class MenuTableManager : IMenuTableService
	{
		private readonly IMenuTableDal _menutableDal;

		public MenuTableManager(IMenuTableDal menutableDal)
		{
			_menutableDal = menutableDal;
		}

		public void TAdd(MenuTable entity)
		{
			_menutableDal.Add(entity);
		}

		public void TDelete(MenuTable entity)
		{
			_menutableDal.Delete(entity);
		}

		public MenuTable TGetByID(int id)
		{
			return _menutableDal.GetByID(id);
		}

		public List<MenuTable> TGetListAll()
		{
			return _menutableDal.GetListAll();
		}

		public int TMenuTableCount()
		{
			return _menutableDal.MenuTableCount();
		}

		public void TUpdate(MenuTable entity)
		{
			_menutableDal.Update(entity);
		}
	}
}
