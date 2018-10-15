using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bimcod.Api.Attributes
{
    public class EmailValidationAttribute : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            if (value.ToString().Contains("@") && value.ToString().Contains("."))
                return true;
            else
                return false;
        }
    }
}
