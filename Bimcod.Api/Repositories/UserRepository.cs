using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bimcod.Api.Models;
using Bimcod.Api.Utilities;

namespace Bimcod.Api.Repositories
{
    public class UserRepository
    {
        private BimcodContext context;
        private AuthenticationService authenticationService;
        public UserRepository(BimcodContext context, AuthenticationService authenticationService)
        {
            this.context = context;
            this.authenticationService = authenticationService;
        }

        public User AddUser(User user)
        {
            User foundUser = context.User.Where(u => u.Username == user.Username).FirstOrDefault();
            if ( foundUser != null)
            {
                return null;
            }

            context.Add(user);
            context.SaveChanges();
            return user;
        }

        public void DeleteUser(int id)
        {
            context.User.Remove(new User { Id = id });
            context.SaveChanges();
        }

        public User GetUserById(int id)
        {
            return context.User.FirstOrDefault(u => u.Id == id);
        }

        public User UpdateUser(User user)
        {
            User foundUser = context.User.FirstOrDefault(u => u.Id == user.Id);
            foundUser.Username = user.Username;
            foundUser.Password = user.Password;
            context.SaveChanges();
            return user;
        }

        public void Activate(int id)
        {
            User user = context.User.FirstOrDefault(u => u.Id == id);
            user.IsConfirmed = true;
            context.SaveChanges();
        }

        internal User GetUserByEmail(string email)
        {
            return context.User.FirstOrDefault(u => u.Email == email);
        }

        public User UserGetUserByEmail(string email)
        {
            return context.User.FirstOrDefault(x => x.Email == email);
        }

        public bool CheckIfUserExists(int userId)
        {
            return context.User.Any(u => u.Id == userId);
        }
    }
}
