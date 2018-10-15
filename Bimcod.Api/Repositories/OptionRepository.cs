using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bimcod.Api.Models;

namespace Bimcod.Api.Repositories
{
    public class OptionRepository
    {
        private BimcodContext context = new BimcodContext();

        public OptionRepository(BimcodContext context)
        {
            this.context = context;
        }


        public List<Option> GetAllOptionsFor(string version)
        {
            return context.Option
                .Where(o => o.ModuleName == version)
                .ToList();
        }

    }
}
