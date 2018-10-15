using System;
using System.Collections.Generic;

namespace Bimcod.Api.Models
{
    public partial class CarOption
    {
        public int CarId { get; set; }
        public int OptionId { get; set; }

        public Car Car { get; set; }
        public Option Option { get; set; }
    }
}
