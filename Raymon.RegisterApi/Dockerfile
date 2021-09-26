#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Raymon.RegisterApi/Raymon.RegisterApi.csproj", "Raymon.RegisterApi/"]
COPY ["Raymon.Services/Raymon.Services.csproj", "Raymon.Services/"]
COPY ["Raymon.Common/Raymon.Common.csproj", "Raymon.Common/"]
COPY ["Raymon.DataAccess/Raymon.DataAccess.csproj", "Raymon.DataAccess/"]
COPY ["Raymon.Domain/Raymon.Domain.csproj", "Raymon.Domain/"]
COPY ["Raymon.Framwork/Raymon.Framwork.csproj", "Raymon.Framwork/"]
RUN dotnet restore "Raymon.RegisterApi/Raymon.RegisterApi.csproj"
COPY . .
WORKDIR "/src/Raymon.RegisterApi"
RUN dotnet build "Raymon.RegisterApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Raymon.RegisterApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Raymon.RegisterApi.dll"]
