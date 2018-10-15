using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bimcod.Api.Models;

namespace Bimcod.Api.Repositories
{
    public class BuiltInCarRepository
    {
        private BimcodContext context = new BimcodContext();

        public BuiltInCarRepository(BimcodContext context)
        {
            this.context = context;
        }

        public List<BuiltInCar> GetAllBuiltInCars()
        {
            return context.BuiltInCar.ToList();
        }
    }
}
