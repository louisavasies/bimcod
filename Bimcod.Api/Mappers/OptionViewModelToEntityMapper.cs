using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bimcod.Api.ViewModels;
using Bimcod.Api.Models;

namespace Bimcod.Api.Mappers
{
    public class OptionViewModelToEntityMapper : IEntityMapper<OptionViewModel, Option>
    {
        public Option Map(OptionViewModel optionViewModel)
        {
            var result = new Option
            {
                Id = optionViewModel.Id,
                Description = optionViewModel.Description,
                Duration = optionViewModel.Duration,
                ModuleName = optionViewModel.ModuleName,
                Price = optionViewModel.Price
            };

            return result;
        }
    }
}
