namespace Arishma.Billing.Application;
public interface ISubscriptionRepository
{
    Task<IReadOnlyList<SubscriptionDto>> ListAsync(CancellationToken ct = default);
}
