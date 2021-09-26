#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Raymon.LoginApi/Raymon.LoginApi.csproj", "Raymon.LoginApi/"]
COPY ["Raymon.Services/Raymon.Services.csproj", "Raymon.Services/"]
COPY ["Raymon.Common/Raymon.Common.csproj", "Raymon.Common/"]
COPY ["Raymon.DataAccess/Raymon.DataAccess.csproj", "Raymon.DataAccess/"]
COPY ["Raymon.Domain/Raymon.Domain.csproj", "Raymon.Domain/"]
COPY ["Raymon.Framwork/Raymon.Framwork.csproj", "Raymon.Framwork/"]
RUN dotnet restore "Raymon.LoginApi/Raymon.LoginApi.csproj"
COPY . .
WORKDIR "/src/Raymon.LoginApi"
RUN dotnet build "Raymon.LoginApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Raymon.LoginApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Raymon.LoginApi.dll"]