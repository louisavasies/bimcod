using System;
using System.Collections.Generic;

namespace Bimcod.Api.Models
{
    public partial class Car
    {
        public Car()
        {
            CarOption = new HashSet<CarOption>();
        }

        public int Id { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public int? UserId { get; set; }

        public User User { get; set; }
        public ICollection<CarOption> CarOption { get; set; }
    }
}
