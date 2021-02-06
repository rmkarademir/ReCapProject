using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.DailyPrice>0)
            {
                _carDal.Add(car);
                Console.WriteLine("Araba eklendi.");
            }
            else
            {
                Console.WriteLine("Aracın günlük ücretini '0' dan fazla giriniz.");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c=>c.ColorId == id);
        }

        public List<Car> GetCarsById(int id)
        {
            return _carDal.GetAll(c => c.Id == id);
        }

        public List<Car> GetCarsByMoledYear(int min, int max)
        {
            return _carDal.GetAll(c => c.ModelYear>=min && c.ModelYear<=max);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
