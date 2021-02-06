﻿using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class RentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Rent;Trusted_Connection=true");
        }

        public DbSet<Car> Products { get; set; }
        public DbSet<Brand> Categories { get; set; }
        public DbSet<Color> Customers { get; set; }
    }
}
