using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bimcod.Api.ViewModels;
using Bimcod.Api.Models;

namespace Bimcod.Api.Mappers
{
    public class ModuleToViewModelMapper : IEntityMapper<Module, ModuleViewModel>
    {
        public ModuleViewModel Map(Module entity)
        {
            var result = new ModuleViewModel
            {
                ModuleName = entity.ModuleName,
                For = entity.For
            };

            return result;
        }
    }
}
