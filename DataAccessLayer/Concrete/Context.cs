using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<Kullanici>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.\\SQLEXPRESS;database=YemekTarifSitesi;integrated security=true;");

        }
        public DbSet<Malzeme> Malzeme { get; set; }
        public DbSet<Yemek> Yemek { get; set; }
        public DbSet<YemekMalzeme> YemekMalzeme { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<YemekKategori> YemekKategori { get; set; }

    }
}
