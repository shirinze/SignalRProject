﻿using SignalR.BuinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BuinessLayer.Concreate
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;
        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }
        public void TAdd(Booking entity)
        {
            _bookingDal.Add(entity);
        }

		public void TBookingStatusApprove(int id)
		{
            _bookingDal.BookingStatusApprove(id);
		}

		public void TBookingStatusCancel(int id)
		{
            _bookingDal.BookingStatusCancel(id);
		}

		public void TDelete(Booking entity)
        {
            _bookingDal.Delete(entity);
        }

        public Booking TGetByID(int id)
        {
            return _bookingDal.GetByID(id);
        }

        public List<Booking> TGetListAll()
        {
            return _bookingDal.GetListAll();
        }

        public void TUpdate(Booking entity)
        {
            _bookingDal.Update(entity);
        }
    }
}
