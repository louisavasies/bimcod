using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bimcod.Api.ViewModels;
using Bimcod.Api.Models;

namespace Bimcod.Api.Mappers
{
    public class ModuleViewModelToEntityMapper : IEntityMapper<ModuleViewModel, Module>
    {
        public Module Map(ModuleViewModel moduleViewModel)
        {
            var result = new Module
            {
                ModuleName = moduleViewModel.ModuleName,
                For = moduleViewModel.For
            };

            return result;
        }
    }
}
