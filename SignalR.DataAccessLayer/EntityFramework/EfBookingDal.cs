using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concreate;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(SignalRContext context) : base(context)
        {
        }

		public void BookingStatusApprove(int id)
		{
			using var context = new SignalRContext();
			var value=context.Bookings.Find(id);
			value.Description = "Rezervasyon Onaylandı";
			context.SaveChanges();
		}

		public void BookingStatusCancel(int id)
		{
			using var context = new SignalRContext();
			var value = context.Bookings.Find(id);
			value.Description = "Rezervasyon Iptal Edildi";
			context.SaveChanges();
		
		}
	}
}
