using System;
using System.Collections.Generic;

namespace Bimcod.Api.Models
{
    public partial class Module
    {
        public Module()
        {
            Option = new HashSet<Option>();
        }

        public string ModuleName { get; set; }
        public string For { get; set; }

        public ICollection<Option> Option { get; set; }
    }
}
