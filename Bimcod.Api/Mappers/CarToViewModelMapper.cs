using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bimcod.Api.ViewModels;
using Bimcod.Api.Models;

namespace Bimcod.Api.Mappers
{
    public class CarToViewModelMapper : IEntityMapper<Car, CarViewModel>
    {
        public CarViewModel Map(Car entity)
        {
            var result = new CarViewModel
            {
                Id = entity.Id,
                Model = entity.Model,
                Type = entity.Type
            };

            return result;
        }
    }
}
