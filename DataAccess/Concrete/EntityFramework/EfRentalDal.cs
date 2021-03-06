﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in filter == null ? context.Rentals : context.Rentals.Where(filter)
                             join c in context.Cars on r.CarId equals c.CarId
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join cu in context.Customers on r.CustomerId equals cu.CustomerId
                             join u in context.Users on cu.UserId equals u.UserId
                             select new RentalDetailDto { 
                                 RentalId = r.RentalId, 
                                 BrandName = b.BrandName, 
                                 UserFirstName = u.FirstName,
                                 UserLastName = u.LastName,
                                 CustomerName= cu.CompanyName, 
                                 ModelName= c.ModelName,
                                 RentDate= r.RentDate,
                                 ReturnDate= r.ReturnDate };
                return result.ToList();
            }
        }
    }
}
