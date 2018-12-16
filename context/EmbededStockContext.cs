using ITWEB_M3.Models;
using Microsoft.EntityFrameworkCore;

public class EmbededStockContext : DbContext
{
    public EmbededStockContext(DbContextOptions<EmbededStockContext> options) : base(options)
    {

    }

    public DbSet<Category> Categories { get; set;}
    public DbSet<Component> Components { get; set;}

    public DbSet<ComponentType> ComponentTypes { get; set;}

    public DbSet<ESImage> ESImages { get; set;}
}