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
			string? status=null;
			if (ModelState.IsValid)
			{
				status = await unitOfWork.UserRepository.IsValidUser(entity);
				ViewBag.Status = status;
			}
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
			if (ModelState.IsValid)
			{
				string status = await unitOfWork.UserRepository.Create(entity);
				ViewBag.Status = status;
				if(status == "Successfully Registered")
				return RedirectToAction("Login");
			}
			ViewData["Title"] = "Register | ";
			return View(entity);
		}
	}
}
