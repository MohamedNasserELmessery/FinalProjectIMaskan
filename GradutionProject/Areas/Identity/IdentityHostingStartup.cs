using System;
using GradutionProject.Areas.Identity.Data;
using GradutionProject.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(GradutionProject.Areas.Identity.IdentityHostingStartup))]
namespace GradutionProject.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            //builder.ConfigureServices((context, services) => {
            //    services.AddDbContext<ApplicationDbContext>(options =>
            //   options.UseSqlServer(
            //      context.Configuration.GetConnectionString("GraduationProject")));
            //    services.AddDefaultIdentity<ApplicationUser>(options => {
            //        options.SignIn.RequireConfirmedAccount = true;
            //        options.Password = new PasswordOptions()
            //        {
            //            RequiredLength=8,
            //            RequireDigit=true,
            //            RequireNonAlphanumeric=true,
            //            RequireLowercase=true,
            //            RequireUppercase=true
            //        };
            //        options.Lockout = new LockoutOptions() {
            //            DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5),
            //            MaxFailedAccessAttempts = 5,
            //            AllowedForNewUsers = true
            //    };
            //        })
            //   .AddEntityFrameworkStores<ApplicationDbContext>();
            //});
        }
    }
}