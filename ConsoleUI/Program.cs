﻿using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {


            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            UserManager userManager = new UserManager(new EfUserDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            //Car car1 = new Car {CarId=1, DailyPrice=-5};
            //carManager.Add(car1);
            carManager.GetAll();

            //TestRentalAdd(rentalManager);

            //var result = carManager.GetAll();
            //if (result.Success==true)
            //{
            //    foreach (var car in result.Data)
            //    {
            //        Console.WriteLine(car.Description);
            //        Console.WriteLine(car.Type);
            //        Console.WriteLine("------------");
            //    }
            //    Console.WriteLine(result.Message);
            //}


        }
        private static void TestRentalAdd(RentalManager rentalManager)
        {
            Rental rental1 = new Rental
            {
                CarId = 1,
                CustomerId = 2,
                RentDate = new DateTime(2021, 2, 2, 19, 30, 00),
                ReturnDate = new DateTime(2021, 2, 17, 19, 30, 00)
            };
            Console.WriteLine(rentalManager.Add(rental1).Message);
        }
    }
}
