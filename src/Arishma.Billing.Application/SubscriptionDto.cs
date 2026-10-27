namespace Arishma.Billing.Application;
public record SubscriptionDto(Guid Id, string Name);
public record ServiceInfoDto(string Service, string Subdomain, string Status, string DatabaseProvider);
