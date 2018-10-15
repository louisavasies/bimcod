using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bimcod.Api.ViewModels
{
    public class PasswordViewModel
    {
        [Required(ErrorMessage = "Password cannot be empty")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password must contains between 6 and 20 characters")]
        public string Password { get; set; }
    }
}
