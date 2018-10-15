using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Net.Mail;
using Bimcod.Api.Models;
using Bimcod.Api.Repositories;
using Bimcod.Api.Utilities;
using Bimcod.Api.ViewModels;

namespace Bimcod.Api.Controllers
{
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        private const string FromAddress = "noreply.bimcod@gmail.com";
        private const string Password = "Punseta10";
        private const string frontendBaseUrl = "http://localhost:3000";
        private const int ConfirmEmailExpiryHours = 168;
        private const int ResetPasswordExpiryHours = 5;

        private readonly UserRepository userRepository;
        private readonly AuthenticationService authenticationService;

        public EmailController(UserRepository userRepository, AuthenticationService authenticationService)
        {
            this.userRepository = userRepository;
            this.authenticationService = authenticationService;
        }

        private void SendEmail(string receiverAddress, string subject, string body)
        {
            SmtpClient client = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(FromAddress, Password)
            };

            using (MailMessage message = new MailMessage(FromAddress, receiverAddress) { Subject = subject, Body = body })
            {
                client.Send(message);
            }
        }

        [Route("email")]
        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public IActionResult SendEmail(int id)
        {
            User user = userRepository.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            string Subject = "Register your account";
            string token = authenticationService.GenerateTokenForUser(user, ConfirmEmailExpiryHours, "email");
            string registerAccountAddress = frontendBaseUrl + "/confirm/" + token;
            string Body = "Click the following link to register your account\n\n" + registerAccountAddress;
            this.SendEmail(user.Email, Subject, Body);
            return Ok();
        }

        [Route("token")]
        [HttpGet]
        [Authorize(Roles = "email")]
        public string ActivateAccount()
        {
            int userId = User.Claims.GetUserId();
            userRepository.Activate(userId);
            return "validation worked";
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult SendPasswordResetEmail([FromBody] EmailViewModel email)
        {
            User user = userRepository.GetUserByEmail(email.Email);

            if (user == null)
            {
                return NotFound();
            }

            string Subject = "Reset your password";
            string token = authenticationService.GenerateTokenForUser(user, ResetPasswordExpiryHours, "ResetPassword");
            string resetPasswordAddress = frontendBaseUrl + "/forgot/" + token;
            string Body = "Click the following link to reset your password\n\n" + resetPasswordAddress +
                "\n\nIf you didn't request this password reset, ignore this message";

            this.SendEmail(user.Email, Subject, Body);
            return Ok();
        }

        [HttpPut]
        [Authorize(Roles = "ResetPassword")]
        public IActionResult ResetPassword([FromBody] PasswordViewModel password)
        {
            string newPassword = password.Password.SHA256Encrypt();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrors().First());
            }

            int userId = User.Claims.GetUserId();
            User user = userRepository.GetUserById(userId);

            if (user == null)
            {
                return NotFound();
            }

            if (user.Password == newPassword)
            {
                return BadRequest("Your new password cannot be the same as the old one.");
            }

            user.Password = newPassword;
            userRepository.UpdateUser(user);
            return Ok();
        }
    }
}
