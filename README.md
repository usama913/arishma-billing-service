# arishma-billing-service

Separate microservice repo for Arishma Lead Workspace — **not** part of a shared solution.

- Service: Billing
- Subdomain: billing.arishmasolutions.com
- Local port: 5006
- Stack: .NET 8, DDD, EF Core

## Layers (DDD)

- `src/Arishma.Billing.Domain/` — entities, no dependencies. This is the bounded context.
- `src/Arishma.Billing.Application/` — DTOs, repository interfaces, use cases.
- `src/Arishma.Billing.Infrastructure/` — EF Core DbContext, repositories, database switch.
- `src/Arishma.Billing.Api/` — HTTP endpoints only. No business logic here.
- `tests/` — xUnit tests for the database-provider switch.

No other service's project is referenced. Services talk only through HTTP
(via the gateway) and, in Phase 1, through events. That is what makes them
independently deployable and scalable.

## Database switch — Postgres or MySQL, per service

This service reads its database from one place at startup, in this order:
1. Env vars `DATABASE_PROVIDER` and `DATABASE_CONNECTION_STRING` (win)
2. `appsettings.json` -> `Database.Provider` / `Database.ConnectionString`

To use MySQL for **this service only**, do one of these — no code change:

```bash
# appsettings.json
"Database": { "Provider": "MySql", "ConnectionString": "Server=localhost;Database=arishma_billing;User=arishma;Password=arishma-dev-only;" }
# or env
DATABASE_PROVIDER=MySql DATABASE_CONNECTION_STRING="Server=localhost;Database=arishma_billing;User=arishma;Password=arishma-dev-only;" dotnet run --project src/Arishma.Billing.Api
```

Default is Postgres. The other services keep whatever they were set to.

## Run

```bash
dotnet build Arishma.Billing.sln
dotnet run --project src/Arishma.Billing.Api
curl http://localhost:5006/health
curl http://localhost:5006/api/v1/service
dotnet test
```

## Status

Phase 0 scaffold only. No live Apify run, email send, or payment yet.
Secrets: use env vars at deploy time, never commit a real connection string.
