using ITWEB_M3.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ITWEB_M3.Context
{
    public class EmbededStockContext : DbContext
    {
        public DbSet<Category> Categories { get; set;}
        
        public DbSet<Component> Components { get; set;}

        public DbSet<ComponentType> ComponentTypes { get; set;}

        public DbSet<ESImage> ESImages { get; set;}


        public EmbededStockContext(DbContextOptions<EmbededStockContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<CategoryToComponentType>().HasKey(t => new {t.CategoryId, t.ComponentTypeId});

            modelBuilder.Entity<ComponentType>()
                .HasMany(c => c.Components)
                .WithOne(e => e.ComponentType)
                .HasForeignKey(k => k.ComponentTypeId);
        }
        
    }
}
