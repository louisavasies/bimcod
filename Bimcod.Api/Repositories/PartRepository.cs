using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bimcod.Api.Models;

namespace Bimcod.Api.Repositories
{
    public class PartRepository
    {
        private BimcodContext context = new BimcodContext();

        public PartRepository(BimcodContext context)
        {
            this.context = context;
        }

        public List<Part> GetAllPartsByOptionId(int optionId)
        {
            return context.Part
                .Where(p => p.OptionPart.FirstOrDefault(op => op.OptionId == optionId) != null)
                .ToList();
        }
    }
}
