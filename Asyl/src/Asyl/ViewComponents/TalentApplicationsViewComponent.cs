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
    public class TalentApplicationsViewComponent: ViewComponent
    {
        public DataManager datamanager;
        
        public TalentApplicationsViewComponent(AzureDbContext context)
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
