using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bimcod.Api.Models;

namespace Bimcod.Api.Repositories
{
    public class OptionPartRepository
    {
        private BimcodContext context = new BimcodContext();

        public OptionPartRepository(BimcodContext context)
        {
            this.context = context;
        }

        //public List<OptionPart> GetOptionPartByOptionId(int optionId)
        //{
        //    var partsOfOption = context.OptionPart.Where(optionpart => optionpart.OptionId == optionId).ToList();
        //    return partsOfOption;
        //}


        public List<Part> GetPartsByOptionId(int id)
        {
            int[] partIds = context.OptionPart.Where(op => op.OptionId == id).Select(op => op.PartId).ToArray();
            return context.Part.Where(p => partIds.Contains(p.Id)).ToList();
        }
    }
}
