using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bimcod.Api.ViewModels;
using Bimcod.Api.Models;

namespace Bimcod.Api.Mappers
{
    public class UserToViewModelMapper : IEntityMapper<User, UserViewModel>
    {
        public UserViewModel Map(User entity)
        {
            var result = new UserViewModel
            {
                Id = entity.Id,
                Username = entity.Username,
                Email = entity.Email,
                Password = entity.Password
            };

            return result;
        }
    }
}
