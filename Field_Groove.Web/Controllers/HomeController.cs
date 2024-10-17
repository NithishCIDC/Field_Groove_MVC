using Field_Groove.Application.Interfaces;
using Field_Groove.Domain.Models;
using Field_Groove.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text;

namespace Field_Groove.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork unitOfWork;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _configuration = configuration;
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            ViewBag.Username = _configuration["UserDetails:Email"];
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Leads()
        {
            ViewBag.Username = _configuration["UserDetails:Email"];
            var User =await unitOfWork.Leads.GetAll();
            return View(User);
        }

        [HttpGet]
        public IActionResult CreateLead()
        {
            ViewBag.Username = _configuration["UserDetails:Email"];
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateLead(LeadsModel model)
        {
            if(ModelState.IsValid)
            {
                await unitOfWork.Leads.Add(model);
                await unitOfWork.Save();
            }
            return RedirectToAction("Leads");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var User = await unitOfWork.Leads.GetById(id);
            return View(User);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(LeadsModel model)
        {
            await unitOfWork.Leads.Update(model);
            await unitOfWork.Save();
            return RedirectToAction("Leads");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await unitOfWork.Leads.Delete(id);
            await unitOfWork.Save();

            return RedirectToAction("Leads");
        }

        [HttpGet("download-csv")]
        public async Task<IActionResult> DownloadCsv()
        {
            var records = await unitOfWork.Leads.GetAll(); ;

            var csv = new StringBuilder();
            csv.AppendLine("ID,Project Name,Status,Added,Type,Contact,Action,Assignee,Bid Date");

            foreach (var record in records)
            {
                csv.AppendLine($"{record.Id},{record.ProjectName},{record.Status},{record.Added},{record.Type},{record.Contact},{record.Action},{record.Assignee},{record.BidDate}");
            }

            byte[] buffer = Encoding.UTF8.GetBytes(csv.ToString());
            return File(buffer, "text/csv", "data.csv");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
