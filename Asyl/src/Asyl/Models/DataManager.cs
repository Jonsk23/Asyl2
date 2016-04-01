using Asyl.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asyl.Models
{
    public class DataManager
    {
        AzureDbContext context;

        public DataManager(AzureDbContext context)
        {
            this.context = context;
        }

        public void CreateUser(CreateUserVM viewModel)
        {
            var existingTalent = context.Talents.ToList().Find(o => o.Username == viewModel.Username);

            if (existingTalent == null)
            {
                context.Talents.Add(new Talent
                {
                    Username = viewModel.Username,
                    Name = viewModel.Name,
                    Email = viewModel.Email,
                    PhoneNumber = viewModel.PhoneNumber,
                    YearsInPrimarySchool = viewModel.YearsInPrimarySchool,
                    YearsInSecondarySchool = viewModel.YearsInSecondarySchool,
                    WorkExperience = viewModel.WorkExperience,
                    SpeaksSwedish = viewModel.SpeaksSwedish,
                    SpeaksEnglish = viewModel.SpeaksEnglish,
                    DrivingLicense = viewModel.DrivingLicense

                });
                context.SaveChanges();
            }
            else
                throw new Exception("Username already exists!");
        }
    }
}
