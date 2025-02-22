FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR /app
COPY . .

RUN dotnet restore

RUN dotnet publish -c Release -o /out

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS final
WORKDIR /app

COPY --from=base /out ./

CMD ["sh", "-c", "dotnet ef database update && dotnet ParkingSystem.dll"]

