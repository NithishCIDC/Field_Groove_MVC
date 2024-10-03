using Feild_Groove.Domain.Models;
using Field_Groove.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Field_Groove.Web.Controllers
{
	public class AccountController : Controller
	{
		private readonly IUnitOfWork unitOfWork;

		public AccountController(IUnitOfWork unitOfWork)
        {
			this.unitOfWork = unitOfWork;
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
			var status = await unitOfWork.UserRepository.IsRegisterd(entity);
			ViewBag.ErrorMessage(status);
			return View();
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
			await unitOfWork.UserRepository.Create(entity);
			return View();
		}
	}
}
