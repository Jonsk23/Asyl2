using Asyl.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using System.Diagnostics;

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
        } //Skapar privat användares profil (erfarenheter osv.)

        public void CreateJobAd(JobAdVM viewModel, string userName)
        {
            var companyId = context.Company  //Hämtar Företags ID baserat på inloggat företags anv.namn
                .Where(o => o.CompanyUsername == userName)
                .Select(o => o.Id)
                .Single();

            context.Add(new JobAd
            {
                FieldOfWork = viewModel.FieldOfWork,
                Description = viewModel.Description,
                Title = viewModel.Title,
                DurationInWeeks = viewModel.DurationInWeeks,
                LocationId = viewModel.LocationId,
                CompanyId = companyId
            });
            context.SaveChanges();
        } //Skapar jobannons, avsedd för företag endast. Tar in företags username


        public PublishAdVM[] ListAllJobAds() //Listar alla jobb, avsedd för jobbsökande användare.
        {
            return context.JobAd
                .OrderBy(o => o.Company.CompanyName)
                  .Select(o => new PublishAdVM
                  {
                      Description = o.Description,
                      FieldOfWork = o.FieldOfWork,
                      CompanyName = o.Company.CompanyName,
                      CompanyWebPage = o.Company.CompanyWebPage,
                      DurationInWeeks = o.DurationInWeeks,
                      LocationId = o.LocationId,
                      Title = o.Title,
                      JobAdId = o.Id,
                      Logo = o.Company.Logo
                  })
                  .ToArray();

        }

        public void CreateCompany(CreateCompanyVM viewModel) // Skapar ett företag med info.
        {
            var existingCompany = context.Company.ToList().Find(o => o.CompanyUsername == viewModel.Username);

            if (existingCompany == null)
            {
                context.Company.Add(new Company
                {
                    CompanyName = viewModel.CompanyName,
                    CorporateIdentityNumber = viewModel.CorporateIdentityNumber,
                    ContactPerson = viewModel.ContactPerson,
                    CompanyWebPage = viewModel.CompanyWebPage,
                    Email = viewModel.Email,
                    CompanyUsername = viewModel.Username
                });
                context.SaveChanges();
            }
            else
                throw new Exception("Company already exists!");

        }

        public ApplicationsOnJobVM[] ListAllApplication(int jobId) // Listar alla ansökningar för ett specifikt jobb. Avsedd för Företag.
        {
            //tar in jobID som tillhör det jobb vi vill ha ut ansökningar för.
            return context.Applications
                .Where(o => o.JobAdId == jobId)
                .OrderBy(o => o.Talent.Id)
                  .Select(o => new ApplicationsOnJobVM
                  {
                      TalentId = o.TalentId,
                      Name = o.Talent.Name,
                      Email = o.Talent.Email,
                      CoverLetter = o.CoverLetter,
                      WorkExperience = o.Talent.WorkExperience,
                      DrivingLicense = (o.Talent.DrivingLicense == true) ? "yes" : "no",
                      PhoneNumber = o.Talent.PhoneNumber,
                      SpeaksSwedish = (o.Talent.SpeaksSwedish == true) ? "yes" : "no",
                      SpeaksEnglish = (o.Talent.SpeaksEnglish == true) ? "yes" : "no",
                      YearsInPrimarySchool = o.Talent.YearsInPrimarySchool,
                      YearsInSecondarySchool = o.Talent.YearsInSecondarySchool
                  })
                  .ToArray();
        }


        public CompanyExistingAdsVM[] ListAllJobsAdsForCompany(string companyUsername) //Listar alla jobbannonser som ett företag har lagt ut

        {

            var companyId = context.Company  //Hämtar Företags ID baserat på inloggat företags anv.namn
                .Where(o => o.CompanyUsername == companyUsername)
                .Select(o => o.Id)
                .Single();

            return context.JobAd
                .Where(o => o.CompanyId == companyId)
               .OrderBy(o => o.Id)
                 .Select(o => new CompanyExistingAdsVM
                 {
                     Id = o.Id,
                     ApplicationCount = o.Applications.Count,
                     CompanyId = o.CompanyId,
                     Description = o.Description,
                     FieldOfWork = o.FieldOfWork,
                     Title = o.Title,
                     DurationInWeeks = o.DurationInWeeks,
                     LocationId = o.LocationId
                 })
                 .ToArray();



        }

        public void SaveApplication(string talentUsername, string coverLetter, int jobAdId)
        {
            var talentId = context.Talents  //Hämtar Företags ID baserat på inloggat företags anv.namn
         .Where(o => o.Username == talentUsername)
         .Select(o => o.Id)
         .Single();


            context.Applications.Add(new Application
            {
                CoverLetter = coverLetter,
                JobAdId = jobAdId,
                TalentId = talentId
            });
            context.SaveChanges();

        } // skapar en ansökan , avsedd för privata anv.
    }

}