using System;
using System.Collections.Generic;

namespace Bimcod.Api.Models
{
    public partial class User
    {
        public User()
        {
            Car = new HashSet<Car>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public bool IsConfirmed { get; set; }

        public ICollection<Car> Car { get; set; }
    }
}
