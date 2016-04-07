using Asyl.Models;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asyl.ViewComponents
{
    public class CompanyApplicationsViewComponent : ViewComponent
    {
        public DataManager datamanager;

        public CompanyApplicationsViewComponent(AzureDbContext context)
        {
            datamanager = new DataManager(context);
        }

        public IViewComponentResult Invoke(string CompanyUsername)
        {
            var viewModel = datamanager.ListAllJobsAdsForCompany (CompanyUsername);
            return View(viewModel);
        }
    }
}
