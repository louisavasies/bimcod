using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bimcod.Api.Models;

namespace Bimcod.Api.Repositories
{
    public class CarOptionRepository
    {
        private BimcodContext context = new BimcodContext();

        public CarOptionRepository(BimcodContext context)
        {
            this.context = context;
        }

        public CarOption AddCarOption(CarOption carOption)
        {
            context.Add(carOption);
            context.SaveChanges();
            return carOption;
        }

        public void RemoveCarOption(int carId, int optionId)
        {
            CarOption carOption = new CarOption { CarId = carId, OptionId = optionId };
            context.CarOption.Remove(carOption);
            context.SaveChanges();
        }

        public List<CarOption> GetAll()
        {
            return context.CarOption.ToList();
        }

        public List<CarOption> GetAllByCarId(int carId)
        {
            return context.CarOption
                .Where(co => co.CarId == carId)
                .ToList();
        }
    }
}
