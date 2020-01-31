#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Registration-Login-Api/Registration-Login-Api.csproj", "Registration-Login-Api/"]
RUN dotnet restore "Registration-Login-Api/Registration-Login-Api.csproj"
COPY . .
WORKDIR "/src/Registration-Login-Api"
RUN dotnet build "Registration-Login-Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Registration-Login-Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Registration-Login-Api.dll"]