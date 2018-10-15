using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bimcod.Api.ViewModels;
using Bimcod.Api.Models;

namespace Bimcod.Api.Mappers
{
    public class CarOptionToViewModelMapper : IEntityMapper<CarOption, CarOptionViewModel>
    {
        public CarOptionViewModel Map(CarOption carOption)
        {
            var result = new CarOptionViewModel
            {
                CarId = carOption.CarId,
                OptionId = carOption.OptionId
            };

            return result;
        }
    }
}
