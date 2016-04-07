using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Asyl.ViewModels;
using Asyl.Models;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Asyl.Controllers
{
    public class CompanyController : Controller
    {

        AzureDbContext context;
        DataManager dataManager;


        SignInManager<IdentityUser> signInManager;
        UserManager<IdentityUser> userManager;
        IdentityDbContext idContext;
        RoleManager<IdentityRole> roleManager;

        public CompanyController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IdentityDbContext idContext, AzureDbContext context, RoleManager<IdentityRole> roleManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.idContext = idContext;
            this.context = context;
            this.roleManager = roleManager;
        }

        [Authorize(Roles = "company user")]
        public IActionResult CreateJobAd()
        {
            return View();
        }

        [Authorize(Roles = "company user")]
        [HttpPost]
        public IActionResult CreateJobAd(JobAdVM viewModel)
        {
            dataManager = new DataManager(context);
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var userName = User.Identity.Name;

            dataManager.CreateJobAd(viewModel, userName);
            //dataManager.CreateJobAd(viewModel, "Doktorn");

            return RedirectToAction(nameof (CompanyController.CompanyProfile), "Company");
        }

        [Authorize(Roles = "company user")]
        public IActionResult CompanyProfile()
        {
            dataManager = new DataManager(context);
            var model = dataManager.ViewMyCompanyProfile(User.Identity.Name);
            //var model = dataManager.ListAllJobsAdsForCompany("Doktorn");
            return View(model);

        }

        [HttpPost]
        public IActionResult UpdateCompanyProfile(MyCompanyProfileVM viewModel)
        {
            dataManager = new DataManager(context);
            dataManager.UpdateCompanyProfile(User.Identity.Name, viewModel);
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public IActionResult Applications(int jobid)
        {
            dataManager = new DataManager(context);
            var model = dataManager.ListAllApplication(jobid);
            return View(model);
        }
    }
}
