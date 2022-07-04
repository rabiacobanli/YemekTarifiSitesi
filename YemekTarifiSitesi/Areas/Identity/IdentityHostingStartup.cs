using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EntityLayer.Concrete;
using DataAccessLayer.Concrete;

[assembly: HostingStartup(typeof(YemekTarifiSitesi.Areas.Identity.IdentityHostingStartup))]
namespace YemekTarifiSitesi.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<YemekTarifiSitesiContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("YemekTarifiSitesiContextConnection")));

                services.AddDefaultIdentity<Kullanici>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<YemekTarifiSitesiContext>();
            });
        }
    }
}