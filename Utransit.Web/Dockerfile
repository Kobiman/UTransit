#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Utransit.Web/Utransit.Web.csproj", "Utransit.Web/"]
COPY ["UTransit.Data/UTransit.Data.csproj", "UTransit.Data/"]
COPY ["UTransit.Models/UTransit.Models.csproj", "UTransit.Models/"]
COPY ["UTransit.Data.Contracts/UTransit.Data.Contracts.csproj", "UTransit.Data.Contracts/"]
COPY ["Utransit.Services/Utransit.Services.csproj", "Utransit.Services/"]
COPY ["Utransit.Services.Contracts/Utransit.Services.Contracts.csproj", "Utransit.Services.Contracts/"]
RUN dotnet restore "Utransit.Web/Utransit.Web.csproj"
COPY . .
WORKDIR "/src/Utransit.Web"
RUN dotnet build "Utransit.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Utransit.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Utransit.Web.dll"]