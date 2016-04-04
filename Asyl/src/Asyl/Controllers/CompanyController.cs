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

        public CompanyController(AzureDbContext context, DataManager dataManager)
        {
            this.context = context;
            this.dataManager = dataManager;
        }

        //[Authorize(Roles = "company user")]
        public IActionResult Index()
        {
            return View();
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
    }
}
