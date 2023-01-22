using System;
using Core_MVC_Application.Areas.Identity.Data;
using Core_MVC_Application.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Core_MVC_Application.Areas.Identity.IdentityHostingStartup))]
namespace Core_MVC_Application.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Core_MVC_ApplicationDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Core_MVC_ApplicationDBContextConnection")));

                services.AddDefaultIdentity<Core_MVC_ApplicationUser>(options => {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    
                    })
                    .AddEntityFrameworkStores<Core_MVC_ApplicationDBContext>();
            });
        }
    }
}