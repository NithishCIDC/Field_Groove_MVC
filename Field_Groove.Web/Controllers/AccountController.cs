using Field_Groove.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Field_Groove.Domain.Models;

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
			string? status;
			if (ModelState.IsValid)
			{
				status = await unitOfWork.UserRepository.IsValidUser(entity);
				ViewBag.ErrorMessage = status;
				if(status == "Loggined Successfully")
					return RedirectToAction("Dashboard");
			}
			return View(entity);
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
				ViewBag.ErrorMessage = status;
				if(status == "Successfully Registered")
				return RedirectToAction("Dashboard");
			}
			ViewData["Title"] = "Register | ";
			return View(entity);
		}

		[HttpGet]
		public IActionResult Dashboard()
		{
			return View();
		}
	}
}
