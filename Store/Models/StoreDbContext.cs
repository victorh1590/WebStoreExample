using Microsoft.EntityFrameworkCore;
namespace Store.Models
{
  public class StoreDbContext : DbContext
  {
    public StoreDbContext(DbContextOptions<StoreDbContext> options)
    : base(options) { }
    public DbSet<Product> Products => Set<Product>(); // Used to query/store in DB.
  }
}