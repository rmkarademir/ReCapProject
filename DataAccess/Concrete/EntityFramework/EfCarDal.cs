﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentContext context = new RentContext())
            {
                var result = from c in context.Cars 
                             join b in context.Brands on c.BrandId equals b.Id
                             join co in context.Colors on c.ColorId equals co.Name
                             select new CarDetailDto { Id = c.Id, BrandName = b.Name, ColorName = co.Name, DailyPrice = c.DailyPrice, ModelYear = c.ModelYear };
                return result.ToList();    
            }
        }        
    }
}