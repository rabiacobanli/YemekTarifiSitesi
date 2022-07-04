using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete
{
    public class YemekTarifiSitesiContext : IdentityDbContext<Kullanici>
    {
        public YemekTarifiSitesiContext(DbContextOptions<YemekTarifiSitesiContext> options)
            : base(options)
        {
        }
        public DbSet<Malzeme> Malzeme { get; set; }
        public DbSet<Yemek> Yemek { get; set; }
        public DbSet<YemekMalzeme> YemekMalzeme { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<YemekKategori> YemekKategori { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
