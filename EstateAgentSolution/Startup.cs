using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using EstateAgentSolution.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.CookiePolicy;
using EstateAgentSolution.DataModel.UnitOfWork.Abstract;
using EstateAgentSolution.DataModel.UnitOfWork.Concrete;
using EstateAgentSolution.BusinessServices.Abstract;
using EstateAgentSolution.BusinessServices.Concrete;
using EstateAgentSolution.DataModel.Context;

namespace EstateAgentSolution
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
                options.Secure = CookieSecurePolicy.Always;
                options.HttpOnly = HttpOnlyPolicy.Always;
            });

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>().AddDefaultUI(UIFramework.Bootstrap4).AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddWebOptimizer(pipeline =>
            {
                //Add each CSS file that needs to go in here. This is mostly required if we have custom CSS files.
                //Files below are for your reference. Please remove these file and add your actual development related files.
                ////pipeline.AddCssBundle("/css/bundle.css", "wwwroot/css/site.css").UseContentRoot();

                //Add each JS file that needs to go in here. We will mostly require a fair amount of custom JS files.
                //Files below are for your reference. Please remove these file and add your actual development related files.
                ////pipeline.AddJavaScriptBundle("/js/bundle.js", "wwwroot/js/site.js", "wwwroot/js/site1.js", "wwwroot/js/site2.js").UseContentRoot();

                //This will minify the CSSS files after bundling them together. (Only if required for custom CSS files.)
                pipeline.MinifyCssFiles();
                //This will minify the JS files after bundling them together.
                ////pipeline.MinifyJsFiles();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseXContentTypeOptions();
            //app.UseReferrerPolicy(options => options.NoReferrer());
            //app.UseXfo(options => options.Deny());
            //app.UseXXssProtection(options => options.EnabledWithBlockMode());
            //app.UseCsp(options => options
            //    .DefaultSources(s => s.Self())
            //    .FontSources(s => s.Self())
            //    .ImageSources(s => s.Self())
            //    .ScriptSources(s => s.Self().CustomSources("scripts.nwebsec.com")));
            //app.UseHpkp(options => options
            //    .MaxAge(seconds: 20)
            //    .Sha256Pins("TODO=")
            //    .PinCertificate("TODO")
            //    );
            app.UseHsts(options => options.MaxAge(days: 365).IncludeSubdomains());
            app.UseNoCacheHttpHeaders();

            if (env.IsProduction())
            {
                app.UseWebOptimizer();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
