using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bimcod.Api.Models;

namespace Bimcod.Api.Repositories
{
    public class CarRepository
    {
        private BimcodContext context = new BimcodContext();

        public CarRepository(BimcodContext context)
        {
            this.context = context;
        }

        public Car AddCar(Car car)
        {
            Car foundCar = context.Car.Where(c => c.Id == car.Id).FirstOrDefault();
            if(foundCar != null)
            {
                return null;
            }

            context.Car.Add(car);
            context.SaveChanges();
            return car;
        }

        public void DeleteCar(int id)
        {
            context.Car.Remove(new Car { Id = id });
            context.SaveChanges();
        }

        public List<Car> GetAllCars(int id)
        {
            return context.Car
                .Where(c => c.UserId == id)
                .ToList();
        }

        public Car GetCarById(int id)
        {
            return context.Car.Find(id);
        }
    }
}
