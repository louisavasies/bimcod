

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Bimcod.Api.Models;
using Bimcod.Api.Repositories;
using Bimcod.Api.Utilities;
using Bimcod.Api.ViewModels;

namespace bimcod.api.controllers
{
    [Route("api/[controller]")]
    public class FacebookController : Controller
    {
        private readonly AuthenticationService authenticationService;
        private readonly UserRepository userRepository;

        public FacebookController(AuthenticationService service, UserRepository userRepo)
        {
            this.authenticationService = service;
            this.userRepository = userRepo;
        }
        [HttpPost]
        public IActionResult Login([FromBody]FacebookViewModel content)
        {
            User user = new User
            {
                Username = content.Name,
                Email = content.Email,
                Password = null,
                IsConfirmed = true
            };
            if (this.userRepository.AddUser(user) == null)
            {
                user = this.userRepository.UserGetUserByEmail(user.Email);
            }
            string userToken = this.authenticationService.GenerateTokenForUser(user);
            return Ok(new { token = userToken });
        }
    }
}

