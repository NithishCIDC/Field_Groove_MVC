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
			ViewData["Title"] = "Login | ";

			try
			{
				if (ModelState.IsValid)
				{
					await unitOfWork.UserRepository.IsValidUser(entity);
					return RedirectToAction("Dashboard");
				}
			}
			catch (Exception ex)
			{
				ViewBag.ErrorMessage = ex.Message;
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
		public IActionResult Dashboard()
		{
			return View();
		}

		[HttpGet]
		public IActionResult WaitingActivation()
		{
			ViewData["Title"] = "Register | ";
			return View();
		}
	}
}
