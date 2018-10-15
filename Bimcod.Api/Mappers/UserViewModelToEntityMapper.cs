using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bimcod.Api.ViewModels;
using Bimcod.Api.Models;

namespace Bimcod.Api.Mappers
{
    public class UserViewModelToEntityMapper : IEntityMapper<UserViewModel, User>
    {
        public User Map(UserViewModel userViewModel)
        {
            var result = new User
            {
                Id = userViewModel.Id,
                Username = userViewModel.Username,
                Email = userViewModel.Email,
                Password = userViewModel.Password
            };

            return result;
        }
    }
}
