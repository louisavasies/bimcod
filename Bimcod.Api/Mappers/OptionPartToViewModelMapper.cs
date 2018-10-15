using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bimcod.Api.ViewModels;
using Bimcod.Api.Models;

namespace Bimcod.Api.Mappers
{
    public class OptionPartToViewModelMapper : IEntityMapper<OptionPart, OptionPartViewModel>
    {
        public OptionPartViewModel Map(OptionPart optionPart)
        {
            var result = new OptionPartViewModel
            {
                OptionId = optionPart.OptionId,
                PartId = optionPart.PartId
            };

            return result;
        }
    }
}
