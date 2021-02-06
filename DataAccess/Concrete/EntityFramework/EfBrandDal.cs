using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : IBrandDal
    {
        void IEntityRepository<Brand>.Add(Brand entity)
        {
            using (RentContext context = new RentContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        void IEntityRepository<Brand>.Delete(Brand entity)
        {
            using (RentContext context = new RentContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        Brand IEntityRepository<Brand>.Get(Expression<Func<Brand, bool>> filter)
        {
            using (RentContext context = new RentContext())
            {
                return context.Set<Brand>().SingleOrDefault(filter);
            }
        }

        List<Brand> IEntityRepository<Brand>.GetAll(Expression<Func<Brand, bool>> filter)
        {
            using (RentContext context = new RentContext())
            {
                return filter == null ? context.Set<Brand>().ToList() : context.Set<Brand>().Where(filter).ToList();
            }
        }

        void IEntityRepository<Brand>.Update(Brand entity)
        {
            using (RentContext context = new RentContext())
            {
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
