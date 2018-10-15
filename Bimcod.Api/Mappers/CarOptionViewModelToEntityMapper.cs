using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bimcod.Api.ViewModels;
using Bimcod.Api.Models;

namespace Bimcod.Api.Mappers
{
    public class CarOptionViewModelToEntityMapper : IEntityMapper<CarOptionViewModel, CarOption>
    {
        public CarOption Map(CarOptionViewModel carOptionViewModel)
        {
            var result = new CarOption
            {
                CarId = carOptionViewModel.CarId,
                OptionId = carOptionViewModel.OptionId
            };

            return result;
        }
    }
}
