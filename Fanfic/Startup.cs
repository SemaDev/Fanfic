using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Fanfic.Data;
using Fanfic.Models;
using Fanfic.Services;
using Fanfic.Extensions;

namespace Fanfic
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(setupAction =>
            {
                setupAction.Password.RequireDigit = false;
                setupAction.Password.RequiredLength = 6;
                setupAction.Password.RequireLowercase = false;
                setupAction.Password.RequireNonAlphanumeric = false;
                setupAction.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication().AddFacebook(Options =>
            {
                Options.AppId = "2037493549871604";
                Options.AppSecret = "eef56a2724df180864fc76d65574ce5d";
            });

            services.AddAuthentication().AddTwitter(Options =>
            {
                Options.ConsumerKey = "cD0iCUriIx1DLJiSNfeFzGur2";
                Options.ConsumerSecret = "IPyehEYxmO0Vb8zCTjQL2PAABdxsqyXV9bwu78AyfqWXoU49cF";
            });

            services.AddAuthentication().AddVKontakte(Options =>
            {
                Options.ClientId = "6413095";
                Options.ClientSecret = "eGZj7cri33hP9PivsTb2";
            });

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseUserDestroyer();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });


        }
    }
}
