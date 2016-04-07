using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Asyl.ViewModels;
using Asyl.Models;
using Microsoft.AspNet.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Asyl.Controllers
{
    public class AccountController : Controller
    {

        SignInManager<IdentityUser> signInManager;
        UserManager<IdentityUser> userManager;
        IdentityDbContext idContext;
        AzureDbContext context;
        DataManager dataManager;
        RoleManager<IdentityRole> roleManager;

        //En konstruktor som tar in kontexterna
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IdentityDbContext idContext, AzureDbContext context, RoleManager<IdentityRole> roleManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.idContext = idContext;
            this.context = context;
            this.roleManager = roleManager;
        }


        // GET: /<controller>/
        public IActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginPage(LoginVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            await signInManager.PasswordSignInAsync(viewModel.Username, viewModel.Password, false, false);
            var user = await userManager.FindByNameAsync(viewModel.Username);
            var isInrole = await userManager.IsInRoleAsync(user, "company user");            
            if (isInrole) 
            {
                return RedirectToAction(nameof(CompanyController.Index), "Company");
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

        }
     
        public IActionResult RegistrationPage()
        {
            return View();
        }

        public async Task<IActionResult> Logout ()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpPost]
        public async Task<IActionResult> RegistrationPage(CreateUserVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var rolename = "talent user"; //eventuellt skapa en klass för detta. 
            var role = await roleManager.CreateAsync(new IdentityRole(rolename));


            await idContext.Database.EnsureCreatedAsync();
            var result = await userManager.CreateAsync(new IdentityUser(viewModel.Username), viewModel.Password);
            var currentUser = userManager.FindByNameAsync(viewModel.Username);
            var newResult = await userManager.AddToRoleAsync(currentUser.Result, rolename);

            //Visa eventuella felmeddelanden
            if (!result.Succeeded)
            {
                ModelState.AddModelError(nameof(LoginVM.Username), result.Errors.First().Description);
                return View(viewModel);
            }

            await signInManager.PasswordSignInAsync(viewModel.Username, viewModel.Password, false, false);

            dataManager = new DataManager(context);
            dataManager.CreateUser(viewModel);
            return RedirectToAction(nameof(HomeController.Index), "Home");
          
        }

        public IActionResult CreateCompany()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(CreateCompanyVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var rolename = "company user"; //eventuellt skapa en klass för detta. 
            var role = await roleManager.CreateAsync(new IdentityRole(rolename));

            //Skapar användare(företag)
            await context.Database.EnsureCreatedAsync();
            var result = await userManager.CreateAsync(new IdentityUser(viewModel.Username), viewModel.Password);
            var currentUser = userManager.FindByNameAsync(viewModel.Username);
            var newResult = await userManager.AddToRoleAsync(currentUser.Result, "company user");

            //Visa eventuella felmeddelanden
            if (!result.Succeeded)
            {
                ModelState.AddModelError(nameof(LoginVM.Username), result.Errors.First().Description);
                return View(viewModel);
            }

            await signInManager.PasswordSignInAsync(viewModel.Username, viewModel.Password, false, false);

            dataManager = new DataManager(context);
            dataManager.CreateCompany(viewModel);
            return RedirectToAction(nameof(CompanyController.Index), "Company");
        }

        [Authorize(Roles = "talent user")]  /*<-- denna ska vara på.ska bara vara synlig för privata användare.*/
        public IActionResult MyApplications()
        {
            dataManager = new DataManager(context);
            var model = dataManager.ViewMyApplications(User.Identity.Name); /*< --den riktiga*/
            //var model = dataManager.ViewMyApplications("Barack");
            return View(model);
        }

        [Authorize(Roles = "talent user")]
        public IActionResult MyProfile()
        {
            dataManager = new DataManager(context);
            var model = dataManager.ViewMyProfile(User.Identity.Name);
            return View(model);
        }

        [HttpPost]
        public IActionResult MyProfile(MyProfileVM viewModel)
        {
            dataManager = new DataManager(context);
            dataManager.UpdateProfile(User.Identity.Name, viewModel);
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }




    }
}
