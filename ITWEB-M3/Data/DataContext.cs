using Microsoft.EntityFrameworkCore;

namespace ITWEB_M3.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<ComponentType> ComponentTypes { get; set; }
        public DbSet<ESImage> ESImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Component>().ToTable("Component");
            modelBuilder.Entity<ComponentType>().ToTable("ComponentType");
            //modelBuilder.Entity<ComponentTypeStatus>().ToTable("ComponentTypeStatus");
            modelBuilder.Entity<ESImage>().ToTable("ESImage");

            modelBuilder.Entity<ComponentTypeCategory>()
                .HasKey(cc => new { cc.ComponentTypeId, cc.CategoryId });

            modelBuilder.Entity<ComponentTypeCategory>()
                .HasOne(cc => cc.Category)
                .WithMany(c => c.ComponentTypeCategory)
                .HasForeignKey(cc => cc.CategoryId);

            modelBuilder.Entity<ComponentTypeCategory>()
                .HasOne(cc => cc.ComponentType)
                .WithMany(c => c.ComponentTypeCategory)
                .HasForeignKey(cc => cc.ComponentTypeId);

            modelBuilder.Entity<ComponentType>()
                .HasMany(c => c.Components)
                .WithOne(e => e.ComponentType)
                .HasForeignKey(k => k.ComponentTypeId)
                .OnDelete(DeleteBehavior.SetNull);
        }

    }
}
