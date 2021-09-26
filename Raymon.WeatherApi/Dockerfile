#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Raymon.WeatherApi/Raymon.WeatherApi.csproj", "Raymon.WeatherApi/"]
COPY ["Raymon.Services/Raymon.Services.csproj", "Raymon.Services/"]
COPY ["Raymon.Common/Raymon.Common.csproj", "Raymon.Common/"]
COPY ["Raymon.DataAccess/Raymon.DataAccess.csproj", "Raymon.DataAccess/"]
COPY ["Raymon.Domain/Raymon.Domain.csproj", "Raymon.Domain/"]
COPY ["Raymon.Framwork/Raymon.Framwork.csproj", "Raymon.Framwork/"]
RUN dotnet restore "Raymon.WeatherApi/Raymon.WeatherApi.csproj"
COPY . .
WORKDIR "/src/Raymon.WeatherApi"
RUN dotnet build "Raymon.WeatherApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Raymon.WeatherApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Raymon.WeatherApi.dll"]
