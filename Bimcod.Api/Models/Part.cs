using System;
using System.Collections.Generic;

namespace Bimcod.Api.Models
{
    public partial class Part
    {
        public Part()
        {
            OptionPart = new HashSet<OptionPart>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<OptionPart> OptionPart { get; set; }
    }
}
