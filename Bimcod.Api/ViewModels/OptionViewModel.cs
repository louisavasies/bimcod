using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bimcod.Api.ViewModels
{
    public class OptionViewModel
    {
        public int Id { get; set;}
        public string Description { get; set; }
        public int? Duration { get; set; }
        public string ModuleName { get; set; }
        public int? Price { get; set; }
    }
}
