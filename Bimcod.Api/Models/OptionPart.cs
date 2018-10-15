using System;
using System.Collections.Generic;

namespace Bimcod.Api.Models
{
    public partial class OptionPart
    {
        public int OptionId { get; set; }
        public int PartId { get; set; }

        public Option Option { get; set; }
        public Part Part { get; set; }
    }
}
