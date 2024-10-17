using Field_Groove.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Field_Groove.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace Field_Groove.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfiguration configuration;
        private readonly IEmailSender emailSender;

        public AccountController(IUnitOfWork unitOfWork, IConfiguration configuration, IEmailSender emailSender)
        {
            this.unitOfWork = unitOfWork;
            this.configuration = configuration;
            this.emailSender = emailSender;
        }
        [HttpGet]
        public IActionResult Login()
        {
            ViewData["Title"] = "Login | ";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel entity)
        {
            ViewData["Title"] = "Login | ";
            string[] errorMessages;

            try
            {
                if (ModelState.IsValid)
                {
                    await unitOfWork.UserRepository.IsValidUser(entity);
                    var token = GenerateJwtToken(entity.Email!);
                    configuration["Userdetails:Email"] = entity.Email;
                    return Json(new { success = true, message = token });
                }
            }
            catch (Exception ex)
            {
                errorMessages = [ex.Message];
                return Json(new { success = false, message = errorMessages });
            }
            errorMessages = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToArray();
            return Json(new { success = false, message = errorMessages });
        }

        public string GenerateJwtToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) }),
                Expires = DateTime.Now.AddMinutes(2),
                Issuer = configuration["Jwt:Issuer"],
                Audience = configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewData["Title"] = "Register | ";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel entity)
        {
            ViewData["Title"] = "Register | ";
            try
            {
                if (ModelState.IsValid)
                {
                    await unitOfWork.UserRepository.Create(entity);
                    return RedirectToAction("WaitingActivation");
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            return View(entity);
        }

        [HttpGet]
        public IActionResult WaitingActivation()
        {
            ViewData["Title"] = "Register | ";
            return View();
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            try
            {
                string password = await unitOfWork.UserRepository.IsValidEmail(email);
                string subject = "Reset Password";
                string message = "Your Current Password is " + password;
                await emailSender.EmailSendAsync(email, subject, message);
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            return RedirectToAction("ChangePassword");
        }
    }
}
