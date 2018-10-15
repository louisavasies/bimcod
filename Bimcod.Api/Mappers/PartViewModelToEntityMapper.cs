using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bimcod.Api.ViewModels;
using Bimcod.Api.Models;

namespace Bimcod.Api.Mappers
{
    public class PartViewModelToEntityMapper : IEntityMapper<PartViewModel, Part>
    {
        public Part Map(PartViewModel partViewModel)
        {
            var result = new Part
            {
                Id = partViewModel.Id,
                Name = partViewModel.Name
            };

            return result;
        }
    }
}
