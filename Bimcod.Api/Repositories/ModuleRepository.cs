using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bimcod.Api.Models;

namespace Bimcod.Api.Repositories
{
    public class ModuleRepository
    {
        private BimcodContext context = new BimcodContext();

        public ModuleRepository(BimcodContext context)
        {
            this.context = context;
        }

        public List<Module> GetAllModulesFor(string version)
        {
            return context.Module
                .Where(m => m.For == version)
                .ToList();
        }
    }
}
