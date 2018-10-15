using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bimcod.Api.ViewModels;
using Bimcod.Api.Models;

namespace Bimcod.Api.Mappers
{
    public class BuiltInCarViewModelToEntityMapper : IEntityMapper<BuiltInCarViewModel, BuiltInCar>
    {
        public BuiltInCar Map(BuiltInCarViewModel builtInCarViewModel)
        {
            var result = new BuiltInCar
            {
                Id = builtInCarViewModel.Id,
                Model = builtInCarViewModel.Model,
                Type = builtInCarViewModel.Type
            };

            return result;
        }
    }
}
