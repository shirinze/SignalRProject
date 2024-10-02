using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concreate;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
	public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
	{
		public EfNotificationDal(SignalRContext context) : base(context)
		{
		}

		public List<Notification> GetAllNotificationByFalse()
		{
			using var context = new SignalRContext();
			return context.Notifications.Where(x => x.Status == false).ToList();
		}

		public int NotificationCountByStatusFalse()
		{
			using var context = new SignalRContext();
			return context.Notifications.Where(x => x.Status == false).Count();
		}

		public void NotificationStatusChangetoFalse(int id)
		{
			using var context = new SignalRContext();
			var value = context.Notifications.Find(id);
			value.Status = false;
			context.SaveChanges();
		}

		public void NotificationStatusChangetoTrue(int id)
		{
			using var context=new SignalRContext();
			var value = context.Notifications.Find(id);
			value.Status = true;
			context.SaveChanges();

		}
	}
}
