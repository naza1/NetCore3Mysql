#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["BeachMdq.Api/BeachMdq.Api.csproj", "BeachMdq.Api/"]
COPY ["CrossCutting/CrossCutting.csproj", "CrossCutting/"]
COPY ["Infrastructure.Data/Infrastructure.Data.csproj", "Infrastructure.Data/"]
COPY ["Entities/Entities.csproj", "Entities/"]
RUN dotnet restore "BeachMdq.Api/BeachMdq.Api.csproj"
COPY . .
WORKDIR "/src/BeachMdq.Api"
RUN dotnet build "BeachMdq.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BeachMdq.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BeachMdq.Api.dll"]