using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bimcod.Api.ViewModels;
using Bimcod.Api.Models;

namespace Bimcod.Api.Mappers
{
    public class OptionToViewModelMapper : IEntityMapper<Option, OptionViewModel>
    {
        public OptionViewModel Map(Option entity)
        {
            var result = new OptionViewModel
            {
                Id = entity.Id,
                Description = entity.Description,
                Duration = entity.Duration,
                ModuleName = entity.ModuleName,
                Price = entity.Price
            };

            return result;
        }
    }
}
