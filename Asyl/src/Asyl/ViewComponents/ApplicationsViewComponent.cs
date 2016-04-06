using Asyl.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asyl.ViewComponents
{
    public class ApplicationsViewComponent: ViewComponent
    {
        public ApplicationsViewComponent(DataManager datamanager, UserManager<IdentityUser> userManager)
        {
            this.datamanager = datamanager;
            this.userManager = userManager;
        }

        public DataManager datamanager;
        UserManager<IdentityUser> userManager;

        public IViewComponentResult Invoke(string Username)
        {
            
            var viewModel = datamanager.ViewMyApplications(Username);
            return View(viewModel);
        }
    }
}
