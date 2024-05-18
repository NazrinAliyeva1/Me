using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProniaTask.Models;

namespace ProniaTask.DataAccesLayer
{
    public class ProniaContext : IdentityDbContext
    {
        public ProniaContext(DbContextOptions options) : base(options)
        {            

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Slider>Sliders { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<AppUser>AppUsers { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        ((BaseEntity)entry.Entity).CreateTime= DateTime.Now;
                        ((BaseEntity)entry.Entity).isDeleted = false;
                        break;
                    case EntityState.Modified:
                        ((BaseEntity)entry.Entity).UpdateTime= DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseSqlServer("Server=LAPTOP-PVUROI38\\SQLEXPRESS; Database=AB106Pronia; Trusted_Connection=True;TrustServerCertificate=True");
        //    base.OnConfiguring(options);
        //}
        
    }
}
