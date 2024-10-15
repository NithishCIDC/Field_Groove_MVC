using Field_Groove.Domain.Models;
using Field_Groove.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Field_Groove.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IConfiguration _configuration;	

		public HomeController(ILogger<HomeController> logger , IConfiguration configuration)
		{
			_logger = logger;
            _configuration = configuration;
        }

		public IActionResult Index()
		{
			return RedirectToAction("Login","Account");
		}

        [HttpGet]
        public IActionResult Dashboard()
        {
			ViewBag.Username = _configuration["UserDetails:Email"];
            return View();
        }
		
		[HttpGet]
        public IActionResult Leads()
        {
            ViewBag.Username = _configuration["UserDetails:Email"];
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
