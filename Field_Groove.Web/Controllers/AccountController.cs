using Microsoft.AspNetCore.Mvc;

namespace Field_Groove.Web.Controllers
{
	public class AccountController : Controller
	{
		public IActionResult Login()
		{
			return View();
		}
		public IActionResult Register()
		{
			return View();
		}
	}
}
