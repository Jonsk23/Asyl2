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
        public DataManager datamanager;
        
        public ApplicationsViewComponent(AzureDbContext context)
        {
            datamanager = new DataManager(context);
        }

        public IViewComponentResult Invoke(string Username)
        {            
            var viewModel = datamanager.ViewMyApplications(Username);
            return View(viewModel);
        }
    }
}
