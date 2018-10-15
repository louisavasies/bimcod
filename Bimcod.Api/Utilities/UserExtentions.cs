﻿using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Bimcod.Api.Utilities
{
    public static class UserExtensions
    {
        public static int GetUserId(this IEnumerable<Claim> user)
        {
            string userId = user.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier).Value;
            return int.Parse(userId);
        }
    }
}
