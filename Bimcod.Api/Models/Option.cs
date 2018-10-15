using System;
using System.Collections.Generic;

namespace Bimcod.Api.Models
{
    public partial class Option
    {
        public Option()
        {
            CarOption = new HashSet<CarOption>();
            OptionPart = new HashSet<OptionPart>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public int? Duration { get; set; }
        public string ModuleName { get; set; }
        public int? Price { get; set; }

        public Module ModuleNameNavigation { get; set; }
        public ICollection<CarOption> CarOption { get; set; }
        public ICollection<OptionPart> OptionPart { get; set; }
    }
}
