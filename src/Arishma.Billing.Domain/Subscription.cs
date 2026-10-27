namespace Arishma.Billing.Domain;
public class Subscription
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string PlanName { get; set; } = "Starter";
    public decimal PriceUsd { get; set; }
    public int VerifiedLeads { get; set; }
}
