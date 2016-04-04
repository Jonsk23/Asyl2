using Asyl.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

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
                    Name = viewModel.CompanyName,
                    Email = viewModel.Email,
                    PhoneNumber = viewModel.CompanyWebPage,
                    YearsInPrimarySchool = viewModel.ContactPerson,
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

        public void CreateJobAd(JobAdVM viewModel, string userName)
        {
            var id = context.Company  //Hämtar Företags ID baserat på inloggat företags anv.namn
                .Where(o => o.CompanyName == userName)
                .Select(o => o.Id)
                .ToString();

            var companyId = Convert.ToInt32(id);

            context.Add(new JobAd
            {
                FieldOfWork = viewModel.FieldOfWork,
                Description = viewModel.Description,
                CompanyId = companyId
            });
            context.SaveChanges();
        }

       
        public List<PublishAdVM> ListAllJobAds() //Listar alla jobb, avsedd för jobbsökande användare.
        { 

            return context.JobAd
                .OrderBy(o => o.Company.CompanyName)
                  .Select(o => new PublishAdVM { Description = o.Description, FieldOfWork = o.FieldOfWork, CompanyName = o.Company.CompanyName, CompanyWebPage = o.Company.CompanyWebPage})                 
                  .ToList();          
          
                
        }

        public void CreateCompany(CreateCompanyVM viewModel)
        {
            var existingCompany = context.Company.ToList().Find(o => o.CompanyName == viewModel.Username);

            if (existingCompany == null)
            {
                context.Company.Add(new Company
                {
                    CompanyName = viewModel.Username,
                    CorporateIdentityNumber = viewModel.CorporateIdentityNumber,
                    ContactPerson = viewModel.ContactPerson,
                    CompanyWebPage = viewModel.CompanyWebPage,
                    Email = viewModel.Email                    

                });
                context.SaveChanges();
            }
            else
                throw new Exception("Company already exists!");

        }

        public List<ApplicationVM> ListAllApplication(int jobId) // Listar alla ansökningar för ett specifikt jobb. Avsedd för Företag.
        {
            //tar in jobID som tillhör det jobb vi vill ha ut ansökningar för.
            return context.Applications
                .Where(o => o.JobAdId == jobId)
                .OrderBy(o => o.Talent.Id)
                  .Select(o => new ApplicationVM {
                      JobAdId = o.JobAdId,
                      TalentId = o.TalentId,
                      Name = o.Talent.Name,
                      Email = o.Talent.Email,
                      CoverLetter = o.CoverLetter,
                      WorkExperience = o.Talent.WorkExperience,                  
                      DrivingLicense = o.Talent.DrivingLicense,
                      PhoneNumber = o.Talent.PhoneNumber,
                      SpeaksSwedish = o.Talent.SpeaksSwedish,
                      SpeaksEnglish = o.Talent.SpeaksEnglish,
                      YearsInPrimarySchool = o.Talent.YearsInPrimarySchool,
                      YearsInSecondarySchool = o.Talent.YearsInSecondarySchool                      
                  })
                  .ToList();
        }

        public void CreateApplication()
        {

        }
    }
}
