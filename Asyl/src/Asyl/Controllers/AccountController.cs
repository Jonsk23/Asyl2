using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Asyl.ViewModels;
using Asyl.Models;

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


        //En konstruktor som tar in kontexterna
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IdentityDbContext idContext, AzureDbContext context)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.idContext = idContext;
            this.context = context;         
        }


        // GET: /<controller>/
        public IActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginPage(LoginVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            

            return View();
        }

        public IActionResult RegistrationPage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistrationPage(CreateUserVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            //Skapar användare
            await context.Database.EnsureCreatedAsync();
            var result = await userManager.CreateAsync(new IdentityUser(viewModel.Username), viewModel.Password);

            //Visa eventuella felmeddelanden
            if (!result.Succeeded)
            {
                ModelState.AddModelError(nameof(LoginVM.Username), result.Errors.First().Description);
                return View(viewModel);
            }

            await signInManager.PasswordSignInAsync(viewModel.Username, viewModel.Password, false, false);

            dataManager = new DataManager(context);
            dataManager.CreateUser(viewModel);
            return RedirectToAction(nameof(HomeController.Index));  
        }
    }
}
