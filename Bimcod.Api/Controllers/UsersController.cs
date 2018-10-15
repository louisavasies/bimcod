using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Bimcod.Api.Mappers;
using Bimcod.Api.Models;
using Bimcod.Api.Repositories;
using Bimcod.Api.ViewModels;
using Bimcod.Api.Utilities;
using Microsoft.AspNetCore.Authorization;


namespace Bimcod.Api.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly UserRepository userRepository;
        private readonly IEntityMapper<User, UserViewModel> entityToVmMapper;

        public UsersController(UserRepository userRepository, IEntityMapper<User, UserViewModel> entityToVmMapper)
        {
            this.userRepository = userRepository;
            this.entityToVmMapper = entityToVmMapper;
        }

        [Route("current")]
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            int userId = User.Claims.GetUserId();
            User user = userRepository.GetUserById(userId);
            if (user == null)
            {
                return NotFound("User doesn't exist");
            }
            UserViewModel userVm = this.entityToVmMapper.Map(user);
            return Ok(userVm);
        }

        [HttpPost]
        public IActionResult Add([FromBody]UserViewModel user)
        {

            if (!ModelState.IsValid)
            {
                var errors = ModelState.GetErrors();
                return BadRequest(errors);
            }

            User userToSave = new User
            {
                Username = user.Username,
                Password = user.Password.SHA256Encrypt(),
                Email = user.Email
            };

            User newUser = userRepository.AddUser(userToSave);

            if (newUser == null)
            {
                return BadRequest("User couldn't be created");
            }
            UserViewModel userVm = entityToVmMapper.Map(newUser);
            return Created($"/{userVm.Id}", userVm);
        }

        [HttpPut]
        public IActionResult Update([FromBody]UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.GetErrors();
                return BadRequest(errors);
            }

            if (!userRepository.CheckIfUserExists(user.Id))
            {
                return NotFound("User doesn't exist");
            }

            User userToUpdate = new User
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password.SHA256Encrypt(),
                Email = user.Email
            };

            User updatedUser = userRepository.UpdateUser(userToUpdate);
            UserViewModel userVm = entityToVmMapper.Map(updatedUser);
            return Accepted($"/{userVm.Id}", userVm);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            userRepository.DeleteUser(id);
            return Ok();
        }
    }
}