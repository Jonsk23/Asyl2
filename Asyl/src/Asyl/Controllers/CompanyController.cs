using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Asyl.ViewModels;
using Asyl.Models;
using Microsoft.AspNet.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Asyl.Controllers
{
    public class CompanyController : Controller
    {

        AzureDbContext context;
        DataManager dataManager;

        public CompanyController(AzureDbContext context)
        {
            this.context = context;
        }

        //[Authorize(Roles = "company user")]
        public IActionResult Index()
        {
            dataManager = new DataManager(context);
            //var model = dataManager.ListAllJobsAdsForCompany(User.Identity.Name);  <-- den riktiga
            var model = dataManager.ListAllJobsAdsForCompany("Doktorn");
            return View(model);

            //return View();
        }

        //[Authorize(Roles = "company user")]
        public IActionResult CreateJobAd()
        {
            return View();
        }

        //[Authorize(Roles = "company user")]
        [HttpPost]
        public IActionResult CreateJobAd(JobAdVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            dataManager.CreateJobAd(viewModel, User.Identity.Name);

            return RedirectToAction(nameof (CompanyController.Index));
        }

        //[Authorize(Roles = "company user")]
        public IActionResult Applications(int id)
        {

            dataManager = new DataManager(context);           
            var model = dataManager.ListAllApplication(id);
            return View(model);

        }
    }
}
