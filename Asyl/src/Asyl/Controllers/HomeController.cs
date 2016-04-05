using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Asyl.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Asyl.Controllers
{
    public class HomeController : Controller
    {
        AzureDbContext context;

        public HomeController(AzureDbContext context)
        {
            this.context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var dataManager = new DataManager(context);
            var model = dataManager.ListAllJobAds(); //Här skickas sorteringsvariabel in
            return View(model);

            //return View();
        }
        public IActionResult PostApplication(string coverLetter, string jobAdId2)
        {
            var jobAdId = Convert.ToInt32(jobAdId2);
            var datamanager = new DataManager(context);
            //var talentUsername = User.Identity.Name; <---den riktiga
            var talentUsername = "Zlatan10";
            datamanager.SaveApplication(talentUsername, coverLetter, jobAdId);
            var model = "succeded";
            return Json(model);
        }


    }
}
