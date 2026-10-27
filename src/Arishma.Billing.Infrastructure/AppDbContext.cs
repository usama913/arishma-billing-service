using Microsoft.EntityFrameworkCore;
using Arishma.Billing.Domain;
namespace Arishma.Billing.Infrastructure;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Subscription> Subscriptions => Set<Subscription>();
    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Subscription>().ToTable("subscriptions");
        base.OnModelCreating(b);
    }
}
