﻿using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BuinessLayer.Abstract
{
    public interface IBookingService:IGenericService<Booking>
    {
		void TBookingStatusApprove(int id);
		void TBookingStatusCancel(int id);
	}
}
