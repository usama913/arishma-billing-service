FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY *.sln ./
COPY src/Arishma.Billing.Api/Arishma.Billing.Api.csproj src/Arishma.Billing.Api/
COPY src/Arishma.Billing.Application/Arishma.Billing.Application.csproj src/Arishma.Billing.Application/
COPY src/Arishma.Billing.Domain/Arishma.Billing.Domain.csproj src/Arishma.Billing.Domain/
COPY src/Arishma.Billing.Infrastructure/Arishma.Billing.Infrastructure.csproj src/Arishma.Billing.Infrastructure/
RUN dotnet restore src/Arishma.Billing.Api/Arishma.Billing.Api.csproj
COPY . .
RUN dotnet publish src/Arishma.Billing.Api/Arishma.Billing.Api.csproj -c Release -o /app/publish --no-restore
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://*:5006
ENTRYPOINT ["dotnet", "Arishma.Billing.Api.dll"]
