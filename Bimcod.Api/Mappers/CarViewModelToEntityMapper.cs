using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bimcod.Api.ViewModels;
using Bimcod.Api.Models;

namespace Bimcod.Api.Mappers
{
    public class CarViewModelToEntityMapper : IEntityMapper<CarViewModel, Car>
    {
        public Car Map(CarViewModel carViewModel)
        {
            var result = new Car
            {
                Id = carViewModel.Id,
                Model = carViewModel.Model,
                Type = carViewModel.Type
            };

            return result;
        }
    }
}
