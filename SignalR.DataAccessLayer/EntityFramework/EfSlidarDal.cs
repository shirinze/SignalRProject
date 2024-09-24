﻿using SignalR.DataAccessLayer.Abstract;
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
    public class EfSlidarDal : GenericRepository<Slider>, ISliderDal
    {
        public EfSlidarDal(SignalRContext context) : base(context)
        {
        }
    }
}
