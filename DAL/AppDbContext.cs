using Microsoft.EntityFrameworkCore;
using ProniaBB209.Models;

namespace ProniaBB209.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
  

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer("server=msi;database=ProniaBB209;trusted_connection=true;integrated security=true;TrustServerCertificate=true; ");
        //}

        public DbSet<Slide> Slides { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }



    }
}
