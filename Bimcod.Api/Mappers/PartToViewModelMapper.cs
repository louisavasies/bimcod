using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bimcod.Api.ViewModels;
using Bimcod.Api.Models;

namespace Bimcod.Api.Mappers
{
    public class PartToViewModelMapper : IEntityMapper<Part, PartViewModel>
    {
        public PartViewModel Map(Part entity)
        {
            var result = new PartViewModel
            {
                Id = entity.Id,
                Name = entity.Name
            };

            return result;
        }
    }
}
