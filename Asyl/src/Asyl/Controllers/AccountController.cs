using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Asyl.Controllers
{
    public class AccountController : Controller
    {

        SignInManager<IdentityUser> signInManager;
        UserManager<IdentityUser> userManager;
        IdentityDbContext idContext;


        //En konstruktor som tar in kontexterna
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IdentityDbContext idContext)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.idContext = idContext;

            
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
