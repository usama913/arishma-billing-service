using Arishma.Billing.Application;
namespace Arishma.Billing.Infrastructure;
public class EfSubscriptionRepository : ISubscriptionRepository
{
    private readonly AppDbContext _db;
    public EfSubscriptionRepository(AppDbContext db) => _db = db;
    // Phase 0: scaffold returns no rows and never requires a live DB for /health.
    // Phase 1: replace with a real query over _db.Subscriptions.
    public Task<IReadOnlyList<SubscriptionDto>> ListAsync(CancellationToken ct = default)
        => Task.FromResult<IReadOnlyList<SubscriptionDto>>(Array.Empty<SubscriptionDto>());
}
