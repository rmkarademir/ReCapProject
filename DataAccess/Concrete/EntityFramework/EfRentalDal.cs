using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentContext>, IRentalDal
    {
        public List<RentalDetailDto> GetCarDetails()
        {
            using (RentContext context = new RentContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.CarId
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join cu in context.Customers on r.CustomerId equals cu.CustomerId
                             join u in context.Users on cu.UserId equals u.UserId
                             select new RentalDetailDto { 
                                 RentalId = r.RentalIdx, 
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
