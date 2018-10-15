using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bimcod.Api.ViewModels;
using Bimcod.Api.Models;

namespace Bimcod.Api.Mappers
{
    public class OptionPartViewModelToEntityMapper : IEntityMapper<OptionPartViewModel, OptionPart>
    {
        public OptionPart Map(OptionPartViewModel optionPartViewModel)
        {
            var result = new OptionPart
            {
                OptionId = optionPartViewModel.OptionId,
                PartId = optionPartViewModel.PartId
            };

            return result;
        }
    }
}
