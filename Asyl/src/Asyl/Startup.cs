using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace Asyl
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            var connString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=CatShelter;Integrated Security=True;Pooling=False";
            var identityConnString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=IdentityDB;Integrated Security=True;Pooling=False";

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<IdentityDbContext>(o => o.UseSqlServer(identityConnString));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<CatShelterContext>(o => o.UseSqlServer(connString));

            //services.AddTransient<ICatsRepository, DbCatsRepository>();
            services.AddTransient<ICatsRepository, TestCatsRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();

            app.UseCookieAuthentication(o =>
            {
                o.AutomaticChallenge = true;
                //o.LoginPath = new PathString("/Members/Login/");
            });

            //app.UseIdentity();
            app.UseMvcWithDefaultRoute();
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
