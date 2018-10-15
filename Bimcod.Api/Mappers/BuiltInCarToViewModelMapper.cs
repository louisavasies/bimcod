using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bimcod.Api.ViewModels;
using Bimcod.Api.Models;

namespace Bimcod.Api.Mappers
{
    public class BuiltInCarToViewModelMapper : IEntityMapper<BuiltInCar, BuiltInCarViewModel>
    {
        public BuiltInCarViewModel Map(BuiltInCar entity)
        {
            var result = new BuiltInCarViewModel
            {
                Id = entity.Id,
                Model = entity.Model,
                Type = entity.Type
            };

            return result;
        }
    }
}
